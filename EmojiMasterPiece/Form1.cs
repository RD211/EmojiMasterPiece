using GA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace EmojiMasterPiece
{
    public partial class Form1 : Form
    {
        public float mutation = 0.3f;
        public static EmojiPlacementAndType GetRandomEmoji()
        {
            var position = new Point(
                StaticRandom.Rand(GlobalImageData.targetPicture.Width),
                StaticRandom.Rand(GlobalImageData.targetPicture.Height)
                );
            var emojiNumber = StaticRandom.Rand(GlobalImageData.emojis.Count);
            int rotation = StaticRandom.Rand(GlobalImageData.emojis[0][0].Count);
            int scale = StaticRandom.Rand(GlobalImageData.emojis[0].Count);
            return new EmojiPlacementAndType(position, emojiNumber,scale,rotation);
        }
        public static double RateEmojiAtPos(DirectBitmap bit, int x,int y)
        {

            double sum = 0;
            int times = 0;
            for(int i = y;i<Math.Min(GlobalImageData.targetPicture.Height,y+bit.Height);i++)
            {
                for(int j = x;j<Math.Min(GlobalImageData.targetPicture.Width,x+bit.Width);j++)
                {
                    times++;
                    var pixel1 = bit.GetPixel(j-x, i-y);
                    var pixel2 = GlobalImageData.targetPicture.GetPixel(j, i);
                    sum -= Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.G - pixel2.G) + Math.Abs(pixel1.B - pixel2.B);
                }
            }

            return -(Math.Abs(sum)/times);
        }
        public Living Mate(Living a, Living b)
        {
            List<EmojiPlacementAndType> emojis = new List<EmojiPlacementAndType>();
            DirectBitmap bitmap = new DirectBitmap(GlobalImageData.targetPicture.Width,
                GlobalImageData.targetPicture.Height);
            Graphics g = Graphics.FromImage(bitmap.Bitmap);
            for(int i = 0;i<GlobalImageData.emojisNeeded;i++)
            {

                EmojiPlacementAndType current;
                double first = RateEmojiAtPos(
                    GlobalImageData.emojis[a.emojis[i].emojiNumber][a.emojis[i].scale][a.emojis[i].rotation],
                    a.emojis[i].position.X,a.emojis[i].position.Y);
                double second = RateEmojiAtPos(
                    GlobalImageData.emojis[b.emojis[i].emojiNumber][b.emojis[i].scale][b.emojis[i].rotation],
                    b.emojis[i].position.X, b.emojis[i].position.Y);
                if (first > second)
                    current = a.emojis[i];
                else
                    current = b.emojis[i];
                emojis.Add(current);
                if ((float)StaticRandom.Rand(101)/(float)100 < mutation)
                    current = GetRandomEmoji();
                double sum2 = 0;
                int times = 0;
                for (int ii = current.position.Y; 
                    ii < Math.Min(GlobalImageData.targetPicture.Height, 
                    current.position.Y + 
                    GlobalImageData.emojis
                    [current.emojiNumber][current.scale][current.rotation].Height); ii++)
                {
                    for (int jj = current.position.X; jj < Math.Min(
                        GlobalImageData.targetPicture.Width, 
                        current.position.X + GlobalImageData.emojis
                    [current.emojiNumber][current.scale][current.rotation].Width); jj++)
                    {
                        times++;
                        var pixel1 = bitmap.GetPixel(jj, ii);
                        var pixel2 = GlobalImageData.targetPicture.GetPixel(jj, ii);
                        sum2 -= Math.Abs(pixel1.R - pixel2.R) + Math.Abs(pixel1.G - pixel2.G) + Math.Abs(pixel1.B - pixel2.B);
                    }
                }
                sum2 = -(Math.Abs(sum2) / times);
                if (sum2>Math.Max(first,second))
                {
                    current = GetRandomEmoji();
                }
                lock(GlobalImageData.emojis)
                g.DrawImageUnscaled(
                    GlobalImageData.emojis[current.emojiNumber][current.scale][current.rotation].Bitmap,
                    current.position.X,current.position.Y);
                emojis[i] = current;

                
            }
            g.Dispose();
            bitmap.Dispose();
            
            return new Living(emojis);
        }
        public Living Create()
        {
            List<EmojiPlacementAndType> emojis = new List<EmojiPlacementAndType>();
            for(int i = 0;i<GlobalImageData.emojisNeeded;i++)
            {
                emojis.Add(GetRandomEmoji());
            }
            return new Living(emojis);
        }

        GA<Living> ga;
        public Form1()
        {
            InitializeComponent();
        }

        private void btn_startStop_Click(object sender, EventArgs e)
        {
            if(EvolutionTimer.Enabled)
            {
                EvolutionTimer.Enabled = false;
                EvolutionTimer.Stop();
                btn_startStop.Text = "Start";
                btn_reset.Enabled = true;
            }
            else
            {
                EvolutionTimer.Enabled = true;
                EvolutionTimer.Start();
                btn_reset.Enabled = false;
                btn_startStop.Text = "Stop";
            }
            /*
            Thread t = new Thread(() => {
                picture_target.Image = GlobalImageData.GetMozaic();
            });
            t.Start();
            */
        }
        int generations = 0;
        private async void Advance()
        {
            ga.Eval();
        }
        bool working = false;
        private void EvolutionTimer_Tick(object sender, EventArgs e)
        {
            if (!working) {

                working = true;
                Task.Run(Advance).GetAwaiter().OnCompleted(()=> {
                    working = false;
                    generations++;
                    lock (ga)
                    {
                        chart_evolution.Series.Last().Points.AddY(ga.GetBestContender().Measure() / 10000);
                        if (chart_evolution.Series.Last().Points.Count >= 2)
                        {
                            chart_derivative.Series.Last().Points.AddY(
                                chart_evolution.Series.Last().Points.Last().YValues[0] -
                                chart_evolution.Series.Last().Points[chart_evolution.Series.Last().Points.Count - 2].YValues[0]
                                );
                        }
                        if(generations%5==0)
                            picture_output.Image = ga.GetBestContender().GetEmojiDrawing().Bitmap;

                        lbl_generation.Text = $"Generation:{generations}\nScore:{ga.GetBestContender().Measure()}";
                    }
                });
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            chart_evolution.Series.Clear();
            chart_derivative.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Scores")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = Color.Blue,
                BorderWidth = 3
            };
            var increasingSeries = new System.Windows.Forms.DataVisualization.Charting.Series("Increase")
            {
                ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line,
                Color = Color.DarkRed,
                BorderWidth = 3
            };
            this.list_emojis.View = View.LargeIcon;
            this.list_emojis.LargeImageList = this.emoji_images;

            GlobalImageData.GetImages(emojiFolder, target);
            UpdateParameterPics();
            chart_evolution.Series.Add(series);
            chart_derivative.Series.Add(increasingSeries);
            ga = new GA<Living>(10, Mate, Create,0.5f,0.1f);
            trackBar_mutation.Value = (int)(mutation*100);
            trackBar_reproduction.Value = 50;
            trackBar_top.Value = 10;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btn_export_Click(object sender, EventArgs e)
        {
            picture_output.Image.Save("saved.png",ImageFormat.Png);
        }
        string emojiFolder = "Emojis/", target = "Target/target.png";

        private void btn_target_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            if (dia.ShowDialog() == DialogResult.OK)
            {
                GlobalImageData.ChangeTarget(dia.FileName);
                UpdateParameterPics();
            }
        }
        void UpdateParameterPics()
        {
            this.emoji_images.Images.Clear();
            this.list_emojis.Items.Clear();
            int indx = 0;
            GlobalImageData.emojisOriginals.ForEach((emoji) => { 

                emoji_images.Images.Add(emoji[0][0]);
                ListViewItem item = new ListViewItem();
                item.ImageIndex = indx;
                indx++;
                this.list_emojis.Items.Add(item);
            });
            this.picture_target.Image = GlobalImageData.targetPicture.Bitmap;
        }

        private void trackBar_mutation_Scroll(object sender, EventArgs e)
        {
            mutation = (float)trackBar_mutation.Value / (float)100f;
        }

        private void trackBar_top_Scroll(object sender, EventArgs e)
        {
            lock(ga)
            {
                ga.top = (float)trackBar_top.Value / (float)100f;
            }
        }

        private void trackBar_reproduction_Scroll(object sender, EventArgs e)
        {
            lock (ga)
            {
                ga.top = (float)trackBar_top.Value / (float)100f;
            }
        }

        private void lbl_mutation_Click(object sender, EventArgs e)
        {

        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            GlobalImageData.emojisNeeded = (int)num_emojis.Value;
            ga = new GA<Living>((int)num_populationSize.Value,
                Mate,
                Create,
                (float)trackBar_mutation.Value / 100f,
                                (float)trackBar_top.Value / 100f);
            chart_derivative.Series.Last().Points.Clear();
            chart_evolution.Series.Last().Points.Clear();
            generations = 0;
        }

        private void num_populationSize_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btn_brute_Click(object sender, EventArgs e)
        {
            this.picture_output.Image = GlobalImageData.GetMozaic((int)num_brute.Value);
        }

        private void btn_emojiFolder_Click(object sender, EventArgs e)
        {
            OpenFileDialog dia = new OpenFileDialog();
            if (dia.ShowDialog() == DialogResult.OK)
            {
                GlobalImageData.AddEmoji(dia.FileName);
                UpdateParameterPics();
            }

        }
    }
}
