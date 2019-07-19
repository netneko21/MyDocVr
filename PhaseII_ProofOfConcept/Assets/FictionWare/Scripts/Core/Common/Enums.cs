namespace FictionWare.Enums
{

    public enum VertexDataType
    {
        ColorsVerticesUvs = 0,
        ColorsUvs = 1
    }

    public enum DrawGizmos { None = 0, Selected = 1, Always = 2}

    #region WORLD

    public enum Gravity
    {
        Off = 0,
        VerticalDown,
        WorldZero
    }

    #endregion

    #region XR 

    public struct XR
    {
        public enum Standard
        {
            Undefined = 0,
            None,
            OpenXR,
            OVR,
            SteamVR
        }

        public enum SDK
        {
            None,
            Oculus,
            OpenVR,
            Daydream
        }

        public enum Family
        {
            None,
            Oculus,
            Vive,
            Windows,
            Undefined
        }

        public enum Model
        {
            None,
            OculusCV1,
            OculusRiftS,
            OculusGO,
            HTCVive,
            LenovoExplorer,
            Undefined
        }

        public enum GearPose
        {
            Mouse = 1,
            Head = 3,
            LeftHand = 4,
            RightHand = 5,
            GamePad = 6,
            Tracker = 8
        }

        public enum HandGearHand
        {
            Dual = 0,
            LeftHand = 1,
            RightHand = 2,
        }
    }
    #endregion

    #region INPUT 

    public enum HeadGearType
    {
        None = 0,
        Headset,
    }

    public enum MainHandGearType
    {
        None = 0,
        Mouse,
        Keyboard,
        Joystick,
        Handheld
    }

    public enum InputMap
    {
        // 100 - button additive
        // 200 - axis additive

        ButtonApp,
        ButtonStart = 107,
        ButtonBack,

        ButtonOne = 100,
        ButtonTwo = 101,
        ButtonThree = 102,
        ButtonFour = 103,

        ButtonTrackpadLeft = 108,
        ButtonTrackpadRight = 109,

        TouchTriggerLeft = 114,
        TouchTriggerRight = 115,
        TouchTrackpadLeft = 116,
        TouchTrackpadRight = 117,

        HorizontalThumbstickLeft = 201,
        VerticalThumbstickLeft = 202,

        HorizontalThumbstickRight =204,
        VerticalThumbstickRight = 205,

        SqueezeTriggerLeft = 209,
        SqueezeTriggerRight = 210,
        SqueezeGripLeft = 211,
        SqueezeGripRight = 212,



        Orientation
    }
    
    public enum TrackingType
    {
        Tracing,
        Touches
    }

    public enum TouchDetectionBy
    {
        Touch,
        Gaze
    }

    public enum LayerMaskType
    {
        UI,
        All,
        WorldOnly,
        Water
    }
    #endregion

    #region STATES

    public enum State
    {
        Start = Constants.StateValues.Start,
        Off = Constants.StateValues.Off,
        Inactive = Constants.StateValues.Inactive,
        Free = Constants.StateValues.Free,
        Ready = Constants.StateValues.Ready,
        On = Constants.StateValues.On,
        Active = Constants.StateValues.Active,
        In = Constants.StateValues.In,
        Out = Constants.StateValues.Out,
        Busy = Constants.StateValues.Busy,
        Trail = Constants.StateValues.Trail
    }

    public enum HudState
    {
        Hidden = 0,
        Disabled = 1,
        Unfocused = 2,
        Focused = 3,
        Active = 4,
        Start = 5
    }

    public enum VfxState
    {
        Hidden = 0,
        FadeIn = 1,
        Visible = 2,
        FadeOut = 3,
    }

    #endregion

}