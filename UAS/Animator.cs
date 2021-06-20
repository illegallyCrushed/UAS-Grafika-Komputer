using System;
using System.Collections.Generic;
using System.Text;
using Assimp;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using Quaternion = OpenTK.Mathematics.Quaternion;

namespace UAS
{
    public class Animator
    {
        public class Ticker {
            public float TPS;
            public float DurationInTicks;
            public float CurrentTick = 0;

            public static List<Ticker> Tickers = new List<Ticker>();

            private Ticker(float TPS, float DurationInTicks) {
                this.TPS = TPS;
                this.DurationInTicks = DurationInTicks;
            }

            public static void Update(float delta) {
                foreach (var ticker in Ticker.Tickers)
                {
                    ticker.CurrentTick += ticker.TPS * delta;
                    ticker.CurrentTick %= ticker.DurationInTicks;
                }
            }

            public static int NewTicker(float TPS, float DurationInTicks) {
                Ticker.Tickers.Add(new Ticker(TPS, DurationInTicks));
                return Ticker.Tickers.Count - 1;
            }

            public static float GetCurrentTick(int index) {
                return Ticker.Tickers[index].CurrentTick;
            }
        }

        public class Timeline {

            public static List<Timeline> Timelines = new List<Timeline>();

            public List<float> ScaleKeys;
            public List<float> RotationKeys;
            public List<float> PositionKeys;

            public List<Vector3> ScaleValues;
            public List<Quaternion> RotationValues;
            public List<Vector3> PositionValues;

            public Matrix4 Original;

            public int TickHandle;
            public String Node;

            private Timeline(String Node, float TPS, float DurationInTicks) {
                this.Node = Node;
                this.Original = Matrix4.Identity;

                TickHandle = Ticker.NewTicker(TPS, DurationInTicks);

                ScaleKeys = new List<float>();
                RotationKeys = new List<float>();
                PositionKeys = new List<float>();

                ScaleValues = new List<Vector3>();
                RotationValues = new List<Quaternion>();
                PositionValues = new List<Vector3>();
            }

            public static int NewTimeline(String Node, float TPS, float DurationInTicks, List<VectorKey> ScalingKeys, List<QuaternionKey> RotationKeys, List<VectorKey> PositionKeys)
            {
                Timeline temp = new Timeline(Node, TPS, DurationInTicks);

                foreach (var scakey in ScalingKeys)
                {
                    temp.ScaleKeys.Add((float)scakey.Time);
                    temp.ScaleValues.Add(new Vector3(scakey.Value.X, scakey.Value.Y, scakey.Value.Z));
                }

                foreach (var rotkey in RotationKeys)
                {
                    temp.RotationKeys.Add((float)rotkey.Time);
                    temp.RotationValues.Add(new Quaternion(rotkey.Value.X, rotkey.Value.Y, rotkey.Value.Z, rotkey.Value.W));
                }

                foreach (var poskey in PositionKeys)
                {
                    temp.PositionKeys.Add((float)poskey.Time);
                    temp.PositionValues.Add(new Vector3(poskey.Value.X, poskey.Value.Y, poskey.Value.Z));
                }

                Timeline.Timelines.Add(temp);
                return Timeline.Timelines.Count - 1;
            }

            public static int FindTimeline(String Node) {
                for (int i = 0; i < Timeline.Timelines.Count; i++)
                {
                    if (Timeline.Timelines[i].Node == Node)
                        return i;
                }
                return -1;
            }

            public static Matrix4 GetMatrixTransform(int index) {
                Timeline Access = Timeline.Timelines[index];
                Vector3 CurrentScale;
                Quaternion CurrentRotation;
                Vector3 CurrentPosition;

                if (Access.ScaleKeys.Count != 0)
                    CurrentScale = Access.ScaleValues[0];
                else
                    CurrentScale = Access.Original.ExtractScale();

                if (Access.RotationKeys.Count != 0)
                    CurrentRotation = Access.RotationValues[0];
                else
                    CurrentRotation = Access.Original.ExtractRotation();

                if (Access.PositionKeys.Count != 0)
                    CurrentPosition = Access.PositionValues[0];
                else
                    CurrentPosition = Access.Original.ExtractTranslation();

                float CurrentTick = Ticker.GetCurrentTick(Access.TickHandle);

                for (int i = Access.ScaleKeys.Count-1 ; i >= 0 ; i--)
                {
                    if (Access.ScaleKeys[i] < CurrentTick) {
                        if (i == Access.ScaleKeys.Count - 1)
                        {
                            CurrentScale = Access.ScaleValues[i];
                        }
                        else
                        {
                            CurrentScale = Access.ScaleValues[i] + (Access.ScaleValues[i + 1] - Access.ScaleValues[i]) * ((CurrentTick - Access.ScaleKeys[i]) / (Access.ScaleKeys[i + 1] - Access.ScaleKeys[i]));
                        }
                        break;
                    }
                }

                for (int i = Access.RotationKeys.Count-1; i >= 0; i--)
                {
                    if (Access.RotationKeys[i] < CurrentTick)
                    {
                        if (i == Access.RotationKeys.Count - 1)
                        {
                            CurrentRotation = Access.RotationValues[i];
                        }
                        else
                        {
                            CurrentRotation = Access.RotationValues[i] + (Access.RotationValues[i + 1] - Access.RotationValues[i]) * ((CurrentTick - Access.RotationKeys[i]) / (Access.RotationKeys[i + 1] - Access.RotationKeys[i]));
                        }
                        break;
                    }
                }

                for (int i = Access.PositionKeys.Count-1; i >= 0; i--)
                {
                    if (Access.PositionKeys[i] < CurrentTick)
                    {
                        if (i == Access.PositionKeys.Count - 1)
                        {
                            CurrentPosition = Access.PositionValues[i];
                        }
                        else
                        {
                            CurrentPosition = Access.PositionValues[i] + (Access.PositionValues[i + 1] - Access.PositionValues[i]) * ((CurrentTick - Access.PositionKeys[i]) / (Access.PositionKeys[i + 1] - Access.PositionKeys[i]));
                        }
                        break;
                    }
                }

                Matrix4 CurrentTransform = Matrix4.CreateScale(CurrentScale) * Matrix4.CreateFromQuaternion(CurrentRotation) * Matrix4.CreateTranslation(CurrentPosition);
                return CurrentTransform;
            }
        }
    }
}
