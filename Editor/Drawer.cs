using UnityEditor;
using UnityEngine;
using include.math;
using include;

[CustomPropertyDrawer(typeof(vec2))]
public class vec2Drawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    var x = property.FindPropertyRelative("x");
    var y = property.FindPropertyRelative("y");
    
    Vector2 val = new Vector2(x.floatValue, y.floatValue);
    val = EditorGUI.Vector2Field(position, label, val);
    
    x.floatValue = val.x;
    y.floatValue = val.y;
  }
}

[CustomPropertyDrawer(typeof(vec3))]
public class vec3Drawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    var x = property.FindPropertyRelative("x");
    var y = property.FindPropertyRelative("y");
    var z = property.FindPropertyRelative("z");
    
    Vector3 val = new Vector3(x.floatValue, y.floatValue, z.floatValue);
    val = EditorGUI.Vector3Field(position, label, val);
    
    x.floatValue = val.x;
    y.floatValue = val.y;
    z.floatValue = val.z;
  }
}

[CustomPropertyDrawer(typeof(vec2i))]
public class vec2iDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    var x = property.FindPropertyRelative("x");
    var y = property.FindPropertyRelative("y");
    
    Vector2Int val = new Vector2Int(x.intValue, y.intValue);
    val = EditorGUI.Vector2IntField(position, label, val);
    
    x.intValue = val.x;
    y.intValue = val.y;
  }
}

[CustomPropertyDrawer(typeof(vec3i))]
public class vec3iDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    var x = property.FindPropertyRelative("x");
    var y = property.FindPropertyRelative("y");
    var z = property.FindPropertyRelative("z");
    
    Vector3Int val = new Vector3Int(x.intValue, y.intValue, z.intValue);
    val = EditorGUI.Vector3IntField(position, label, val);
    
    x.intValue = val.x;
    y.intValue = val.y;
    z.intValue = val.z;
  }
}

[CustomPropertyDrawer(typeof(quat))]
public class quatDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    var x = property.FindPropertyRelative("x");
    var y = property.FindPropertyRelative("y");
    var z = property.FindPropertyRelative("z");
    var w = property.FindPropertyRelative("w");

    Quaternion q = new Quaternion(x.floatValue, y.floatValue, z.floatValue, w.floatValue);
    
    Vector3 euler = q.eulerAngles;
    EditorGUI.BeginChangeCheck();
    euler = EditorGUI.Vector3Field(position, label, euler);
    if (EditorGUI.EndChangeCheck()) {
      Quaternion newQ = Quaternion.Euler(euler);
      x.floatValue = newQ.x;
      y.floatValue = newQ.y;
      z.floatValue = newQ.z;
      w.floatValue = newQ.w;
    }
  }
}
[CustomPropertyDrawer(typeof(btoi))]
public class btoiDrawer : PropertyDrawer {
  public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
    SerializedProperty val = property.FindPropertyRelative("_val");

    if (val != null) {
      EditorGUI.BeginChangeCheck();
      bool newState = EditorGUI.Toggle(position, label, val.boolValue);
      if (EditorGUI.EndChangeCheck()) {
        val.boolValue = newState;
    }
    } else {
        EditorGUI.LabelField(position, label.text, "Error: _val not found");
    }
  }
  public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
    return EditorGUIUtility.singleLineHeight;
  }
}