using UnityEngine;
namespace include.cursor_h {
  public enum cur_lock_mode {
    none, locked, confined
  }
  public static class cursor {
    public static bool visible => Cursor.visible;
    public static cur_lock_mode state {
      get => (cur_lock_mode)Cursor.lockState;
      set => Cursor.lockState = (CursorLockMode)value;
    }
  }
}