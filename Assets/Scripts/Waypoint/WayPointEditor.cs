using UnityEditor;
using UnityEngine;


[CustomEditor(typeof(WayPoint))]
    public class WayPointEditor : Editor
    {
        private WayPoint wayPointTarget => target as WayPoint;

        private void OnSceneGUI()
        {
            if (wayPointTarget.Points.Length <= 0f) return;

            Handles.color = Color.red;

            for (int i = 0; i < wayPointTarget.Points.Length; i++)
            {
                EditorGUI.BeginChangeCheck();

                Vector3 currentPosition = wayPointTarget.entityPosition + wayPointTarget.Points[i];
                Vector3 newPosition = Handles.FreeMoveHandle(currentPosition, 0.5f, Vector3.one * 0.5f, Handles.SphereHandleCap);

                GUIStyle textStyle = new GUIStyle();
                textStyle.fontStyle =  FontStyle.Bold;
                textStyle.normal.textColor = Color.black;
                textStyle.fontSize = 16;
                Vector3 textPosition = new Vector3(0.2f, -0.2f);
                Handles.Label(wayPointTarget.entityPosition + wayPointTarget.Points[i] + textPosition, $"{i + 1}", textStyle);
                
                if (EditorGUI.EndChangeCheck())
                {
                    Undo.RecordObject(wayPointTarget, "Free Move");
                    wayPointTarget.Points[i] = newPosition - wayPointTarget.entityPosition;
                }
            }
        }
    }
