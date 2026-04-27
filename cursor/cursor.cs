using UnityEngine;
namespace include.cursor {
  public enum cur_lock_mode_t {
    none, locked, confined
  }
  public static class h {
    public static bool cur_visible => Cursor.visible;
    public static cur_lock_mode_t cur_state {
      get => (cur_lock_mode_t)Cursor.lockState;
      set => Cursor.lockState = (CursorLockMode)value;
    }
  }
}