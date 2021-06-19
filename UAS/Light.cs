using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;

namespace UAS
{
    class Light
    {
        public static int Directional = 1;
        public static int Point = 2;
        public static int Spot = 3;

        // 1 = directional;
        // 2 = point;
        // 3 = specular;
        String name;

        public int lightType;

        // positional
        public Vector3 position;
        public Vector3 direction;

        // light color
        public Vector3 ambient;
        public Vector3 diffuse;
        public Vector3 specular;

        // spot light cone cutoff
        public float innerCutOff;
        public float outerCutOff;

        public float constant;
        public float linear;
        public float quadratic;
        public float farPlane;

        // cast shadow 0 : not
        public int castShadow;

        public int shadowMap;
        public int shadowMapFBO;

        public Object lightCube;
        public List<Matrix4> LightSpaceMatrix;
        public Matrix4 LightProjectionMatrix;

        public Light(String name)
        {
            this.name = name;
            lightType = 0;

            position = new Vector3(0, 0, 0);
            direction = new Vector3(0, -1, 0);

            ambient = new Vector3(1, 1, 1);
            diffuse = new Vector3(1, 1, 1);
            specular = new Vector3(1, 1, 1);

            innerCutOff = 0.91f;
            outerCutOff = 0.82f;

            constant = 1.0f;
            linear = 0.22f;
            quadratic = 0.20f;

            farPlane = 3000f;

            castShadow = 1;

            lightCube = new Object(name);
            lightCube.createCube();
            lightCube.scale(1);
            lightCube.setTranslate(0, 0, 0);
            lightCube.init();


            shadowMap = GL.GenTexture();
            GL.BindTexture(TextureTarget.TextureCubeMap, shadowMap);
            for (int i = 0; i < 6; ++i)
                GL.TexImage2D(TextureTarget.TextureCubeMapPositiveX + i, 0, PixelInternalFormat.DepthComponent, Window.SHADOW_RESOLUTION, Window.SHADOW_RESOLUTION, 0, PixelFormat.DepthComponent, PixelType.Float, IntPtr.Zero);

            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMinFilter, (float)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureMagFilter, (float)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapS, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapT, (float)TextureWrapMode.ClampToEdge);
            GL.TexParameter(TextureTarget.TextureCubeMap, TextureParameterName.TextureWrapR, (float)TextureWrapMode.ClampToEdge);

            shadowMapFBO = GL.GenFramebuffer();
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, shadowMapFBO);
            GL.FramebufferTexture(FramebufferTarget.Framebuffer, FramebufferAttachment.DepthAttachment, shadowMap, 0);
            GL.DrawBuffer(DrawBufferMode.None);
            GL.ReadBuffer(ReadBufferMode.None);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);

            LightSpaceMatrix = new List<Matrix4>();
        }

        public static Light FindLight(ref List<Light> lights, String name)
        {
            foreach (var light in lights)
            {
                if (light.name == name)
                    return light;
            }

            return null;
        }

        public static void GenerateDirectional(ref List<Light> lights, String name, Vector3 ambi, Vector3 diff, Vector3 spec, Vector3 dir, float posx = 0, float posy = 0, float posz = 0)
        {
            if (Light.FindLight(ref lights, name) != null)
            {
                Console.Write("Light -");
                Console.Write(name);
                Console.Write("- Exists!");
                return;
            }

            Light genlight = new Light(name);
            genlight.position = new Vector3(posx, posy, posz);
            genlight.lightType = Light.Directional;
            genlight.direction = dir;
            genlight.ambient = ambi;
            genlight.diffuse = diff;
            genlight.lightCube.material.diffuse = diff;
            genlight.specular = spec;
            genlight.castShadow = 0;
            lights.Add(genlight);
        }

        public static void GeneratePoint(ref List<Light> lights, String name, Vector3 ambi, Vector3 diff, Vector3 spec, Vector3 pos)
        {
            if (Light.FindLight(ref lights, name) != null)
            {
                Console.Write("Light -");
                Console.Write(name);
                Console.Write("- Exists!");
                return;
            }

            Light genlight = new Light(name);

            genlight.lightType = Light.Point;
            genlight.position = pos;
            genlight.ambient = ambi;
            genlight.diffuse = diff;
            genlight.lightCube.material.diffuse = diff;
            genlight.specular = spec;
            //genlight.constant = constant;
            //genlight.linear = linear;
            //genlight.quadratic = quadratic;
            lights.Add(genlight);
        }

        public static void GenerateSpot(ref List<Light> lights, String name, Vector3 ambi, Vector3 diff, Vector3 spec, Vector3 pos, Vector3 dir, float innerCutOff, float outerCutOff)
        {
            if (Light.FindLight(ref lights, name) != null)
            {
                Console.Write("Light -");
                Console.Write(name);
                Console.Write("- Exists!");
                return;
            }

            Light genlight = new Light(name);

            genlight.lightType = Light.Spot;
            genlight.position = pos;
            genlight.direction = dir;
            genlight.ambient = ambi;
            genlight.diffuse = diff;
            genlight.lightCube.material.diffuse = diff;
            genlight.specular = spec;
            //genlight.constant = constant;
            //genlight.linear = linear;
            //genlight.quadratic = quadratic;
            genlight.innerCutOff = innerCutOff;
            genlight.outerCutOff = outerCutOff;
            lights.Add(genlight);
        }

        public void calculateShadow(ref Object scene)
        {

            if (lightType == Light.Directional)
            {
                Matrix4.CreateOrthographicOffCenter(-10.0f, 10.0f, -10.0f, 10.0f, 0.01f, 100, out LightProjectionMatrix);
                Matrix4 lightView = Matrix4.LookAt(position, position + direction, new Vector3(0, 1, 0));
                LightSpaceMatrix.Clear();
                LightSpaceMatrix.Add(lightView * LightProjectionMatrix);
            }
            else
            {
                LightProjectionMatrix = Matrix4.CreatePerspectiveFieldOfView(90f.Rad(), (float)Scene.WindowSize.X / (float)Scene.WindowSize.Y, 1f, farPlane);
                LightSpaceMatrix.Clear();
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(-1, 0, 0), new Vector3(0, -1, 0)) * LightProjectionMatrix);
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(0, 1, 0), new Vector3(0, 0, 1)) * LightProjectionMatrix);
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(0, -1, 0), new Vector3(0, 0, -1)) * LightProjectionMatrix);
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(0, 0, 1), new Vector3(0, -1, 0)) * LightProjectionMatrix);
                LightSpaceMatrix.Add(Matrix4.LookAt(position, position + new Vector3(0, 0, -1), new Vector3(0, -1, 0)) * LightProjectionMatrix);
            }

            GL.Viewport(0, 0, Window.SHADOW_RESOLUTION, Window.SHADOW_RESOLUTION);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, shadowMapFBO);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            scene.renderDepth(this);
            GL.BindFramebuffer(FramebufferTarget.Framebuffer, 0);
            GL.Viewport(0, 0, Scene.WindowSize.X, Scene.WindowSize.Y);
        }

        public void renderLightCube()
        {
            Matrix4 transform = Matrix4.CreateTranslation(position);
            //Console.WriteLine("##");
            //Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", transform.M11, transform.M12, transform.M13, transform.M14));
            //Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", transform.M21, transform.M22, transform.M23, transform.M24));
            //Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", transform.M31, transform.M32, transform.M33, transform.M34));
            //Console.WriteLine(String.Format("{0}, {1}, {2}, {3}", transform.M41, transform.M42, transform.M43, transform.M44));
            //Console.WriteLine();
            //Console.WriteLine(String.Format("Rendering LightCube: {0}", name));
            //Console.WriteLine(String.Format("Position: {0}, {1}, {2}", position.X, position.Y, position.Z));
            //Console.WriteLine(String.Format("Direction: {0}, {1}, {2}", direction.X,direction.Y,direction.Z));
            //Console.WriteLine(String.Format("ExtractedPosition: {0}, {1}, {2}", extract.X, extract.Y, extract.Z));
            //Console.WriteLine("##-");
            //Console.WriteLine("##-");
            //transform.Transpose();
            lightCube.setTransform(transform);
            lightCube.render(true);
            lightCube.restoreTransform();
        }
    }
}
