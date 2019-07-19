using UnityEngine;
using UnityEditor;

[InitializeOnLoad]
public class HierarchyHighlighter
{
    private static HierarchyHighlighterComponent h;

    static HierarchyHighlighter()
    {
        EditorApplication.hierarchyWindowItemOnGUI += HierarchyWindowItem_CB;
    }

    private static void HierarchyWindowItem_CB(int selectionID, Rect selectionRect)
    {
        var o = EditorUtility.InstanceIDToObject(selectionID);
        if (o == null) return;

        h = ((GameObject) o).GetComponent<HierarchyHighlighterComponent>();
        if (h == null) return;

        if (SkipHighlight()) return;

        if (Event.current.type != EventType.Repaint) return;

        EditorGUI.DrawRect(selectionRect, h.color);
        EditorApplication.RepaintHierarchyWindow();
    }

    private static bool SkipHighlight()
    {
        switch (h.type)
        {
            case HierarchyHighlighterComponent.HighlightOn.None:
                return true;
            case HierarchyHighlighterComponent.HighlightOn.Always:
                return false;
            case HierarchyHighlighterComponent.HighlightOn.Runtime:
                return !h.isRuntime;
        }
        return false;
    }
}
