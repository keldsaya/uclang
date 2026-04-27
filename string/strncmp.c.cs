namespace include.@string {
  public static partial class h {
    public static unsafe int strncmp(char* s1, char* s2, int n) {
      if (n == 0) return 0;

      byte* p1 = (byte*)s1;
      byte* p2 = (byte*)s2;

      while (n-- > 0 && *p1 != 0 && *p1 == *p2) {
        if (n == 0) break;
        p1++;
        p2++;
      }

      return *p1 - *p2;
    }
  }
}