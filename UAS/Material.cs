using LearnOpenTK.Common;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using System.Globalization;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;

namespace UAS
{
    class Material
    {
        public Vector3 ambient;
        public Vector3 diffuse;
        public Vector3 specular;
        public float specularExponent;
        public float alpha;
        public float dispHeight;

        public string name;

        public byte[] diffData;
        public int diffWidth;
        public int diffHeight;

        public byte[] specData;
        public int specWidth;
        public int specHeight;

        public byte[] normData;
        public int normWidth;
        public int normHeight;

        public byte[] paraData;
        public int paraWidth;
        public int paraHeight;

        public byte[] ambiData;
        public int ambiWidth;
        public int ambiHeight;

        public Material(string matname = "Default")
        {
            name = matname;
            ambient.X = 1;
            ambient.Y = 1;
            ambient.Z = 1;
            diffuse.X = 1;
            diffuse.Y = 1;
            diffuse.Z = 1;
            specular.X = 1;
            specular.Y = 1;
            specular.Z = 1;
            alpha = 1.0f;
            dispHeight = 0.1f;
            specularExponent = 8;

            List<byte> diff_pixels = new List<byte>(4 * 1 * 1);
            List<byte> spec_pixels = new List<byte>(4 * 1 * 1);
            List<byte> norm_pixels = new List<byte>(4 * 1 * 1);
            List<byte> para_pixels = new List<byte>(4 * 1 * 1);
            List<byte> ambi_pixels = new List<byte>(4 * 1 * 1);

            diff_pixels.Add(255);
            diff_pixels.Add(255);
            diff_pixels.Add(255);
            diff_pixels.Add(255);

            diffWidth = 1;
            diffHeight = 1;

            spec_pixels.Add(255);
            spec_pixels.Add(255);
            spec_pixels.Add(255);
            spec_pixels.Add(255);

            specWidth = 1;
            specHeight = 1;

            norm_pixels.Add(255);
            norm_pixels.Add(255);
            norm_pixels.Add(255);
            norm_pixels.Add(255);

            normWidth = 1;
            normHeight = 1;

            para_pixels.Add(0);
            para_pixels.Add(0);
            para_pixels.Add(0);
            para_pixels.Add(0);

            paraWidth = 1;
            paraHeight = 1;

            ambi_pixels.Add(255);
            ambi_pixels.Add(255);
            ambi_pixels.Add(255);
            ambi_pixels.Add(255);

            ambiWidth = 1;
            ambiHeight = 1;

            diffData = diff_pixels.ToArray();
            specData = spec_pixels.ToArray();
            normData = norm_pixels.ToArray();
            paraData = norm_pixels.ToArray();
            ambiData = norm_pixels.ToArray();
        }

        public void loadTexture(String diff = "", String spec = "", String norm = "", String para = "" , String ambi = "")
        {
            List<byte> diff_pixels;
            if (diff == "")
            {
                diff_pixels = new List<byte>(4 * 1 * 1);
                diff_pixels.Add(255);
                diff_pixels.Add(255);
                diff_pixels.Add(255);
                diff_pixels.Add(255);
                diffWidth = 1;
                diffHeight = 1;
            }
            else
            {
                Image<Rgba32> image = Image.Load<Rgba32>(diff);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                diff_pixels = new List<byte>(4 * image.Width * image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    var row = image.GetPixelRowSpan(y);

                    for (int x = 0; x < image.Width; x++)
                    {
                        diff_pixels.Add(row[x].R);
                        diff_pixels.Add(row[x].G);
                        diff_pixels.Add(row[x].B);
                        diff_pixels.Add(row[x].A);
                    }
                }
                diffWidth = image.Width;
                diffHeight = image.Height;
            }
            diffData = diff_pixels.ToArray();

            List<byte> spec_pixels;
            if (spec == "")
            {
                spec_pixels = new List<byte>(4 * 1 * 1);
                spec_pixels.Add(255);
                spec_pixels.Add(255);
                spec_pixels.Add(255);
                spec_pixels.Add(255);
                specWidth = 1;
                specHeight = 1;
            }
            else
            {
                Image<Rgba32> image = Image.Load<Rgba32>(spec);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                spec_pixels = new List<byte>(4 * image.Width * image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    var row = image.GetPixelRowSpan(y);

                    for (int x = 0; x < image.Width; x++)
                    {
                        spec_pixels.Add(row[x].R);
                        spec_pixels.Add(row[x].G);
                        spec_pixels.Add(row[x].B);
                        spec_pixels.Add(row[x].A);
                    }
                }
                specWidth = image.Width;
                specHeight = image.Height;
            }
            specData = spec_pixels.ToArray();

            List<byte> norm_pixels;
            if (norm == "")
            {
                norm_pixels = new List<byte>(4 * 1 * 1);
                norm_pixels.Add(255);
                norm_pixels.Add(255);
                norm_pixels.Add(255);
                norm_pixels.Add(255);
                normWidth = 1;
                normHeight = 1;
            }
            else
            {
                Image<Rgba32> image = Image.Load<Rgba32>(norm);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                norm_pixels = new List<byte>(4 * image.Width * image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    var row = image.GetPixelRowSpan(y);

                    for (int x = 0; x < image.Width; x++)
                    {
                        norm_pixels.Add(row[x].R);
                        norm_pixels.Add(row[x].G);
                        norm_pixels.Add(row[x].B);
                        norm_pixels.Add(row[x].A);
                    }
                }
                normWidth = image.Width;
                normHeight = image.Height;
            }
            normData = norm_pixels.ToArray();

            List<byte> para_pixels;
            if (para == "")
            {
                para_pixels = new List<byte>(4 * 1 * 1);
                para_pixels.Add(0);
                para_pixels.Add(0);
                para_pixels.Add(0);
                para_pixels.Add(0);
                paraWidth = 1;
                paraHeight = 1;
            }
            else
            {
                Image<Rgba32> image = Image.Load<Rgba32>(para);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                para_pixels = new List<byte>(4 * image.Width * image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    var row = image.GetPixelRowSpan(y);

                    for (int x = 0; x < image.Width; x++)
                    {
                        para_pixels.Add(row[x].R);
                        para_pixels.Add(row[x].G);
                        para_pixels.Add(row[x].B);
                        para_pixels.Add(row[x].A);
                    }
                }
                paraWidth = image.Width;
                paraHeight = image.Height;
            }
            paraData = para_pixels.ToArray();

            List<byte> ambi_pixels;
            if (ambi == "")
            {
                ambi_pixels = new List<byte>(4 * 1 * 1);
                ambi_pixels.Add(255);
                ambi_pixels.Add(255);
                ambi_pixels.Add(255);
                ambi_pixels.Add(255);
                ambiWidth = 1;
                ambiHeight = 1;
            }
            else
            {
                Image<Rgba32> image = Image.Load<Rgba32>(ambi);
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                ambi_pixels = new List<byte>(4 * image.Width * image.Height);
                for (int y = 0; y < image.Height; y++)
                {
                    var row = image.GetPixelRowSpan(y);

                    for (int x = 0; x < image.Width; x++)
                    {
                        ambi_pixels.Add(row[x].R);
                        ambi_pixels.Add(row[x].G);
                        ambi_pixels.Add(row[x].B);
                        ambi_pixels.Add(row[x].A);
                    }
                }
                ambiWidth = image.Width;
                ambiHeight = image.Height;
            }
            ambiData = ambi_pixels.ToArray();
        }
    }

}
