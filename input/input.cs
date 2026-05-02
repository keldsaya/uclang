using include.math;
using UnityEngine;

namespace include.input {
  public static class h {
    public static vec2 input_mouse_pos => new vec2(Input.mousePosition.x, Input.mousePosition.y);
    public static bool input_mouse(int b) => Input.GetMouseButton(b);
    public static bool input_mouse_down(int b) => Input.GetMouseButtonDown(b);
    public static bool input_mouse_up(int b) => Input.GetMouseButtonUp(b);
    public static float input_axis(string n) => Input.GetAxis(n);
    public static float input_axis_raw(string n) => Input.GetAxisRaw(n);
    public static bool input_key(KeyCode k) => Input.GetKey(k);
    public static bool input_key_down(KeyCode k) => Input.GetKeyDown(k);
  }
}