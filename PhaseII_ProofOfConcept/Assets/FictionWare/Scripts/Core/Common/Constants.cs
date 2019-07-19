
using System;
//using FictionWare.Enums;
using UnityEngine.Networking;

namespace FictionWare
{
    using UnityEngine;

    public static class Constants
    {

        public const int FIRST = 0;
        public const int SECOND = 1;
        public const float TOLERANCE = 0.001f;
        public const int ROOT = 0;

        public static readonly Vector3 NULL_VECTOR3 = Vector3.one;

        public struct InitializationMask
        {
            public const int Start = 1;
            public const int End = 2;
            public const int PostStart= 4;
            public const int PostEnd = 8;
        }

        public struct SubscribeMask
        {
            public const int Init = 1;
            public const int PostInit = 2;
            public const int Tick = 4;
            public const int Unload = 8;
        }

        public struct StateValues
        {
            public const int Start = 0;
            public const int Off = 1;
            public const int On = 2;
            public const int Inactive = 3;
            public const int Free = 4;
            public const int Ready = 5;
            public const int Active = 6;
            public const int In = 7;
            public const int Out = 8;
            public const int Busy = 9;
            public const int Trail = 0;
        }

        public struct TagStrings
        {
            public const string FictionWare = "[FictionWare]";
            public const string Now = "[Now]";
            public const string Event = "[Event]";
            public const string Warning = "[Warning]";
            public const string SDK = "[SDK]";
            public const string Scene = "[Scene]";
        }

        public struct Fx
        {
            public struct Containers
            {
                public const int UNDEFINED = 0;

                public const int DEFAULT = 1234;
            }
            public struct Branches
            {
                public const int UNDEFINED = 0;

                public const int DEBUG = 1234;
                public const int GESTURE = 1001;
                public const int IDATANK = 2001;
            }
            public struct Sets
            {
                public const int UNDEFINED = 0;

                public const int DEFAULT = 100;
                public const int DOUBLE = 101;
                public const int MARKER = 102;

                public const int DUST = 200;
            }
            public struct Effectors
            {
                public const int UNDEFINED = 0;
            }
        }

        public struct Colors
        {
            public static Color Normal = new Color(0.5f, 0.5f, 1.000f);
        }

        public struct XR
        {
            public struct SDKs
            {
                public const string None = "None";
                public const string Oculus = "Oculus";
                public const string OpenVr = "OpenVR";
            }

            public struct Models
            {
                public const string None = "None";
                public const string OculusCv1 = "Oculus Rift CV1";
                public const string OculusRiftS = "Oculus Rift S";
                public const string Vive = "Vive MV";
                public const string LenovoExplorer = "Lenovo Explorer";
                public const string SamsungOdissey = "Samsung Windows Mixed Reality 800ZAA";
                public const string Acer = "Acer AH100";
                public const string HpWindowsMr = "HP Windows Mixed Reality Headset";
            }

            public struct TracingRays { }
            public struct TrackedPoseDriverOffsets { }

            public static Vector3 GetPoseDriverOffset(Enums.XR.Model model)
            {
                switch (model)
                {
                    case Enums.XR.Model.OculusCV1:
                        return Vector3.up * 0.08f;

                    case Enums.XR.Model.HTCVive:
                        return Vector3.up * 0.08f;

                    default:
                        return Vector3.zero;
                }
            }

            public static Vector3 GetControllerDirection(Enums.XR.Model model)
            {
                switch (model)
                {
                    case Enums.XR.Model.OculusCV1:
                        return Vector3.forward;

                    case Enums.XR.Model.HTCVive:
                        return Quaternion.Euler(60, 0, 0) * Vector3.forward;

                    default:
                        return Vector3.forward;
                }
            }
        }

        public struct Input
        {
            public struct Controllers
            {
                public const string none = "";

                public const string mouse = "Generic Mouse";

                public const string gamepad = "Controller (XBOX 360 For Windows)";

                public const string throttle = "Saitek Pro Flight X-55 Rhino Throttle";
                public const string stick = "Saitek Pro Flight X-55 Rhino Stick";

                public const string OpenVrViveMvRight = "OpenVR Controller(Vive Controller MV) - Right";
                public const string OpenVrViveMvLeft = "OpenVR Controller(Vive Controller MV) - Left";

                public const string OpenVrWindowsMrLeft = "OpenVR Controller(WindowsMR: 0x045E/0x065B/0/1) - Left";
                public const string OpenVrWindowsMrRight = "OpenVR Controller(WindowsMR: 0x045E/0x065B/0/2) - Right";

                public const string OculusRemote = "----- CHECK THE RIGHT NAME -----";

                public const string OculusTouchLeft = "Oculus Touch Controller - Left";
                public const string OculusTouchRight = "Oculus Touch Controller - Right";
                public const string OpenVrTouchLeft = "OpenVR Controller(Oculus Rift CV1 (Left Controller)) - Left";
                public const string OpenVrTouchRight = "OpenVR Controller(Oculus Rift CV1 (Right Controller)) - Right";
            }
            public static int JoystickAvailabilityCheck(string name)
            {
                switch (name)
                {
                    case Controllers.gamepad:
                        return 1 << (int)Enums.XR.GearPose.GamePad;

                    case Controllers.OpenVrViveMvRight:
                        return 1 << (int)Enums.XR.GearPose.RightHand;
                    case Controllers.OpenVrViveMvLeft:
                        return 1 << (int)Enums.XR.GearPose.LeftHand; ;

                    case Controllers.OpenVrWindowsMrRight:
                        return 1 << (int)Enums.XR.GearPose.RightHand;
                    case Controllers.OpenVrWindowsMrLeft:
                        return 1 << (int)Enums.XR.GearPose.LeftHand; ;

                    case Controllers.OculusTouchRight:
                        return 1 << (int)Enums.XR.GearPose.RightHand;
                    case Controllers.OculusTouchLeft:
                        return 1 << (int)Enums.XR.GearPose.LeftHand; ;

                    case Controllers.OpenVrTouchRight:
                        return 1 << (int)Enums.XR.GearPose.RightHand;
                    case Controllers.OpenVrTouchLeft:
                        return 1 << (int)Enums.XR.GearPose.LeftHand;

                    default:
                        return 0;
                }
            }
        }
    }
}



