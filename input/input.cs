using UnityEngine;

namespace include.input_h {
  public static class input {
    public static bool mouse(int b) => Input.GetMouseButton(b);
    public static bool mouse_down(int b) => Input.GetMouseButtonDown(b);
    public static float axis(string n) => Input.GetAxis(n);
    public static float axis_raw(string n) => Input.GetAxisRaw(n);
    public static bool key(KeyCode k) => Input.GetKey(k);
    public static bool key_down(KeyCode k) => Input.GetKeyDown(k);
  }
}