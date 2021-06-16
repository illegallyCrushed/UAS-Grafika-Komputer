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

namespace UAS
{
    class Scene
    {

        public static Shader Shader_NoMap;
        public static Shader Shader_Color;
        public static Shader Shader_Wireframe;
        public static Shader Shader_Depth;

        public static Object scene;
        public static Object lightSphere;

        public static List<ImageStore> TextureLibrary = new List<ImageStore>();

        public static Matrix4 ProjectionMatrix;
        public static Matrix4 ViewMatrix;
        public static Vector3 ViewPosition = new Vector3(20, 3, 0);
        public static Vector3 ViewTo = new Vector3(0, 0, 0);
        public static Vector3 ViewUpwards = new Vector3(0, 1, 0);
        public static Vector3 WireframeColor = new Vector3(0,0,0);
        public static Vector3 SkyColor = new Vector3(0.529f, 0.808f, 0.922f);
        //public static Vector3 SkyColor = new Vector3(0, 0, 0);
        public static Vector2i WindowSize;
        public static float LightFarPlane = 100.0f;
        public static float FOV = 45.0f;
        public static float RotateVelocityX = 0;
        public static float RotateVelocityY = 0;
        public static float RotateVelocityZ = 0;
        public static bool ShowLightBall = false;
        public static bool Wireframe = false;
        public static bool Solids = true;
        public static int LightMode = 3;

        public static int depthMapFBO;
        public static int depthMap;

        public static List<Matrix4> LightSpaceMatrix = new List<Matrix4>();
        public static Matrix4 LightProjectionMatrix;
        public static Vector3 LightPosition = new Vector3(10,10,0);
        public static Vector3 LightColor = new Vector3(0.75f,0.75f,0.75f);
        public static void SetScene(Vector2i Size)
        {
            if (Window.ENABLE_SHADOW)
            {
                depthMap = GL.GenTexture();
                GL.BindTexture(TextureTarget.TextureCubeMap, depthMap);
                for (int i = 0; i < 6; ++i)
                    GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, PixelInternalFormat.DepthComponent, Window.SHADOW_RESOLUTION, Window.SHADOW_RESOLUTION, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);

                GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
                GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
                GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (float)TextureWrapMode.ClampToEdge);
                GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (float)TextureWrapMode.ClampToEdge);
                GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (float)TextureWrapMode.ClampToEdge);

                depthMapFBO = GL.GenFramebuffer();

                GL.BindFramebuffer(FramebufferTarget.Framebuffer, depthMapFBO);
                GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, depthMap, 0);
                GL.DrawBuffer(DrawBufferMode.None);
                GL.ReadBuffer(ReadBufferMode.None);
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            }

            WindowSize = Size;

            Shader_NoMap = new Shader("../../../Shaders/shader_nomap.vert", "../../../Shaders/shader_nomap.frag");
            Shader_Color = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");
            Shader_Wireframe = new Shader("../../../Shaders/shader_line.vert", "../../../Shaders/shader_line.frag");
            Shader_Depth = new Shader("../../../Shaders/shader_depth.vert", "../../../Shaders/shader_depth.frag", "../../../Shaders/shader_depth.geom");

            LightProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(90f.Rad(), (float)WindowSize.X / (float)WindowSize.Y, 1f, LightFarPlane);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(-1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 1, 0), new Vector3(0, 0, 1)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, -1, 0), new Vector3(0, 0, -1)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 0, 1), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 0, -1), new Vector3(0, -1, 0)) * LightProjectionMatrix);


            scene = new Object("scene");

            
             //Leonando.Objects(ref scene);
             //Jeremy.Objects(ref scene);
             Nicholas.Objects(ref scene);


            //scene.translateZ(-8.8f);
            //scene.rotateZ(45f);
            scene.init();

            lightSphere = new Object("lightsphere");
            lightSphere.createCube();
            lightSphere.material.loadDiffuse("test.jpg");
            lightSphere.scale(1);
            lightSphere.setTranslate(LightPosition.X, -LightPosition.Z, LightPosition.Y);
            lightSphere.setColor(255, 245, 166);
            lightSphere.init();
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
            ProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(FOV.Rad(), (float)WindowSize.X / (float)WindowSize.Y, 0.1f, 100.0f);

            ViewMatrix = Matrix4.LookAt(ViewPosition, ViewTo, ViewUpwards);

            LightSpaceMatrix.Clear();
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(-1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 1, 0), new Vector3(0, 0, 1)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, -1, 0), new Vector3(0, 0, -1)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 0, 1), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            LightSpaceMatrix.Add(Matrix4.LookAt(LightPosition, LightPosition + new Vector3(0, 0, -1), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            lightSphere.setTranslate(LightPosition.X, -LightPosition.Z, LightPosition.Y);

            if (Window.ENABLE_SHADOW)
            {
                // get depth, 1st pass
                GL.Viewport(0, 0, Window.SHADOW_RESOLUTION, Window.SHADOW_RESOLUTION);
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, depthMapFBO);
                GL.Clear(ClearBufferMask.DepthBufferBit);
                scene.renderDepth();
                GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
                GL.Viewport(0, 0, WindowSize.X, WindowSize.Y);
                GL.ActiveTexture(TextureUnit.Texture0);
                GL.BindTexture(TextureTarget.TextureCubeMap, depthMap);
            }

            // render color, 2nd pass
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            scene.render();
            if(ShowLightBall)
                lightSphere.render();
        }

        public static void Movement(FrameEventArgs e, Window w)
        {

            float speed = 5;
            float reducespeed = 7.5f;
            float rotatesens = 0.5f;

            if (w.KeyboardState.IsKeyDown(Keys.W))
            {
                ViewPosition -= new Vector3(1, 0, 0) * speed * (float)e.Time;
                ViewTo -= new Vector3(1, 0, 0) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.S))
            {
                ViewPosition += new Vector3(1, 0, 0) * speed * (float)e.Time;
                ViewTo += new Vector3(1, 0, 0) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.A))
            {
                ViewPosition += new Vector3(0, 0, 1) * speed * (float)e.Time;
                ViewTo += new Vector3(0, 0, 1) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.D))
            {
                ViewPosition -= new Vector3(0, 0, 1) * speed * (float)e.Time;
                ViewTo -= new Vector3(0, 0, 1) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.LeftShift))
            {
                ViewPosition += new Vector3(0, 1, 0) * speed * (float)e.Time;
                ViewTo += new Vector3(0, 1, 0) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.LeftControl))
            {
                ViewPosition -= new Vector3(0, 1, 0) * speed * (float)e.Time;
                ViewTo -= new Vector3(0, 1, 0) * speed * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyReleased(Keys.R))
            {
                scene.setTranslate(0, 0, 0);
                scene.setRotation(0, 0, 0);
                scene.translateZ(-8.8f);
                scene.rotateZ(45f);

                ViewPosition = new Vector3(20, 3, 0);
                ViewTo = new Vector3(0, 0, 0);

                FOV = 45f;

                Console.WriteLine("Camera Reset");
            }

            if (w.KeyboardState.IsKeyDown(Keys.Up))
            {
                LightPosition -= new Vector3(1, 0, 0) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.Down))
            {
                LightPosition += new Vector3(1, 0, 0) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.Left))
            {
                LightPosition += new Vector3(0, 0, 1) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.Right))
            {
                LightPosition -= new Vector3(0, 0, 1) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.RightShift))
            {
                LightPosition += new Vector3(0, 1, 0) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyDown(Keys.RightControl))
            {
                LightPosition -= new Vector3(0, 1, 0) * speed*3 * (float)e.Time;
            }

            if (w.KeyboardState.IsKeyReleased(Keys.L))
            {

                LightPosition = new Vector3(10,10, 0);

                Console.WriteLine("Light Reset");
            }

            


            float deltaX = w.MouseState.Position.X - w.MouseState.PreviousPosition.X;
            float deltaY = w.MouseState.Position.Y - w.MouseState.PreviousPosition.Y;
            if (w.MouseState.IsButtonDown(MouseButton.Button3))
            {
                RotateVelocityZ = deltaX * (float)rotatesens;
            }
            else if (w.MouseState.IsButtonDown(MouseButton.Button2))
            {
                RotateVelocityY = deltaY * (float)rotatesens;

            }
            else if (w.MouseState.IsButtonDown(MouseButton.Button1))
            {
                RotateVelocityX = deltaX * (float)rotatesens;
            }
            RotateVelocityX -= (RotateVelocityX - 0) * reducespeed * (float)e.Time;
            RotateVelocityY -= (RotateVelocityY - 0) * reducespeed * (float)e.Time;
            RotateVelocityZ -= (RotateVelocityZ - 0) * reducespeed * (float)e.Time;
            scene.rotateY(RotateVelocityY);
            scene.rotateZ(RotateVelocityX);
            scene.rotateX(RotateVelocityZ);

            if (w.KeyboardState.IsKeyReleased(Keys.F11)) {
                if (!Window.ISFULLSCREEN)
                {
                    w.WindowBorder = WindowBorder.Hidden;
                    w.WindowState = WindowState.Fullscreen;
                    GL.Viewport(0, 0, w.Size.X, w.Size.Y);
                    WindowSize = w.Size;
                }
                else {

                    w.WindowBorder = WindowBorder.Resizable;
                    w.WindowState = WindowState.Normal;
                    GL.Viewport(0, 0, w.Size.X, w.Size.Y);
                    WindowSize = w.Size;
                }
                Window.ISFULLSCREEN = !Window.ISFULLSCREEN;
                Console.WriteLine("Toggle Fullscreen = " + Window.ISFULLSCREEN);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F10))
            {
                Window.ENABLE_SHADOW = !Window.ENABLE_SHADOW;
                Console.WriteLine("Toggle Shadow = " + Window.ENABLE_SHADOW);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F9))
            {
                ShowLightBall = !ShowLightBall;
                Console.WriteLine("Toggle LightBall = " + ShowLightBall);
            }

            if (w.KeyboardState.IsKeyReleased(Keys.F8))
            {
                Solids =! Solids;
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
                Console.WriteLine("LSHIFT - MOVE UP CAMERA");
                Console.WriteLine("LCTRL - MOVE DOWN CAMERA");
                Console.WriteLine("MOUSEWHEEL - ZOOM IN/OUT CAMERA");
                Console.WriteLine("R - RESET CAMERA");
                Console.WriteLine("");
                Console.WriteLine("LEFT MOUSE - HORIZONTAL SPIN");
                Console.WriteLine("RIGHT MOUSE - VERTICAL SPIN");
                Console.WriteLine("MIDDLE MOUSE - CIRCLE SPIN");
                Console.WriteLine("");
                Console.WriteLine("ARROW KEYS - MOVE LIGHT");
                Console.WriteLine("RSHIFT - MOVE UP LIGHT");
                Console.WriteLine("RCTRL - MOVE DOWN LIGHT");
                Console.WriteLine("L - RESET LIGHT");
                Console.WriteLine("");
                Console.WriteLine("F1 - SHOW HELP");
                Console.WriteLine("F7 - TOGGLE WIREFRAMES");
                Console.WriteLine("F8 - TOGGLE SOLIDS");
                Console.WriteLine("F9 - TOGGLE LIGHTBALL");
                Console.WriteLine("F10 - TOGGLE SHADOW");
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

