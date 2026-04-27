namespace include.@string {
  public static partial class h {
    public static unsafe void strcpy(char* dest, char* src) {
      while ((*dest++ = *src++) != '\0');
    }
  }
}