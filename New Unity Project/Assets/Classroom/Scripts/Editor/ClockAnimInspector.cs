using UnityEngine;
using UnityEditor;

namespace NeutronCat.Classroom
{
    [CustomEditor(typeof(ClockAnim))]
    public class ClockAnimInspector : Editor
    {

        public override void OnInspectorGUI()
        {
            ClockAnim clockAnim = target as ClockAnim;

            clockAnim.hours = EditorGUILayout.ObjectField("Hours", clockAnim.hours, typeof(Transform), true) as Transform;
            clockAnim.minutes = EditorGUILayout.ObjectField("Minutes", clockAnim.minutes, typeof(Transform), true) as Transform;
            clockAnim.seconds = EditorGUILayout.ObjectField("Seconds", clockAnim.seconds, typeof(Transform), true) as Transform;
            clockAnim.isWorking = EditorGUILayout.Toggle("Is Working", clockAnim.isWorking);
            clockAnim.isNow = EditorGUILayout.Toggle("Is Now", clockAnim.isNow);
            if (!clockAnim.isNow)
            {
                clockAnim.initHours = EditorGUILayout.IntField("Init Hours", clockAnim.initHours);
                clockAnim.initMinutes = EditorGUILayout.IntField("Init Minutes", clockAnim.initMinutes);
                clockAnim.initSeconds = EditorGUILayout.IntField("Init Seconds", clockAnim.initSeconds);
            }
        }
    }
}