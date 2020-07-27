using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace EmojiMasterPiece
{
    public class DirectBitmap : IDisposable
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        public DirectBitmap(int width, int height)
        {
            Width = width;
            Height = height;
            Bits = new Int32[width * height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(width, height, width * 4, PixelFormat.Format32bppArgb, BitsHandle.AddrOfPinnedObject());
        }
        public DirectBitmap(Bitmap bmp)
        {
            Width = bmp.Width;
            Height = bmp.Height;
            Bits = new Int32[Width * Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(bmp.Width, bmp.Height, bmp.Width * 4, PixelFormat.Format32bppArgb, BitsHandle.AddrOfPinnedObject());
            Graphics g = Graphics.FromImage(Bitmap);
            g.DrawImageUnscaled(bmp, 0, 0);
            g.Dispose();
            bmp.Dispose();
        }
        public DirectBitmap(string filename)
        {
            var temp = new Bitmap(filename);
            Width = temp.Width;
            Height = temp.Height;
            Bits = new Int32[temp.Width * temp.Height];
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(temp.Width, temp.Height, temp.Width * 4, PixelFormat.Format32bppArgb, BitsHandle.AddrOfPinnedObject());
            Graphics g = Graphics.FromImage(Bitmap);
            g.DrawImageUnscaled(temp, 0, 0);
            g.Dispose();
        }
        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            Bits[index] = col;
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col = Bits[index];
            Color result = Color.FromArgb(col);

            return result;
        }
        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }


}
