namespace include.@string {
  public static partial class h {
      public static unsafe int strcmp(char* s1, char* s2) {
      byte* p1 = (byte*)s1;
      byte* p2 = (byte*)s2;

      while (*p1 != 0 && *p1 == *p2) {
        p1++;
        p2++;
      }

      return *p1 - *p2;
    }
  }
}