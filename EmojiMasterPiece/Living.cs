using GA;
using GATesting.GA;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmojiMasterPiece
{
    public struct EmojiPlacementAndType
    {
        public Point position;
        public int emojiNumber;
        public int scale;
        public int rotation;
        public EmojiPlacementAndType(Point position, int emojiNumber, int scale, int rotation)
        {
            this.position = position;
            this.emojiNumber = emojiNumber;
            this.scale = scale;
            this.rotation = rotation;
        }
    };
    public class Living : IFitness
    {
        public List<EmojiPlacementAndType> emojis = new List<EmojiPlacementAndType>();
        double? fitness;
        public Living(List<EmojiPlacementAndType> emojis)
        {
            this.emojis = emojis;
            Measure();
        }
        public DirectBitmap GetEmojiDrawingFast()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            DirectBitmap bmp = new DirectBitmap(GlobalImageData.targetPicture.Width, 
                GlobalImageData.targetPicture.Height);
            Graphics g = Graphics.FromImage(bmp.Bitmap);
            emojis.ForEach((emoji) => {
                lock (GlobalImageData.emojis)
                {
                    g.DrawImageUnscaled(GlobalImageData.emojis[emoji.emojiNumber][emoji.scale][emoji.rotation].Bitmap,
                            emoji.position);
                }
                
            });
            g.Dispose();
            watch.Stop();
            return bmp;
        }
        public DirectBitmap GetEmojiDrawing()
        {
            DirectBitmap bmp = new DirectBitmap((int)((float)GlobalImageData.targetPicture.Width/GlobalImageData.ratioChange),
                (int)(GlobalImageData.targetPicture.Height / GlobalImageData.ratioChange));
            Graphics g = Graphics.FromImage(bmp.Bitmap);
            Parallel.ForEach(emojis, (emoji) => {
                lock (GlobalImageData.emojis)
                {
                    lock (bmp)
                    {
                        g.DrawImageUnscaled(
                            GlobalImageData.emojisOriginals[emoji.emojiNumber][emoji.scale][emoji.rotation],
                            (int)((float)emoji.position.X/(float)GlobalImageData.ratioChange),
                            (int)((float)emoji.position.Y / (float)GlobalImageData.ratioChange));
                    }
                }
            });
            g.Dispose();
            return bmp;
        }
        public double Measure()
        {
            if (fitness != null) return (double)fitness;
            var pic = GetEmojiDrawingFast();
            double distance = 0;

            for(int i = 0;i<GlobalImageData.targetPicture.Height;i++)
            {
                for(int j = 0;j<GlobalImageData.targetPicture.Width;j++)
                {
                    
                    var pixel1 = GlobalImageData.targetPicture.GetPixel(j,i);
                    var pixel2 = pic.GetPixel(j,i);
                    double dPix = Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.B - pixel2.B) + Math.Abs(pixel1.G - pixel2.G);
                    distance -= dPix;
                }
            }
            pic.Dispose();
            fitness = distance;
            return distance;

        }
    }
}
