using UnityEngine;
using System.Collections;

public class Outer {

    public static void RectMove(ref Rect _rect, float _addX, float _addY)
    {
        RectSet(ref _rect, _rect.x + _addX, _rect.y + _addY, _rect.width, _rect.height);
    }

    public static void RectTune(ref Rect _rect, float _addX, float _addY, float _addWidth, float _addHeight)
    {
        RectSet(ref _rect, _rect.x + _addX, _rect.y + _addY, _rect.width + _addWidth, _rect.height + _addHeight);
    }

    public static void RectResize(ref Rect _rect, float _addX, float _addY, float _w, float _h)
    {
        RectSet(ref _rect, _rect.x + _addX, _rect.y + _addY, _w, _h);
    }

    public static void RectSet(ref Rect _rect, float _x, float _y, float _w, float _h)
    {
        _rect.x = _x;
        _rect.y = _y;
        _rect.width = _w;
        _rect.height = _h;
    }

    public static void RectClone(ref Rect _rect, Rect _target)
    {
        _rect = new Rect(_target.x, _target.y, _target.width, _target.height);
    }

#region new rect

    public static Rect NewRectResize(ref Rect _rect, int _x, int _y, int _w, int _h)
    {
        return new Rect(_rect.x + _x, _rect.y + _y, _w, _h);
    }

    public static Rect NewRectTune(ref Rect _rect, int _x, int _y, int _w, int _h)
    {
        return new Rect(_rect.x + _x, _rect.y + _y, _rect.width + _w,  _rect.height + _h);
    }

#endregion
}
