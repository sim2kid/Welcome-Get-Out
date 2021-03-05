using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

[CustomEditor(typeof(DialogueTree))]
public class DialogueTreeEditor : Editor
{
    private SerializedProperty m_voiceLines;
    private ReorderableList m_ReorderableList;
    private int stringlimit = 64;

    private void OnEnable()
    {
        //Find the list in our ScriptableObject script.
        m_voiceLines = serializedObject.FindProperty("voiceLines");

        //Create an instance of our reorderable list.
        m_ReorderableList = new ReorderableList(serializedObject: serializedObject, elements: m_voiceLines, draggable: true, displayHeader: true,
            displayAddButton: true, displayRemoveButton: true);
        
        //Set up the method callback to draw our list header
        m_ReorderableList.drawHeaderCallback = DrawHeaderCallback;
    
        //Set up the method callback to draw each element in our reorderable list
        m_ReorderableList.drawElementCallback = DrawElementCallback;
    
        //Set the height of each element.
        m_ReorderableList.elementHeightCallback += ElementHeightCallback;
   
        //Set up the method callback to define what should happen when we add a new object to our list.
        m_ReorderableList.onAddCallback += OnAddCallback;
    }

    public override void OnInspectorGUI()
    {
        //Update serialized object's representation.
        serializedObject.Update();

        //Draw the list property we found in the ScriptableObject
        m_ReorderableList.DoLayoutList();

        //Apply any changes made to the serializedObject and flush it's data stream.
        serializedObject.ApplyModifiedProperties();
    }

    private void DrawElementCallback(Rect rect, int index, bool isactive, bool isfocused)
    {
        //Get the element we want to draw from the list.
        SerializedProperty element = m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index);
        rect.y += 2;

        //We get the name property of our element so we can display this in our list.
        SerializedProperty elementName = element.FindPropertyRelative("m_TextLine");
        string elementTitle = string.IsNullOrEmpty(elementName.stringValue)
            ? $"{index}: New Line"
            : $"{index}: \"{elementName.stringValue.Substring(0, (elementName.stringValue.Length>stringlimit + 3) ? stringlimit : elementName.stringValue.Length)}" +
            $"{(elementName.stringValue.Length > stringlimit + 3 ? "..." : "")}\"";

        //Draw the list item as a property field, just like Unity does internally.
        EditorGUI.PropertyField(position:
            new Rect(rect.x += 10, rect.y, Screen.width * .8f, height: EditorGUIUtility.singleLineHeight), property:
            element, label: new GUIContent(elementTitle), includeChildren: true);
    }

    private void OnAddCallback(ReorderableList list)
    {
        //Insert an extra item add the end of our list.
        var index = list.serializedProperty.arraySize;
        list.serializedProperty.arraySize++;
        list.index = index;

        //If we want to do anything with the item we just added,
        //We can create reference by using this method
        var element = list.serializedProperty.GetArrayElementAtIndex(index);
    }

    private float ElementHeightCallback(int index)
    {
        //Gets the height of the element. This also accounts for properties that can be expanded, like structs.
        float propertyHeight = EditorGUI.GetPropertyHeight(m_ReorderableList.serializedProperty.GetArrayElementAtIndex(index), true);

        float spacing = EditorGUIUtility.singleLineHeight / 2;

        return propertyHeight + spacing;
    }

    private void DrawHeaderCallback(Rect rect)
    {
        EditorGUI.LabelField(rect, "Dialogue");
    }
}
