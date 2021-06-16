using System;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Desktop;

namespace UAS
{
    class Program
    {
        static void Main(string[] args)
        {
            var ourWindow = new NativeWindowSettings()
            {
                Size = new Vector2i(1000, 1000),
                Title = "Proyek UAS - Shaun the Sheep",
                NumberOfSamples = Window.MULTISAMPLING_LEVEL
            };

            using (var win = new Window(GameWindowSettings.Default, ourWindow))
            {
                win.Run();
            };
        }
    }
}
