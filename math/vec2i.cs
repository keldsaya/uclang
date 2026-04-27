using System;
using System.Globalization;
using UnityEngine;

namespace include.math {
  [Serializable]
  public struct vec2i : IEquatable<vec2i>, IFormattable {
    public int x, y;

    public static readonly vec2i zero  = new vec2i(0, 0);
    public static readonly vec2i one   = new vec2i(1, 1);
    public static readonly vec2i up    = new vec2i(0, 1);
    public static readonly vec2i down  = new vec2i(0, -1);
    public static readonly vec2i left  = new vec2i(-1, 0);
    public static readonly vec2i right = new vec2i(1, 0);

    public vec2i(int x, int y) { this.x = x; this.y = y; }

    public static vec2i operator +(vec2i a, vec2i b) => new vec2i(a.x + b.x, a.y + b.y);
    public static vec2i operator -(vec2i a, vec2i b) => new vec2i(a.x - b.x, a.y - b.y);
    public static vec2i operator -(vec2i a) => new vec2i(-a.x, -a.y);
    public static vec2i operator *(vec2i a, int b) => new vec2i(a.x * b, a.y * b);
    public static vec2i operator *(int a, vec2i b) => new vec2i(a * b.x, a * b.y);
    public static vec2i operator /(vec2i a, int b) => new vec2i(a.x / b, a.y / b);
    
    public static bool operator ==(vec2i a, vec2i b) => a.x == b.x && a.y == b.y;
    public static bool operator !=(vec2i a, vec2i b) => !(a == b);

    public override bool Equals(object obj) => obj is vec2i other && Equals(other);
    public bool Equals(vec2i other) => x == other.x && y == other.y;
    public override int GetHashCode() => HashCode.Combine(x, y);
    public override string ToString() => ToString(null, null);
    public string ToString(string format, IFormatProvider formatProvider = null) => 
      $"({x.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)}, {y.ToString(format, formatProvider ?? CultureInfo.InvariantCulture)})";
    
    public static implicit operator Vector2Int(vec2i v) => new Vector2Int(v.x, v.y);
    public static implicit operator vec2i(Vector2Int v) => new vec2i(v.x, v.y);
  }
}