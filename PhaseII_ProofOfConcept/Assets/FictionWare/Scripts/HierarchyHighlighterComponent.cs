using UnityEngine;

public class HierarchyHighlighterComponent : MonoBehaviour
{
    public enum HighlightOn { None = -1, Always = 0, Runtime = 1 }

    public HighlightOn type;
    [System.NonSerialized] public bool isRuntime;
    public Color color = new Color(0f, 1f, 0f, 0.3f);

    void OnEnable()
    {
        isRuntime = true;
    }
}
