using UnityEditor;
using UnityEngine;

public static class EditorList
{
    public static void Show(SerializedProperty list)
    {
        //EditorGUILayout.LabelField(list.displayName);
        //list.isExpanded = EditorGUILayout.Toggle(list.isExpanded);


        bool showPosition = true;
        string status = "Select a GameObject";

        showPosition = EditorGUILayout.BeginFoldoutHeaderGroup(showPosition, status, null, ShowHeaderContextMenu);

        if (showPosition)
            if (Selection.activeTransform)
            {
                Selection.activeTransform.position =
                    EditorGUILayout.Vector3Field("Position", Selection.activeTransform.position);
                status = Selection.activeTransform.name;
            }

        if (!Selection.activeTransform)
        {
            status = "Select a GameObject";
            showPosition = false;
        }
        // End the Foldout Header that we began above.
        EditorGUILayout.EndFoldoutHeaderGroup();

        void ShowHeaderContextMenu(Rect position)
        {
            var menu = new GenericMenu();
            menu.AddItem(new GUIContent("Move to (0,0,0)"), false, OnItemClicked);
            menu.DropDown(position);
        }

        void OnItemClicked()
        {
            Undo.RecordObject(Selection.activeTransform, "Moving to center of world");
            Selection.activeTransform.position = Vector3.zero;
        }

        //EditorGUI.indentLevel += 1;
        //if (list.isExpanded)
        //{
        //    EditorGUILayout.PropertyField(list.FindPropertyRelative("Array.size"));
        //    for (int i = 0; i < list.arraySize; i++)
        //    {
        //        EditorGUILayout.PropertyField(list.GetArrayElementAtIndex(i));
        //    }
        //}
        //EditorGUI.indentLevel -= 1;
    }

    //public class FoldoutHeaderUsage : EditorWindow
    //{
    //    bool showPosition = true;
    //    string status = "Select a GameObject";

    //    [MenuItem("Examples/Foldout Header Usage")]
    //    static void CreateWindow()
    //    {
    //        GetWindow<FoldoutHeaderUsage>();
    //    }

    //    public void OnGUI()
    //    {
    //        showPosition = EditorGUILayout.BeginFoldoutHeaderGroup(showPosition, status, null, ShowHeaderContextMenu);

    //        if (showPosition)
    //            if (Selection.activeTransform)
    //            {
    //                Selection.activeTransform.position =
    //                    EditorGUILayout.Vector3Field("Position", Selection.activeTransform.position);
    //                status = Selection.activeTransform.name;
    //            }

    //        if (!Selection.activeTransform)
    //        {
    //            status = "Select a GameObject";
    //            showPosition = false;
    //        }
    //        // End the Foldout Header that we began above.
    //        EditorGUILayout.EndFoldoutHeaderGroup();
    //    }

    //    void ShowHeaderContextMenu(Rect position)
    //    {
    //        var menu = new GenericMenu();
    //        menu.AddItem(new GUIContent("Move to (0,0,0)"), false, OnItemClicked);
    //        menu.DropDown(position);
    //    }

    //    void OnItemClicked()
    //    {
    //        Undo.RecordObject(Selection.activeTransform, "Moving to center of world");
    //        Selection.activeTransform.position = Vector3.zero;
    //    }
    //}
}