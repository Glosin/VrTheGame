using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(TrapController))]
    public class TrapControllerEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            TrapController example = (TrapController)target;
            example.type = (TrapController.Options)EditorGUILayout.EnumPopup("Type:", example.type);

            switch (example.type)
            {
                case TrapController.Options.FlyingBooks:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("books"), true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("direction"), true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("selectedAxis"), true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("audioSource"), true);
                    break;

                case TrapController.Options.Music:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("audioClips"), true);
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("audioSource"), true);
                    break;

                case TrapController.Options.Lights:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("lightLamp"), true);
                    break;

                default:
                    EditorGUILayout.HelpBox("Select an option to see additional fields.", MessageType.Info);
                    break;
            }

            serializedObject.ApplyModifiedProperties();

            if (GUI.changed)
            {
                EditorUtility.SetDirty(example);
            }
        }
    }
}
