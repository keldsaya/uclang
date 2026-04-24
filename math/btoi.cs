using System;

namespace include.math_h {
  [Serializable]
  public struct btoi {
    [UnityEngine.SerializeField] private bool _val;

    public btoi(bool v) => _val = v;
    public btoi(int i)  => _val = (i != 0);

    public static implicit operator btoi(int i) => new btoi(i);
    public static implicit operator btoi(bool v) => new btoi(v);
    public static implicit operator bool(btoi b) => b._val;
    public static implicit operator int(btoi b) => b._val ? 1 : 0;
    public static bool operator true(btoi b)  => b._val;
    public static bool operator false(btoi b) => !b._val;
    public static btoi operator !(btoi b)     => new btoi(!b._val);

    public override string ToString() => _val.ToString().ToLower();
  }
}