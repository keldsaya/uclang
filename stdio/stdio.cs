using System;
using System.Text;
using UnityEngine;

namespace include.stdio_h {
  public static class stdio {
    public static void printf(string str, params object[] args) {
      if (string.IsNullOrEmpty(str)) return;

      StringBuilder result = build_str(str, args);

      string finalString = result.ToString();

      Debug.Log(finalString);
    }
    public static string snprintf(string str, params object[] args) {
      if (string.IsNullOrEmpty(str)) return str;

      StringBuilder result = build_str(str, args);

      return result.ToString();
    }

    private static StringBuilder build_str(string str, object[] args) {
      StringBuilder result = new StringBuilder();
      int argIndex = 0;

      for (int i = 0; i < str.Length; i++) {
        if (str[i] == '%' && i + 1 < str.Length) {
          char specifier = str[i + 1];

          switch (specifier) {
            case 'd':
            case 'i':
            case 's':
            case 'f':
            case 'c':
              if (argIndex < args.Length) {
                result.Append(args[argIndex++]);
              }
              i++;
              break;

            case '%':
              result.Append('%');
              i++;
              break;

            default:
              result.Append(str[i]);
              break;
          }
        }
        else {
          result.Append(str[i]);
        }
      }

      return result;
    }
  }
}