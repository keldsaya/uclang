namespace include.@string {
  public static partial class h {
    public static unsafe int strlen(char *s) {
      char* start = s;
      char* curr = s;

      while (*curr != '\0') {
        curr++;
      }

      return (int)(curr - start); 
    }
  }
}