using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomPropertyDrawer(typeof(Character))]
public class CharacterPropertyDrawer : PropertyDrawer {


    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {

        EditorGUI.BeginProperty(position, label, property);
        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);
        int indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
        Rect charRect= new Rect(position.x, position.y, 30, position.height);
        Rect spriteRect = new Rect(position.x + 35, position.y, 150, position.height);
        EditorGUI.PropertyField(charRect, property.FindPropertyRelative("c"), GUIContent.none);
        EditorGUI.PropertyField(spriteRect,property.FindPropertyRelative("texture"), GUIContent.none);
        EditorGUI.indentLevel = indent;
        EditorGUI.EndProperty();



    }
}
