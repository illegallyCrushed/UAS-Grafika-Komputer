using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Mathematics;

namespace UAS
{
    class Leonando
    {
        public static Animator KepalaAnjingScale = new Animator();
        public static Animator GoyangBuntutScale = new Animator();
        public static void Objects(ref Object scene)
        {
            //scene.addChild(new Object("Bitzer"));

            //{ // Children of 'Bitzer'

            //    scene.lastChild().addChild(new Object("Badan"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.72260f, 0.72260f, 1.82260f);
            //    scene.lastChild().lastChild().rotateQ(0.70711f, 0.00000f, 0.70711f, 0.00000f);
            //    scene.lastChild().lastChild().translate(-0.11785f, 0.37402f, 0.05395f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("JariBelakangKanan"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.37090f, 0.21291f, 0.11286f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //    scene.lastChild().lastChild().translate(-1.39000f, -0.24000f, -1.99104f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("JariBelakangKiri"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.37090f, 0.21291f, 0.11286f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //    scene.lastChild().lastChild().translate(-1.44000f, 0.86000f, -1.99104f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("JariDepanKanan"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.37090f, 0.21291f, 0.11286f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //    scene.lastChild().lastChild().translate(1.34000f, -0.05000f, -1.99104f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("JariDepanKiri"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.37090f, 0.21291f, 0.11286f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //    scene.lastChild().lastChild().translate(1.34000f, 0.86000f, -1.99104f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("KakiBelakangKanan"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.19737f, 0.19737f, 0.76975f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(-1.47875f, -0.12718f, -1.07360f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("KakiBelakangKiri"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.19737f, 0.19737f, 0.76975f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(-1.52687f, 0.85691f, -1.04578f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("KakiDepanKanan"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.19737f, 0.19737f, 0.76975f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(1.17244f, -0.07727f, -1.13042f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("KakiDepanKiri"));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(0.19737f, 0.19737f, 0.76975f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(1.20996f, 0.85619f, -1.13076f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("Leher."));
            //    scene.lastChild().lastChild().createCylinder();
            //    scene.lastChild().lastChild().scale(-0.37330f, -0.37330f, -0.75330f);
            //    scene.lastChild().lastChild().rotateQ(-0.00000f, 0.00000f, 0.00000f, 1.00000f);
            //    scene.lastChild().lastChild().translate(1.45128f, 0.38019f, 1.15430f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("PantatKanan"));
            //    scene.lastChild().lastChild().createBall(0.5f);
            //    scene.lastChild().lastChild().scale(0.59000f, 0.68000f, 0.66000f);
            //    scene.lastChild().lastChild().rotateQ(0.70425f, -0.06347f, -0.06347f, -0.70425f);
            //    scene.lastChild().lastChild().translate(-1.71568f, 0.16234f, 0.06764f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("PantatKiri"));
            //    scene.lastChild().lastChild().createBall(0.5f);
            //    scene.lastChild().lastChild().scale(0.59000f, 0.68000f, 0.66000f);
            //    scene.lastChild().lastChild().rotateQ(0.70425f, -0.06347f, -0.06347f, -0.70425f);
            //    scene.lastChild().lastChild().translate(-1.71568f, 0.60234f, 0.05764f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("BuntutPusat"));

            //    { // Children of 'BuntutPusat'

            //        scene.lastChild().lastChild().addChild(new Object("EkorLengkung"));
            //        scene.lastChild().lastChild().lastChild().createFreeformTube(new List<Vector2> {
            //                                                    new Vector2(-1.80755f, -0.98517f),
            //                                                    new Vector2(-1.66045f, -0.82033f),
            //                                                    new Vector2(-1.48165f, -0.71185f),
            //                                                    new Vector2(-1.28969f, -0.67060f),
            //                                                    new Vector2(-1.10305f, -0.70741f),
            //                                                    new Vector2(-0.94028f, -0.83312f),
            //                                                    new Vector2(-0.80743f, -1.10283f),
            //                                                    new Vector2(-0.73521f, -1.43205f),
            //                                                    new Vector2(-0.66919f, -1.75419f),
            //                                                    new Vector2(-0.55495f, -2.00264f),
            //                                                    new Vector2(-0.33807f, -2.11081f),
            //                                                    new Vector2(0.17896f, -1.93905f),
            //                                                    new Vector2(0.47532f, -1.43880f),
            //                                                    new Vector2(0.63550f, -0.74143f),
            //                                                    new Vector2(0.74398f, 0.02171f),
            //                                                    new Vector2(0.88525f, 0.71925f),
            //                                                    new Vector2(1.06257f, 0.99636f),
            //                                                    new Vector2(1.38102f, 1.26436f),
            //                                                    new Vector2(1.75946f, 1.47754f),
            //                                                    new Vector2(2.11679f, 1.59022f),
            //                                                    new Vector2(2.37188f, 1.55669f),
            //                                    });
            //        scene.lastChild().lastChild().lastChild().scale(0.21116f, 0.21116f, 0.21116f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.15425f, -0.15425f, -0.69008f, -0.69008f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.28384f, -0.05000f, 0.57896f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    } // Children of 'BuntutPusat'

            //    scene.lastChild().lastChild().scale(1.00000f, 1.00000f, 1.00000f);
            //    scene.lastChild().lastChild().rotateQ(0.99854f, 0.05408f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(-2.03616f, 0.45000f, 0.60000f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(1.0f, 1.0f, 0.0f);

            //    scene.lastChild().addChild(new Object("KepalaAnjing"));

            //    { // Children of 'KepalaAnjing'

            //        scene.lastChild().lastChild().addChild(new Object("Kumis"));
            //        scene.lastChild().lastChild().lastChild().createFreeformTube(new List<Vector2> {
            //                                                    new Vector2(-4.10252f, -1.10510f),
            //                                                    new Vector2(-3.96997f, -1.35472f),
            //                                                    new Vector2(-3.63807f, -1.58429f),
            //                                                    new Vector2(-3.20549f, -1.75488f),
            //                                                    new Vector2(-2.77087f, -1.82761f),
            //                                                    new Vector2(-2.43286f, -1.76356f),
            //                                                    new Vector2(-2.10398f, -1.49187f),
            //                                                    new Vector2(-1.93332f, -1.18185f),
            //                                                    new Vector2(-1.82638f, -0.84463f),
            //                                                    new Vector2(-1.68866f, -0.49130f),
            //                                                    new Vector2(-1.42569f, -0.13298f),
            //                                                    new Vector2(-1.16385f, 0.03774f),
            //                                                    new Vector2(-0.86970f, 0.08804f),
            //                                                    new Vector2(-0.57907f, 0.02631f),
            //                                                    new Vector2(-0.32781f, -0.13903f),
            //                                                    new Vector2(-0.15177f, -0.39961f),
            //                                                    new Vector2(0.00710f, -0.51349f),
            //                                                    new Vector2(0.21059f, -0.31534f),
            //                                                    new Vector2(0.45692f, 0.01971f),
            //                                                    new Vector2(0.74434f, 0.31652f),
            //                                                    new Vector2(1.07109f, 0.39995f),
            //                                                    new Vector2(1.51746f, 0.11590f),
            //                                                    new Vector2(1.83045f, -0.38407f),
            //                                                    new Vector2(2.09897f, -0.95601f),
            //                                                    new Vector2(2.41196f, -1.45598f),
            //                                                    new Vector2(2.85833f, -1.74004f),
            //                                                    new Vector2(3.20083f, -1.70400f),
            //                                                    new Vector2(3.53665f, -1.50595f),
            //                                                    new Vector2(3.82352f, -1.24597f),
            //                                                    new Vector2(4.01912f, -1.02413f),
            //                                                    new Vector2(4.08118f, -0.94048f),
            //                                    }, 1f, 0.1f);
            //        scene.lastChild().lastChild().lastChild().scale(0.10553f, 0.16553f, 0.20553f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.50000f, 0.50000f, 0.50000f, 0.50000f);
            //        scene.lastChild().lastChild().lastChild().translate(0.68000f, -0.03000f, 0.84000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.00000f, 0.00000f, 0.00000f);

            //        scene.lastChild().lastChild().addChild(new Object("Kepala"));
            //        scene.lastChild().lastChild().lastChild().createCylinder();
            //        scene.lastChild().lastChild().lastChild().scale(0.56409f, 0.56409f, 0.66713f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.06000f, -0.00000f, 0.73000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //        scene.lastChild().lastChild().addChild(new Object("Lidah"));
            //        scene.lastChild().lastChild().lastChild().createCylinder();
            //        scene.lastChild().lastChild().lastChild().scale(0.37987f, 0.18635f, 0.06451f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.96858f, 0.00000f, 0.24869f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(0.66000f, -0.03000f, -0.19000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.80000f, 0.04368f, 0.06054f);

            //        scene.lastChild().lastChild().addChild(new Object("MoncongHidung"));
            //        scene.lastChild().lastChild().lastChild().createCylinder();
            //        scene.lastChild().lastChild().lastChild().scale(0.45129f, 0.45129f, 0.39890f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, -0.00000f, -0.70711f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(0.55000f, -0.00000f, 0.38000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //        scene.lastChild().lastChild().addChild(new Object("MulutAtas"));
            //        scene.lastChild().lastChild().lastChild().createCylinder();
            //        scene.lastChild().lastChild().lastChild().scale(0.82405f, 0.70405f, 0.09732f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(1.00000f, -0.00000f, -0.00000f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(0.07000f, -0.00000f, -0.01000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //        scene.lastChild().lastChild().addChild(new Object("MulutBawah"));
            //        scene.lastChild().lastChild().lastChild().createCylinder();
            //        scene.lastChild().lastChild().lastChild().scale(0.64392f, 0.64392f, 0.07605f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(1.00000f, 0.00000f, -0.00000f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(0.04000f, -0.00000f, -0.21000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //        scene.lastChild().lastChild().addChild(new Object("HidungDepan"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.42832f, 0.42832f, 0.42832f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, 0.00000f, -0.00000f, 0.70711f);
            //        scene.lastChild().lastChild().lastChild().translate(0.90840f, -0.00711f, 0.38484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //        scene.lastChild().lastChild().addChild(new Object("MataKanan"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.07312f, 0.09312f, 0.09312f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, 0.00000f, 0.00000f, 0.70711f);
            //        scene.lastChild().lastChild().lastChild().translate(0.47840f, -0.10711f, 0.99484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(1.00000f, 1.00000f, 1.00000f);

            //        scene.lastChild().lastChild().addChild(new Object("MataKiri"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.07312f, 0.09312f, 0.09312f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, -0.00000f, 0.00000f, 0.70711f);
            //        scene.lastChild().lastChild().lastChild().translate(0.47840f, 0.09289f, 0.99484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(1.00000f, 1.00000f, 1.00000f);

            //        scene.lastChild().lastChild().addChild(new Object("PupilKanan"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.03591f, 0.02573f, 0.04573f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, -0.00000f, 0.00000f, 0.70711f);
            //        scene.lastChild().lastChild().lastChild().translate(0.55840f, -0.10711f, 0.99484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.00000f, 0.00000f, 0.00000f);

            //        scene.lastChild().lastChild().addChild(new Object("PupilKiri"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.03591f, 0.02573f, 0.04573f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.70711f, -0.00000f, 0.00000f, 0.70711f);
            //        scene.lastChild().lastChild().lastChild().translate(0.55840f, 0.09289f, 0.99484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.00000f, 0.00000f, 0.00000f);

            //        scene.lastChild().lastChild().addChild(new Object("TopiAtas"));
            //        scene.lastChild().lastChild().lastChild().createBall(0.5f);
            //        scene.lastChild().lastChild().lastChild().scale(0.51187f, 0.51187f, 0.51187f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.50000f, -0.50000f, -0.50000f, 0.50000f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.04160f, -0.00711f, 1.34484f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.07451f, 0.32157f, 0.50588f);

            //        scene.lastChild().lastChild().addChild(new Object("OffsetTelingaKanan"));

            //        { // Children of 'OffsetTelingaKanan'

            //            scene.lastChild().lastChild().lastChild().addChild(new Object("TelingaKanan"));
            //            scene.lastChild().lastChild().lastChild().lastChild().createCube();
            //            scene.lastChild().lastChild().lastChild().lastChild().scale(0.13734f, 0.02943f, 0.10791f);
            //            scene.lastChild().lastChild().lastChild().lastChild().rotateQ(0.70049f, -0.05254f, 0.07157f, -0.70812f);
            //            scene.lastChild().lastChild().lastChild().lastChild().translate(0.01004f, 0.00223f, -0.10009f);
            //            scene.lastChild().lastChild().lastChild().lastChild().centerOrigin();
            //            scene.lastChild().lastChild().lastChild().lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //        } // Children of 'OffsetTelingaKanan'

            //        scene.lastChild().lastChild().lastChild().scale(2.03873f, 2.03873f, 2.03873f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.66005f, -0.23599f, 0.23372f, 0.67381f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.09048f, -0.56029f, 0.91418f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(1.0f, 1.0f, 0.0f);

            //        scene.lastChild().lastChild().addChild(new Object("OffsetTelingaKiri"));

            //        { // Children of 'OffsetTelingaKiri'

            //            scene.lastChild().lastChild().lastChild().addChild(new Object("TelingaKiri"));
            //            scene.lastChild().lastChild().lastChild().lastChild().createCube();
            //            scene.lastChild().lastChild().lastChild().lastChild().scale(0.13734f, 0.02943f, 0.10791f);
            //            scene.lastChild().lastChild().lastChild().lastChild().rotateQ(0.67172f, 0.20550f, -0.19055f, -0.68575f);
            //            scene.lastChild().lastChild().lastChild().lastChild().translate(0.03964f, 0.00199f, -0.09762f);
            //            scene.lastChild().lastChild().lastChild().lastChild().centerOrigin();
            //            scene.lastChild().lastChild().lastChild().lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //        } // Children of 'OffsetTelingaKiri'

            //        scene.lastChild().lastChild().lastChild().scale(2.03873f, 2.03873f, 2.03873f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(0.69923f, 0.07736f, -0.08779f, 0.70526f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.09003f, 0.52952f, 0.92100f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(1.0f, 1.0f, 0.0f);

            //        scene.lastChild().lastChild().addChild(new Object("TopiTepi"));
            //        scene.lastChild().lastChild().lastChild().createTorus();
            //        scene.lastChild().lastChild().lastChild().scale(0.56735f, 0.56735f, 0.56735f);
            //        scene.lastChild().lastChild().lastChild().rotateQ(1.00000f, -0.00000f, 0.00000f, -0.00000f);
            //        scene.lastChild().lastChild().lastChild().translate(-0.02000f, -0.00000f, 1.29000f);
            //        scene.lastChild().lastChild().lastChild().centerOrigin();
            //        scene.lastChild().lastChild().lastChild().setColor(0.07451f, 0.32157f, 0.50588f);

            //    } // Children of 'KepalaAnjing'

            //    scene.lastChild().lastChild().scale(1.00000f, 1.00000f, 1.00000f);
            //    scene.lastChild().lastChild().rotateQ(0.99990f, 0.00141f, 0.00838f, 0.01134f);
            //    scene.lastChild().lastChild().translate(1.70000f, 0.37000f, 1.59896f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(1.0f, 1.0f, 0.0f);

            //    scene.lastChild().addChild(new Object("BadanBelakang"));
            //    scene.lastChild().lastChild().createBall();
            //    scene.lastChild().lastChild().scale(1.51000f, 0.78000f, 0.99000f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(-0.75536f, 0.39542f, 0.04211f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("BadanDepan"));
            //    scene.lastChild().lastChild().createBall();
            //    scene.lastChild().lastChild().scale(1.28000f, 0.84000f, 0.93000f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, -0.00000f);
            //    scene.lastChild().lastChild().translate(0.79464f, 0.35542f, 0.04211f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.98824f, 0.72157f, 0.16078f);

            //    scene.lastChild().addChild(new Object("Aksesoris"));
            //    scene.lastChild().lastChild().createTorus(1f, 0.4f);
            //    scene.lastChild().lastChild().scale(0.36307f, 0.47716f, 0.56921f);
            //    scene.lastChild().lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //    scene.lastChild().lastChild().translate(1.46000f, 0.36000f, 1.00896f);
            //    scene.lastChild().lastChild().centerOrigin();
            //    scene.lastChild().lastChild().setColor(0.00000f, 0.00000f, 0.00000f);

            //} // Children of 'Bitzer'

            //scene.lastChild().scale(0.49050f, 0.49050f, 0.49050f);
            //scene.lastChild().rotateQ(0.88343f, 0.00000f, 0.00000f, -0.46856f);
            //scene.lastChild().translate(0.07049f, -6.52194f, 0.99904f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(1.0f, 1.0f, 0.0f);

            //scene.addChild(new Object("Pagar.001"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-9.13333f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.002"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-7.82372f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.003"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-9.13333f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.004"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(-9.13333f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.005"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(-9.13333f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.006"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(-9.13333f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.017"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-10.36973f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.013"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-6.59502f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.012"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-5.28541f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.011"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-6.59502f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.010"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(-6.59502f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.009"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(-6.59502f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.008"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(-6.59502f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.007"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-7.83142f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.021"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-5.26539f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.020"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(-4.02899f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.019"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(-4.02899f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.018"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(-4.02899f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.016"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-4.02899f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.015"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-2.71938f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.014"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-4.02899f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.028"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-1.45820f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.027"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-0.14859f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.026"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(-1.45820f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.025"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(-1.45820f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.024"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(-1.45820f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.023"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(-1.45820f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.022"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-2.69460f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.035"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(-0.17577f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.034"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(1.06063f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.033"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(1.06063f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.032"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(1.06063f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.031"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(1.06063f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.030"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(2.37024f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.029"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(1.06063f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.042"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(3.62209f, -9.47051f, 0.18632f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.041"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(4.93170f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.040"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.50000f, 0.50000f, -0.50000f, -0.50000f);
            //scene.lastChild().translate(3.62209f, -9.47051f, 1.25914f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.039"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.27060f, 0.65328f, -0.27060f, -0.65328f);
            //scene.lastChild().translate(3.62209f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.038"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, -0.40558f, 0.40558f, -0.57923f);
            //scene.lastChild().translate(3.62209f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.037"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.57923f, 0.40558f, -0.40558f, -0.57923f);
            //scene.lastChild().translate(3.62209f, -9.47051f, 0.68441f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.036"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(2.38569f, -9.47051f, 0.80894f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.09473f, 0.09473f, 0.61535f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, -0.00000f, -0.50000f);
            //scene.lastChild().translate(7.76629f, -6.69530f, 0.66515f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.058"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.08667f, 0.61237f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(6.96346f, -7.49813f, 0.79783f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.057"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.09473f, 0.09473f, 0.62402f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, -0.00000f, -0.50000f);
            //scene.lastChild().translate(6.56511f, -7.89648f, 0.20587f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.056"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.09473f, 0.09473f, 0.61535f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, -0.00000f, -0.50000f);
            //scene.lastChild().translate(6.57124f, -7.89035f, 0.66515f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.055"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.10206f, 1.42138f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(7.13505f, -7.32653f, 1.27751f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.054"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.08667f, 1.02061f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(8.12174f, -6.33985f, 0.79783f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.053"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.10206f, 0.39868f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(7.16570f, -7.29589f, 0.70597f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.052"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.08667f, 0.61237f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, -0.38268f);
            //scene.lastChild().translate(7.38632f, -7.07527f, 0.79783f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.051"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.09473f, 0.09473f, 0.62402f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, -0.00000f, -0.50000f);
            //scene.lastChild().translate(7.76016f, -6.70143f, 0.22628f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.050"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08667f, 0.08667f, 1.02061f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(6.20353f, -8.25806f, 0.79783f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.065"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09604f, 0.83325f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(5.63262f, -8.80985f, 0.16333f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.064"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.07076f, 0.07076f, 0.96043f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(6.21103f, -8.23144f, 0.78761f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.063"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09604f, 0.83325f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(5.63262f, -8.80985f, 1.23901f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.062"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08914f, 0.08914f, 0.83325f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, 0.00000f, -0.50000f);
            //scene.lastChild().translate(5.63262f, -8.80985f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.061"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09235f, 0.94825f);
            //scene.lastChild().rotateQ(0.75680f, -0.52992f, 0.21950f, -0.31348f);
            //scene.lastChild().translate(5.63262f, -8.80985f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.060"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09235f, 0.94825f);
            //scene.lastChild().rotateQ(0.75680f, 0.52992f, -0.21950f, -0.31348f);
            //scene.lastChild().translate(5.63262f, -8.80985f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.059"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.07076f, 0.07076f, 0.96043f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(5.08653f, -9.35593f, 0.78761f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.072"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.07076f, 0.07076f, 0.96043f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(8.13944f, -6.30303f, 0.78761f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.071"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09235f, 0.94825f);
            //scene.lastChild().rotateQ(0.75680f, 0.52992f, -0.21950f, -0.31348f);
            //scene.lastChild().translate(8.68552f, -5.75695f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.070"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09235f, 0.94825f);
            //scene.lastChild().rotateQ(0.75680f, -0.52992f, 0.21950f, -0.31348f);
            //scene.lastChild().translate(8.68552f, -5.75695f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.069"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08914f, 0.08914f, 0.83325f);
            //scene.lastChild().rotateQ(0.50000f, 0.70711f, 0.00000f, -0.50000f);
            //scene.lastChild().translate(8.68552f, -5.75695f, 0.66276f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.068"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09604f, 0.83325f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(8.68552f, -5.75695f, 1.23901f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.067"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.07076f, 0.07076f, 0.96043f);
            //scene.lastChild().rotateQ(1.00000f, 0.00000f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.26394f, -5.17853f, 0.78761f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.066"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08156f, 0.09604f, 0.83325f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, -0.27060f, -0.27060f);
            //scene.lastChild().translate(8.68552f, -5.75695f, 0.16333f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.079"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -3.83460f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.078"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, -2.52499f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.077"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -3.83460f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.076"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, -3.83460f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.075"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -3.83460f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.074"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -3.83460f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.073"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, -5.07100f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.086"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, -2.52794f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.085"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -1.29154f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.084"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -1.29154f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.083"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, -1.29154f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.082"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -1.29154f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.081"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 0.01807f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.080"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, -1.29154f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.093"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 1.26891f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.092"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 2.57852f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.091"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 1.26891f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.090"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, 1.26891f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.089"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 1.26891f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.088"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 1.26891f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.087"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 0.03251f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.100"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 2.58136f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.099"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 3.81776f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.098"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 3.81776f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.097"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, 3.81776f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.096"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 3.81776f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.095"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 5.12737f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.094"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 3.81776f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.107"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 6.36039f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.106"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 7.67000f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.105"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 6.36039f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.104"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, 6.36039f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.103"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 6.36039f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.102"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 6.36039f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.101"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 5.12399f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.114"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 7.70973f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.113"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, 0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 8.94613f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.112"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09424f, 1.36406f);
            //scene.lastChild().rotateQ(0.81915f, -0.57358f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 8.94613f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.111"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08891f, 0.08891f, 1.33401f);
            //scene.lastChild().rotateQ(0.65328f, 0.65328f, 0.27060f, -0.27060f);
            //scene.lastChild().translate(9.37255f, 8.94613f, 0.65019f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.110"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 8.94613f, 1.22492f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);

            //scene.addChild(new Object("Pagar.109"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.08134f, 0.95788f);
            //scene.lastChild().rotateQ(0.92388f, 0.00000f, 0.00000f, 0.38268f);
            //scene.lastChild().translate(9.37255f, 10.25574f, 0.77471f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.08627f, 0.06275f, 0.01290f);

            //scene.addChild(new Object("Pagar.108"));
            //scene.lastChild().createCube();
            //scene.lastChild().scale(0.08134f, 0.09579f, 1.33401f);
            //scene.lastChild().rotateQ(0.70711f, 0.70711f, 0.00000f, 0.00000f);
            //scene.lastChild().translate(9.37255f, 8.94613f, 0.15210f);
            //scene.lastChild().centerOrigin();
            //scene.lastChild().setColor(0.31765f, 0.19216f, 0.03922f);


            //KepalaAnjingScale.s = 0.002f;
            //GoyangBuntutScale.s = 0.008f;
        }

        public static void Animations(ref Object scene)
        {
            scene.findChild("Bitzer").findChild("KepalaAnjing").rotateX(KepalaAnjingScale.MinMaxBounce(-0.4444f, 0.4465f));
            scene.findChild("Bitzer").findChild("KepalaAnjing").findChild("OffsetTelingaKanan").rotateX(KepalaAnjingScale.MinMaxBounce(-0.3333f, 0.3333f));
            scene.findChild("Bitzer").findChild("KepalaAnjing").findChild("OffsetTelingaKiri").rotateX(KepalaAnjingScale.MinMaxBounce(0.3333f, -0.3333f));
            scene.findChild("Bitzer").findChild("KepalaAnjing").findChild("Lidah").translateX(KepalaAnjingScale.MinMaxBounce(-0.005555f, 0.005555f));
            scene.findChild("Bitzer").findChild("BuntutPusat").rotateX(GoyangBuntutScale.MinMaxBounce(-0.7777f, 0.7777f));
        }
    }
}
