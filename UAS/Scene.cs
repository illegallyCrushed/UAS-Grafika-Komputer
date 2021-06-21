using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Graphics.OpenGL4;
using LearnOpenTK.Common;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;
using System.Linq;
using System.Windows;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using Image = SixLabors.ImageSharp.Image;
using SixLabors.ImageSharp.Processing;

namespace UAS
{
    class Scene
    {

        public static Shader Shader_NoMap;
        public static Shader Shader_Color;
        public static Shader Shader_PBR;
        public static Shader Shader_Flat;
        public static Shader Shader_DepthCube;
        public static Shader Shader_DepthPlane;
        public static Shader Shader_SkyBox;

        public static Object scene;

        public static List<ImageStore> TextureLibrary = new List<ImageStore>();
        public static List<Light> Lights = new List<Light>();

        public static Matrix4 ProjectionMatrix;
        public static Matrix4 ViewMatrix;
        public static Vector3 ViewPosition = new Vector3(0, 175, 0);
        public static Vector3 ViewTo = new Vector3(0, 0, -1);
        public static Vector3 ViewUpwards = new Vector3(0, 1, 0);
        public static float Pitch = 0;
        public static float Yaw = 180;
        public static Vector3 WireframeColor = new Vector3(0, 0, 0);
        public static Vector3 SkyColor = new Vector3(0.529f, 0.808f, 0.922f);
        //public static Vector3 SkyColor = new Vector3(0.1f,0.1f,0.1f);
        public static Vector2i WindowSize;
        public static float FOV = 45.0f;
        public static float RotateVelocityX = 0;
        public static float RotateVelocityY = 0;
        public static float RotateVelocityZ = 0;

        public static bool ShowLightBall = false;
        public static bool Wireframe = false;
        public static bool Solids = true;

        public static bool GlobalLighting = true;
        public static bool GlobalShadow = true;
        public static int MaxLight = 15;

        private static int _skyBoxVBO;
        private static int _skyBoxVAO;
        private static int _skyBoxMap;
        private static List<Vector3> skyBoxVerts = new List<Vector3>();

        public static void SetSkyBox(List<String> paths)
        {
            GL.BindTexture(TextureTarget.TextureCubeMap, _skyBoxMap);
            for (int i = 0; i < 6; i++)
            {
                List<byte> image_pixels;

                byte[] Data;
                int Width;
                int Height;

                Image<Rgba32> image = Image.Load<Rgba32>(paths[i]);
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

                GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, PixelInternalFormat.Rgba, Width, Height, 0, PixelFormat.Rgba, PixelType.UnsignedByte, Data);
            }
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (float)TextureWrapMode.ClampToEdge);
        }

        public static void RenderSkyBox()
        {
            GL.DepthFunc(DepthFunction.Lequal);
            Shader_SkyBox.Use();
            Matrix4 ViewMatrixNoScale= new  Matrix4(new  Matrix3(ViewMatrix));
            Shader_SkyBox.SetMatrix4("view", ViewMatrixNoScale);
            Shader_SkyBox.SetMatrix4("projection", ProjectionMatrix);
            Shader_SkyBox.SetInt("skybox", 0);
            GL.BindVertexArray(_skyBoxVAO);
            GL.ActiveTexture(TextureUnit.Texture0);
            GL.BindTexture(TextureTarget.TextureCubeMap, _skyBoxMap);
            GL.DrawArrays(PrimitiveType.Triangles, 0, skyBoxVerts.Count());
            GL.BindVertexArray(0);
            GL.DepthFunc(DepthFunction.Less);
        }

        public static void SetScene(Vector2i Size)
        {

            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, 1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, -1.0f));
            skyBoxVerts.Add(new Vector3(-1.0f, -1.0f, 1.0f));
            skyBoxVerts.Add(new Vector3(1.0f, -1.0f, 1.0f));
            _skyBoxMap = GL.GenTexture();

            _skyBoxVBO = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _skyBoxVBO);
            GL.BufferData<Vector3>(BufferTarget.ArrayBuffer,
                skyBoxVerts.Count * Vector3.SizeInBytes,
                skyBoxVerts.ToArray(),
                BufferUsageHint.StaticDraw);

            _skyBoxVAO = GL.GenVertexArray();
            GL.BindVertexArray(_skyBoxVAO);

            GL.BindBuffer(BufferTarget.ArrayBuffer, _skyBoxVBO);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            WindowSize = Size;

            Console.WriteLine("Init NoMap Shader");
            Shader_NoMap = new Shader("../../../Shaders/shader_nomap.vert", "../../../Shaders/shader_nomap.frag");
            Console.WriteLine("Init Color Shader");
            Shader_Color = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");
            Console.WriteLine("Init PBR Shader");
            Shader_PBR = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader_pbr.frag");
            Console.WriteLine("Init Flat Shader");
            Shader_Flat = new Shader("../../../Shaders/shader_flat.vert", "../../../Shaders/shader_flat.frag");
            Console.WriteLine("Init DepthCube Shader");
            Shader_DepthCube = new Shader("../../../Shaders/shader_depthcube.vert", "../../../Shaders/shader_depthcube.frag", "../../../Shaders/shader_depthcube.geom");
            Console.WriteLine("Init DepthPlane Shader");
            Shader_DepthPlane = new Shader("../../../Shaders/shader_depthplane.vert", "../../../Shaders/shader_depthplane.frag");
            Console.WriteLine("Init SkyBox Shader");
            Shader_SkyBox = new Shader("../../../Shaders/shader_skybox.vert", "../../../Shaders/shader_skybox.frag");

            List<String> faces = new List<String>();
            faces.Add("../../../Assets/skybox/night/right.jpg");
            faces.Add("../../../Assets/skybox/night/left.jpg");
            faces.Add("../../../Assets/skybox/night/top.jpg");
            faces.Add("../../../Assets/skybox/night/bottom.jpg");
            faces.Add("../../../Assets/skybox/night/front.jpg");
            faces.Add("../../../Assets/skybox/night/back.jpg");

            SetSkyBox(faces);

            scene = new Object("scene");


            //Leonando.Objects(ref scene);
            //Jeremy.Objects(ref scene);
            Nicholas.Objects(ref scene);


            //scene.translateZ(-8.8f);
            //scene.rotateZ(45f);
            scene.init();

        }

        public static void AnimateScene()
        {
            if (Window.PLAYANIMATION)
            {
                Leonando.Animations(ref scene);
                Jeremy.Animations(ref scene);
                Nicholas.Animations(ref scene);
            }
        }
        public static void RenderScene()
        {
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV.Rad(), (float)WindowSize.X / (float)WindowSize.Y, 1f, 5000.0f);

            ViewMatrix = Matrix4.LookAt(ViewPosition, ViewPosition + ViewTo, ViewUpwards);

            // refresh light animator
            foreach (var light in Scene.Lights)
            {
                light.refreshLightMatrix();
            }

            // get shadow, 1st pass
            if (GlobalShadow)
            {
                foreach (var light in Scene.Lights)
                {
                    if (light.castShadow == 1)
                    {
                        //Console.WriteLine(light.name);
                        light.calculateShadow(ref scene);
                    }
                }
            }

            // render color, 2nd pass
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            scene.render();
            if (ShowLightBall)
            {
                foreach (var light in Scene.Lights)
                {
                   
                   light.renderLightCube();
                }
            }

            // render skymap, 3st pass
            if (Scene.GlobalLighting) { 
                RenderSkyBox();
            }
        }

        public static void MouseMovement(MouseMoveEventArgs e, Window w)
        {

            float rotatesens = 0.05f;

            w.CursorVisible = false;

            float deltaX = w.Size.X / 2f - e.X;
            float deltaY = w.Size.Y / 2f - e.Y;
            Yaw += deltaX * rotatesens;
            if (Pitch > 89.0f)
            {
                Pitch = 89.0f;
            }
            else if (Pitch < -89.0f)
            {
                Pitch = -89.0f;
            }
            else
            {
                Pitch -= deltaY * rotatesens;
            }

            ViewTo.X = (float)Math.Cos(Pitch.Rad()) * (float)Math.Cos(Yaw.Rad());
            ViewTo.Y = (float)Math.Sin(Pitch.Rad());
            ViewTo.Z = (float)Math.Cos(Pitch.Rad()) * (float)Math.Sin(Yaw.Rad());
            ViewTo.Normalize();
            w.MousePosition = new Vector2(w.Size.X / 2f, w.Size.Y / 2f);
        }

        public static void Movement(FrameEventArgs e, Window w)
        {

            float speed = 100f;

            if (w.KeyboardState.IsKeyDown(Keys.W))
            {
                ViewPosition += ViewTo * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.S))
            {
                ViewPosition -= ViewTo * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.A))
            {
                ViewPosition -= Vector3.Normalize(Vector3.Cross(ViewTo, ViewUpwards)) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.D))
            {
                ViewPosition += Vector3.Normalize(Vector3.Cross(ViewTo, ViewUpwards)) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.Space))
            {
                ViewPosition += ViewUpwards * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                ViewPosition -= ViewUpwards * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyReleased(Keys.R))
            {
                ViewPosition = new Vector3(20, 0, 0);
                ViewTo = new Vector3(-1, 0, 0);
                Yaw = 180.0f;
                Pitch = 0.0f;
                FOV = 45f;
                Console.WriteLine("Camera Reset");
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F11))
            {
                if (!Window.ISFULLSCREEN)
                {
                    w.WindowBorder = WindowBorder.Hidden;
                    w.WindowState = WindowState.Fullscreen;
                    GL.Viewport(0, 0, w.Size.X, w.Size.Y);
                    WindowSize = w.Size;
                }
                else
                {

                    w.WindowBorder = WindowBorder.Resizable;
                    w.WindowState = WindowState.Normal;
                    GL.Viewport(0, 0, w.Size.X, w.Size.Y);
                    WindowSize = w.Size;
                }
                Window.ISFULLSCREEN = !Window.ISFULLSCREEN;
                Console.WriteLine("Toggle Fullscreen = " + Window.ISFULLSCREEN);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F5))
            {
                Scene.GlobalLighting = !Scene.GlobalLighting;
                Console.WriteLine("Toggle Lighting = " + Scene.GlobalLighting);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F6))
            {
                Scene.GlobalShadow = !Scene.GlobalShadow;
                Console.WriteLine("Toggle Shadow = " + Scene.GlobalShadow);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F9))
            {
                ShowLightBall = !ShowLightBall;
                Console.WriteLine("Toggle LightBall = " + ShowLightBall);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F8))
            {
                Solids = !Solids;
                Console.WriteLine("Toggle Solids = " + Solids);
            }
            if (w.KeyboardState.IsKeyReleased(Keys.F7))
            {
                Wireframe = !Wireframe;
                Console.WriteLine("Toggle Wireframes = " + Wireframe);
            }
            if (w.KeyboardState.IsKeyReleased(Keys.F1))
            {
                Console.WriteLine("\nControls:");
                Console.WriteLine("WASD - MOVE CAMERA");
                Console.WriteLine("SPACE - MOVE UP CAMERA");
                Console.WriteLine("LSHIFT - MOVE DOWN CAMERA");
                Console.WriteLine("MOUSEWHEEL - ZOOM IN/OUT CAMERA");
                Console.WriteLine("MOUSEMOVE - LOOK AROUND");
                Console.WriteLine("R - RESET CAMERA");
                Console.WriteLine("");
                Console.WriteLine("F1 - SHOW HELP");
                Console.WriteLine("F5 - TOGGLE LIGHTING");
                Console.WriteLine("F6 - TOGGLE SHADOW");
                Console.WriteLine("F7 - TOGGLE WIREFRAMES");
                Console.WriteLine("F8 - TOGGLE SOLIDS");
                Console.WriteLine("F9 - TOGGLE LIGHTBALL");
                Console.WriteLine("F11 - TOGGLE FULLSCREEN");
                Console.WriteLine("F12 - TOGGLE ANIMATIONS");
                Console.WriteLine("\nActions:");
            }
            if (w.KeyboardState.IsKeyReleased(Keys.F12))
            {
                Window.PLAYANIMATION = !Window.PLAYANIMATION;
                Console.WriteLine("Toggle Animations = " + Window.PLAYANIMATION);
            }
        }

        public static void Zoom(MouseWheelEventArgs e)
        {
            FOV -= e.Offset.Y * 2;

            if (FOV <= 1.0f)
            {
                FOV = 1.0f;
            }
            else if (FOV >= 179.0f)
            {
                FOV = 179.0f;
            }
        }
    }

}

