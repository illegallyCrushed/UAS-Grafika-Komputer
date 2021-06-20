using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace UAS
{
    class ImageStore
    {
        public String dirname;
        public int imgHandle;

        public ImageStore(string path)
        {
            dirname = path;
            List<byte> image_pixels;

            byte[] Data;
            int Width;
            int Height;

            Image<Rgba32> image = Image.Load<Rgba32>(path);
            image.Mutate(x => x.Flip(FlipMode.Vertical));
            image_pixels = new List<byte>(4 * image.Width * image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                var row = image.GetPixelRowSpan(y);

                for (int x = 0; x < image.Width; x++)
                {
                    image_pixels.Add(row[x].R);
                    image_pixels.Add(row[x].G);
                    image_pixels.Add(row[x].B);
                    image_pixels.Add(row[x].A);
                }
            }
            Width = image.Width;
            Height = image.Height;
            Data = image_pixels.ToArray();

            imgHandle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, imgHandle);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, Data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, (float)TextureWrapMode.Repeat);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public ImageStore(byte[] compressedData, int hash)
        {

            dirname = hash.ToString();

            List<byte> image_pixels;

            byte[] Data;
            int Width;
            int Height;

            Image<Rgba32> image = Image.Load<Rgba32>(compressedData);
            image.Mutate(x => x.Flip(FlipMode.Vertical));
            image_pixels = new List<byte>(4 * image.Width * image.Height);
            for (int y = 0; y < image.Height; y++)
            {
                var row = image.GetPixelRowSpan(y);

                for (int x = 0; x < image.Width; x++)
                {
                    image_pixels.Add(row[x].R);
                    image_pixels.Add(row[x].G);
                    image_pixels.Add(row[x].B);
                    image_pixels.Add(row[x].A);
                }
            }
            Width = image.Width;
            Height = image.Height;
            Data = image_pixels.ToArray();

            imgHandle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, imgHandle);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, Data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, (float)TextureWrapMode.ClampToEdge);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public ImageStore(byte[] Data, int Width, int Height, int hash)
        {
            imgHandle = GL.GenTexture();
            GL.BindTexture(TextureTarget.Texture2D, imgHandle);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, Data);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapR, (float)TextureWrapMode.ClampToEdge);
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public static int ImageLookup(ref List<ImageStore> ImageLib, String path)
        {
            foreach (var imagestore in ImageLib)
            {
                if (imagestore.dirname == path)
                {
                    Console.WriteLine("ImageLookup - Found!");
                    Console.WriteLine(path);
                    Console.WriteLine(imagestore.imgHandle);
                    return imagestore.imgHandle;
                }
            }

            ImageStore temp = new ImageStore(path);
            ImageLib.Add(temp);
            Console.WriteLine("ImageLookup - Added!");
            Console.WriteLine(path);
            Console.WriteLine(temp.imgHandle);
            return temp.imgHandle;
        }

        public static int ImageLookup(ref List<ImageStore> ImageLib, int hash, byte[] compressedData)
        {
            foreach (var imagestore in ImageLib)
            {
                if (imagestore.dirname == hash.ToString())
                {
                    Console.WriteLine("ImageLookup - Found!");
                    Console.WriteLine(hash.ToString());
                    Console.WriteLine(imagestore.imgHandle);
                    return imagestore.imgHandle;
                }
            }

            ImageStore temp = new ImageStore(compressedData, hash);
            ImageLib.Add(temp);
            Console.WriteLine("ImageLookup - Added!");
            Console.WriteLine(hash.ToString());
            Console.WriteLine(temp.imgHandle);
            return temp.imgHandle;
        }

        public static int ImageLookup(ref List<ImageStore> ImageLib, int hash, byte[] Data, int Width, int Height)
        {
            foreach (var imagestore in ImageLib)
            {
                if (imagestore.dirname == hash.ToString())
                {
                    Console.WriteLine("ImageLookup - Found!");
                    Console.WriteLine(hash.ToString());
                    Console.WriteLine(imagestore.imgHandle);
                    return imagestore.imgHandle;
                }
            }

            ImageStore temp = new ImageStore(Data, Width, Height, hash);
            ImageLib.Add(temp);
            Console.WriteLine("ImageLookup - Added!");
            Console.WriteLine(hash.ToString());
            Console.WriteLine(temp.imgHandle);
            return temp.imgHandle;
        }
    }
}
