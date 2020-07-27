using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmojiMasterPiece
{
    public static class GlobalImageData
    {
        public static Random rand = new Random();
        public static int emojisNeeded = 100;
        public static volatile List<List<List<DirectBitmap>>> emojis = new List<List<List<DirectBitmap>>>();
        public static volatile List<List<List<Bitmap>>> emojisOriginals = new List<List<List<Bitmap>>>();

        public static volatile DirectBitmap targetPicture;
        public static float ratioChange = 0.0f;

        public static void AddEmoji(string path)
        {
            var bmp = new DirectBitmap(path);
            emojis.Add(new List<List<DirectBitmap>>());
            emojisOriginals.Add(new List<List<Bitmap>>());
            for (int i = 1; i <= 5; i++)
            {
                emojis.Last().Add(new List<DirectBitmap>());
                emojisOriginals.Last().Add(new List<Bitmap>());
                DirectBitmap otherBit = new DirectBitmap((int)((float)bmp.Width / (float)i * ratioChange)+1, (int)((float)bmp.Height / (float)i * ratioChange) +1);
                DirectBitmap originalBit = new DirectBitmap(bmp.Width / i, bmp.Height / i);

                Graphics g = Graphics.FromImage(otherBit.Bitmap);
                g.DrawImage(bmp.Bitmap, 0, 0, otherBit.Width, otherBit.Height);
                Graphics g2 = Graphics.FromImage(originalBit.Bitmap);
                g2.DrawImage(bmp.Bitmap, 0, 0, originalBit.Width, originalBit.Height);
                for (int j = 0; j < 10; j++)
                {

                    emojis.Last().Last().Add(new DirectBitmap(otherBit.Bitmap.RotateImage(j * 36)));
                    emojisOriginals.Last().Last().Add(originalBit.Bitmap.RotateImage(j * 36));
                }
                g.Dispose();
                g2.Dispose();
                otherBit.Dispose();
                originalBit.Dispose();
            }
        }
        public static void ChangeTarget(string path)
        {
            var temp = new Bitmap(path);
            ratioChange = (float)100 / temp.Width;
            targetPicture = new DirectBitmap((int)((float)temp.Width * ratioChange) + 1, 
                (int)((float)temp.Height * ratioChange) + 1);
            Graphics g = Graphics.FromImage(targetPicture.Bitmap);
            g.DrawImage(temp, 0, 0, (float)temp.Width * ratioChange, (float)temp.Height * ratioChange);
            g.Dispose();
            best = null;
        }
        public static void GetImages(string emojiFolder, string target)
        {
            ChangeTarget(target);
            Directory.GetFiles($"{emojiFolder}/").ToList().ForEach((file)=> {
                AddEmoji(file);
            });
        }
        public static DirectBitmap best ;
        //public static List<List<List<int>>> saved;

        public static Bitmap GetMozaic(int repeat)
        {
            if (best == null)
                best = new DirectBitmap(targetPicture.Width, targetPicture.Height);
           // if(saved==null)
           //     saved = Enumerable.Range(0, emojis[0].Count).Select((_)=>Enumerable.Range(0, best.Height).Select((i) => Enumerable.Range(0, best.Width).Select(x => 0).ToList()).ToList()).ToList();
            Graphics g = Graphics.FromImage(best.Bitmap);
            ParallelEnumerable.Range(0, repeat).ForAll((times) =>
            {
                int i = StaticRandom.Rand(targetPicture.Height);
                int j = StaticRandom.Rand(targetPicture.Width);
                for (int repetitions = 0; repetitions < 10; repetitions++)
                {
                    int size = StaticRandom.Rand(emojis[0].Count);
                    int rotation = StaticRandom.Rand(emojis[0][0].Count);
                    var emoji = emojis[StaticRandom.Rand(emojis.Count)][size][rotation];

                    int first = 0;
                    for (int ii = i; ii < Math.Min(i + emoji.Height,
                        targetPicture.Height); ii++)
                    {
                        for (int jj = j; jj < Math.Min(j + emoji.Width,
                            targetPicture.Width); jj++)
                        {
                            var pixel1 = targetPicture.GetPixel(jj, ii);
                            var pixel2 = emoji.GetPixel(jj - j, ii - i);
                            if (pixel2.R + pixel2.B + pixel2.G >= 3 * 250
                            || pixel2.A <= 1)
                                pixel2 = best.GetPixel(jj, ii);
                            first -= Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.B - pixel2.B) + Math.Abs(pixel1.G - pixel2.G);
                        }
                    }
                    int second = 0;
                    //if (saved[size][i][j] >= -1)
                    //{
                    for (int ii = i; ii < Math.Min(i + emoji.Height,
                        targetPicture.Height); ii++)
                    {
                        for (int jj = j; jj < Math.Min(j + emoji.Width,
                            targetPicture.Width); jj++)
                        {
                            var pixel1 = targetPicture.GetPixel(jj, ii);
                            var pixel2 = best.GetPixel(jj, ii);
                            if (pixel2.A <= 1)
                                second -= 3 * 255;
                            else
                                second -= Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.B - pixel2.B) + Math.Abs(pixel1.G - pixel2.G);

                        }
                    }
                    //saved[size][i][j] = second;
                    //}
                    //else
                    // second = saved[size][i][j];

                    if (first > second)
                    {
                        lock(GlobalImageData.targetPicture)
                            lock(emoji)
                            g.DrawImageUnscaled(emoji.Bitmap, j, i);
                        //saved[size][i][j] = first;
                    }
                }
            });
                                
                        
            g.Dispose();
            return best.Bitmap;
        }
    }
    public static class StaticRandom
    {
        static int seed = Environment.TickCount;

        static readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(Interlocked.Increment(ref seed)));

        public static int Rand(int max)
        {
            return random.Value.Next(max);
        }
    }
}
