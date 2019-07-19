namespace FictionWare
{

    using UnityEngine;
    using UnityEditor;
    using UnityEngine.SceneManagement;
    using Random = UnityEngine.Random;

    public class FW_EditorShelf : EditorWindow
    {
        public enum FW_ObjectType
        {
            CameraRig,
            GameLogic,
            SceneContainers,
            Grid,
            Noise,
            Loader,
            Player,
            Spawners
//            SpawnPoint
        }

        FW_ObjectType holderType = FW_ObjectType.SceneContainers;

        private GUIStyle styleNull;

        private bool bPos = true;
        private bool bRot = true;
        private bool bScale;

        //private const bool BRandomPan = false;
        private bool bNonUniform;

        private Vector3 vPos = Vector3.zero;
        private Quaternion qRot = Quaternion.identity;
        private Vector3 vScale = Vector3.zero;

        private Transform selection;

        private Texture texBtnHighlight;
        private Texture texBtnCopy;
        private Texture texBtnPaste;
        private Texture texBtnRotateY;
        private Texture texBtnByZero;
        private Texture texBtnRandomScale;
        private Texture texBtnMesh2Prefab;

        private AnimationClip animationClip2Export;

        private Texture texBtnToTheGround;

        //private Color colorActiveButton = new Color(0.561f, 0.718f, 0.941f);
        //private Color colorIdleButton = new Color(0.85f, 0.85f, 0.85f);

        //    private string currentVRDevice;
        private bool virtualRealitySupported;

        private bool cacheServerIsOn;

        [MenuItem("Tools/FictionWare/Shelf")]
        static void Init()
        {
#pragma warning disable 168
            var window = (FW_EditorShelf)GetWindow(typeof(FW_EditorShelf));
            window.Show();
#pragma warning restore 168
        }


        void InitTextures()
        {
            texBtnHighlight = (Texture)Resources.Load("editor_icons/e_btn_highlight", typeof(Texture));
            texBtnCopy = (Texture)Resources.Load("editor_icons/e_btn_copy", typeof(Texture));
            texBtnPaste = (Texture)Resources.Load("editor_icons/e_btn_paste", typeof(Texture));
            texBtnRotateY = (Texture)Resources.Load("editor_icons/e_btn_rotateY", typeof(Texture));
            texBtnByZero = (Texture)Resources.Load("editor_icons/e_btn_byZero", typeof(Texture));
            texBtnToTheGround = (Texture)Resources.Load("editor_icons/e_btn_toTheGround", typeof(Texture));
            texBtnRandomScale = (Texture)Resources.Load("editor_icons/e_btn_randomScale", typeof(Texture));
            texBtnMesh2Prefab = (Texture)Resources.Load("editor_icons/e_btn_mesh2prefab", typeof(Texture));
        }

        void HighlightInHierarchy()
        {
            selection = Selection.activeTransform;

            if (selection)
            {
                HierarchyHighlighterComponent hh = selection.GetComponent<HierarchyHighlighterComponent>();

                if (hh == null)
                {
                    selection.gameObject.AddComponent<HierarchyHighlighterComponent>();
                    hh = selection.gameObject.GetComponent<HierarchyHighlighterComponent>();
                }
                else
                {
                    DestroyImmediate(hh);
                    return;
                }

                var floorValue = 0.2f;
                var restValue = 1 - floorValue;

                hh.color = new Color(floorValue + restValue * Random.value, floorValue + restValue * Random.value,
                    floorValue + restValue * Random.value, 0.3f);
                hh.type = HierarchyHighlighterComponent.HighlightOn.Always;
            }
            else Debug.Log("Select object first");
        }


        void CopyTransform()
        {
            selection = Selection.activeTransform;

            if (selection)
            {
                vPos = selection.position;
                qRot = selection.rotation;
                vScale = selection.localScale;
            }
            else Debug.Log("Select object first");

        }

        void PasteTransform()
        {
            selection = Selection.activeTransform;
            if (selection)
            {
                Undo.RecordObject(selection, "Tranform pasting to " + selection.name);
                if (bPos) selection.position = vPos;
                if (bRot)
                {
                    selection.rotation = qRot;
                    //if (BRandomPan)
                    //selection.RotateAround(selection.position, selection.up, 360 * Random.value);
                }
                if (bScale) selection.localScale = vScale;
            }
            else Debug.Log("Select object first");

        }

        private float randomScaleMin = 1f;
        private float randomScaleMax = 1f;

        void RandomScale()
        {
            selection = Selection.activeTransform;
            float value;

            if (Selection.transforms != null)
            {
                foreach (Transform t in Selection.transforms)
                {
                    value = randomScaleMin + Random.value * (randomScaleMax - randomScaleMin);
                    t.localScale = Vector3.one * value;
                }
            }
            else Debug.Log("Select object first");

        }

        void RotateTransform()
        {
            //selection = Selection.activeTransform;
            if (Selection.transforms != null)
            {
                foreach (Transform t in Selection.transforms)
                {
                    Undo.RecordObject(t, "RotateTransform " + t.name);
                    t.RotateAround(t.position, t.up, 360 * Random.value);
                }
            }
            else Debug.Log("Select object first");
        }

        void OrientByZero()
        {
            selection = Selection.activeTransform;
            if (selection)
            {
                Undo.RecordObject(selection, "OrientByZero " + selection.name);
                Quaternion tempRot = Quaternion.FromToRotation(selection.up, selection.position.normalized);
                selection.rotation = tempRot * selection.rotation;

            }
            else Debug.Log("Select object first");

        }

        void DropToTheGround()
        {
            //selection = Selection.activeTransform;


            foreach (Transform selection in Selection.transforms)
            {
                //if (selection)
                //{
                Undo.RecordObject(selection, "DropToTheGround " + selection.name);
                RaycastHit hit;
                if (selection.GetComponent<Collider>()) selection.GetComponent<Collider>().enabled = false;

                //if (Physics.Raycast(new Vector3(selection.position.X, selection.position.Y + selection.renderer.bounds.extents.Y, selection.position.Z), -Vector3.up * 100f, out hit))
                //selection.position = new Vector3(hit.point.X, hitPos.point.Y + selection.renderer.bounds.extents.Y, hitPos.point.Z);

                if (Physics.Raycast(new Vector3(selection.position.x, selection.position.y, selection.position.z),
                    -Vector3.up * 100f, out hit))
                    selection.position = new Vector3(hit.point.x, hit.point.y, hit.point.z);

                if (selection.GetComponent<Collider>()) selection.GetComponent<Collider>().enabled = true;

                //}
                //else Debug.Log("Select object first");
            }

        }

        void ExportMesh()
        {
            selection = Selection.activeTransform;

            MeshFilter mf = selection.GetComponent<MeshFilter>();

            if (mf == null)
            {
                Debug.LogError("There is no component [MesfFilter] on selected object");
                return;
            }
            Mesh m = selection.GetComponent<MeshFilter>().mesh;
            if (m == null)
            {
                Debug.LogError("There is no mefh on selected object");
                return;
            }
            AssetDatabase.CreateAsset(m, "Assets/exportedMesh_" + m.name + ".asset");
            AssetDatabase.SaveAssets();

        }


        //	private var scene : SceneView;
        //	private var cam : Camera;

        //	function Update() {
        //		if (scene == null) 
        //			scene = EditorWindow.GetWindow(SceneView); 
        //			 
        //		if(scene && scene.camera)
        //	    {
        //           cam = scene.camera;
        //	   	}
        //        else cam = null;
        //	}

//        void DisconnectPrefab()
//        {
//            selection = Selection.activeTransform;
//
//            PrefabUtility.DisconnectPrefabInstance(selection);
//        }

        public void Awake()
        {
            EditorSettings.serializationMode = SerializationMode.ForceText;

            //styleNull = new GUIStyle();
            styleNull = new GUIStyle { alignment = TextAnchor.MiddleCenter };

            InitTextures();

            //        currentVRDevice = XRSettings.supportedDevices[0];

            //        this.minSize = new Vector2(100, 32);
        }

        private Rect rect;
        private Rect rectButton;

        private Color color;
        private readonly Color colorOff = new Color(1.0f, 0.5f, 0.5f);
        private Color colorOn = new Color(0.9f, 1.0f, 0.9f);
        private Color colorAction = new Color(0.8f, 1.0f, 1.0f);

        Color CacheServerCheck()
        {
            cacheServerIsOn = System.Diagnostics.Process.GetProcessesByName("node").Length > 0;
            return cacheServerIsOn ? Color.clear : colorOff;
        }

        Color VRCheck()
        {
            virtualRealitySupported = PlayerSettings.virtualRealitySupported;
            return virtualRealitySupported ? colorOn : colorOff;
        }

        void OnGUI()
        {

            minSize = new Vector2(100, 36);
            maxSize = new Vector2(800, 36);

            rect = GUILayoutUtility.GetRect(32, 32);
            Outer.RectResize(ref rect, 3, 3, 32, 32);

            if (GUI.Button(rect, new GUIContent(texBtnHighlight, "Highlight in Hierarchy")))
            {
                HighlightInHierarchy();
            }

            Outer.RectTune(ref rect, 34, 0, 0, 0);
            if (GUI.Button(rect, new GUIContent(texBtnCopy, "Copy transforms")))
            {
                CopyTransform();
            }

            Outer.RectTune(ref rect, 34, 0, 0, 0);
            if (GUI.Button(rect, new GUIContent(texBtnPaste, "Paste transforms")))
            {
                PasteTransform();
            }

//            Outer.RectTune(ref rect, 34, 0, 0, 0);
//            if (GUI.Button(rect, new GUIContent("><", "Disconnect this object from prefab")))
//            {
//                DisconnectPrefab();
//            }

            Outer.RectTune(ref rect, 50, 0, -20, 0);
            EditorGUI.LabelField(rect, "T    R    S ");

            Outer.RectResize(ref rect, 0, 15, 16, 16);
            bPos = EditorGUI.Toggle(rect, bPos);

            Outer.RectTune(ref rect, 23, 0, 0, 0);
            bRot = EditorGUI.Toggle(rect, bRot);

            Outer.RectTune(ref rect, 23, 0, 0, 0);
            bScale = EditorGUI.Toggle(rect, bScale);


            Outer.RectResize(ref rect, 32, -15, 32, 32);
            if (GUI.Button(rect, new GUIContent(texBtnRotateY, "Random panning")))
            {
                RotateTransform();
            }
            Outer.RectTune(ref rect, 34, 0, 0, 0);
            if (GUI.Button(rect, new GUIContent(texBtnByZero, "Up-axis looks out from the world zero")))
            {
                OrientByZero();
            }

            Outer.RectTune(ref rect, 34, 0, 0, 0);
            if (GUI.Button(rect, new GUIContent(texBtnToTheGround, "Drop to the ground")))
            {
                DropToTheGround();
            }

            Outer.RectResize(ref rect, 40, 0, 40, 32);
            randomScaleMin = EditorGUI.FloatField(rect, Mathf.Clamp(randomScaleMin, 0.1f, randomScaleMax), styleNull);

            Outer.RectResize(ref rect, 40, 0, 32, 32);
            if (GUI.Button(rect, new GUIContent(texBtnRandomScale, "Random scaling")))
            {
                RandomScale();
            }

            Outer.RectResize(ref rect, 32, 0, 40, 32);
            randomScaleMax = EditorGUI.FloatField(rect, Mathf.Clamp(randomScaleMax, randomScaleMin, 4f), styleNull);

            Outer.RectResize(ref rect, 32, 0, 32, 32);
            if (GUI.Button(rect, new GUIContent(texBtnMesh2Prefab, "Export mesh to prefab")))
            {
                ExportMesh();
            }

            //        GUI.backgroundColor = VRCheck();
            //        Outer.RectResize(ref rect, 60, 0, 32, 32);
            //        if (GUI.Button(rect, new GUIContent("VR\n" + (virtualRealitySupported ? "on" : "off"), "Virtual Reality Supported")))
            //        {
            //            virtualRealitySupported = !virtualRealitySupported;
            //            PlayerSettings.virtualRealitySupported = virtualRealitySupported;
            //        }

            //        GUI.backgroundColor = colorOn;
            //        Outer.RectResize(ref rect, 60, 0, 48, 32);
            //        if (GUI.Button(rect, new GUIContent("Build\nVR on", "Build & Run VR scene")))
            //        {
            //            BuildCurrentScene(true);
            //        }
            //
            //        GUI.backgroundColor = colorOff;
            //        Outer.RectResize(ref rect, 60, 0, 48, 32);
            //        if (GUI.Button(rect, new GUIContent("Build\nVR off", "Build & Run scene")))
            //        {
            //            BuildCurrentScene(false);
            //        }

            //        GUI.backgroundColor = Color.white;

            Outer.RectResize(ref rect, 50, 0, 56, 32);
            if (GUI.Button(rect, new GUIContent("Settings")))
            {
//                EditorApplication.ExecuteMenuItem("Edit/Preferences...");
//                EditorApplication.ExecuteMenuItem("GameObject/3D Object/Cube");
                EditorApplication.ExecuteMenuItem("Edit/Project Settings...");
//                EditorApplication.ExecuteMenuItem("Edit/Project Settings.../Player");
//                EditorApplication.ExecuteMenuItem("Edit/Project Settings");
            }

//            Outer.RectResize(ref rect, 48, 0, 46, 32);
//            if (GUI.Button(rect, new GUIContent("GFX")))
//            {
//                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Graphics");
//            }
//
//            Outer.RectResize(ref rect, 48, 0, 46, 32);
//            if (GUI.Button(rect, new GUIContent("Input")))
//            {
//                EditorApplication.ExecuteMenuItem("Edit/Project Settings/Input");
//            }

            Outer.RectResize(ref rect, 80, 0, 100, 16);
            holderType = (FW_ObjectType)EditorGUI.EnumPopup(rect, holderType);
            GUI.backgroundColor = colorAction;
            Outer.RectTune(ref rect, 0, 16, 0, 0);
            if (GUI.Button(rect, "Create or Ping"))
            {
                CreateFWSDKHandler();
            }


            GUI.backgroundColor = Color.white;

            Outer.RectResize(ref rect, 104, -16, 100, 16);
            animationClip2Export =
                (AnimationClip)EditorGUI.ObjectField(rect, animationClip2Export, typeof(AnimationClip), true);
            GUI.backgroundColor = colorOn;
            Outer.RectTune(ref rect, 0, 16, -18, 0);
            if (GUI.Button(rect, "Clip 2 .anim"))
            {
                ExportClip2AnimAsset();
            }

            GUI.backgroundColor = CacheServerCheck();
            Outer.RectResize(ref rect, 90, -16, 128, 32);
            GUI.Box(rect, "CacheServer\nis " + (cacheServerIsOn ? "ON" : "OFF"));

        }

        protected string GetHandlerName(FW_ObjectType type)
        {
            var tempName = ("" + type).Split('.');
            return tempName[tempName.Length - 1];
        }

        void CreateFWSDKHandler()
        {
            var handleName = "[" + GetHandlerName(holderType) + "]";
            GetHandlerName(holderType);
            Create(handleName);

//            switch (holderType)
//            {
//                case FW_ObjectType.SpawnPoint:
//                    var root = Create("[Spawners]").transform;
//                    var result = Create("SpawnPoint_" + root.GetComponentsInChildren<FW_SpawnPoint>().Length);
//                    result.transform.parent = root;
//                    result.AddComponent<FW_SpawnPoint>();
//                    break;
//                default:
//                    Create(handleName);
//                    break;
//            }
        }

        void ExportClip2AnimAsset()
        {
            if (animationClip2Export == null)
            {
                Debug.LogWarning("Select a clip first");
                return;
            }

            AnimationClip newClip = Instantiate(animationClip2Export) as AnimationClip;

            string path = "Assets/FictionWare/ExportedClips/" + animationClip2Export.name + "_exported.anim";

            AssetDatabase.CreateAsset(newClip, path);
            AssetDatabase.SaveAssets();
            Debug.Log("Asset saved as " + path);

        }

        private GameObject Create(string objectName)
        {
            var current = GameObject.Find(objectName);
            if (current != null)
            {
                EditorGUIUtility.PingObject(current);
            }
            else
            {
                current = new GameObject(objectName);
                Selection.activeGameObject = current;
            }
            return current;
        }

        void BuildCurrentScene(bool _buildAsVR)
        {
            var extention = "undefined";
            switch (BuildTarget.Android)
            {
                case BuildTarget.Android:
                    extention = "apk";
                    break;
            }
            PlayerSettings.virtualRealitySupported = _buildAsVR;
            var scene = SceneManager.GetActiveScene();
            string[] levels = { scene.path };
            BuildPipeline.BuildPlayer(levels, "D:/_UnityBuilds/" + scene.name + "." + extention, BuildTarget.Android,
                BuildOptions.AutoRunPlayer);
        }


    }

}