using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using UnityEditor.AnimatedValues;

public class GUIHelper
{
    public enum LayoutStyle
    {
        Defualt = 0, Box, Button, TextArea, Window, Textfield,
        HorizontalScrollbar,//Fixed height
        Label,//No Style
        Toggle, //Just puts a non usable CB to the left 
        Toolbar,//Fixed height
        PreToolbar2,
        scrollView
    }

    public static void ArrayGUI(SerializedObject instance, string name)
    {
        ArrayGUI(instance, instance.FindProperty(name));
    }

    public static void ArrayGUI(SerializedObject instance, SerializedProperty array)
    {
        EditorGUI.BeginChangeCheck();
        EditorGUILayout.PropertyField(array, true);

        if(EditorGUI.EndChangeCheck())
            instance.ApplyModifiedProperties();

        EditorGUIUtility.LookLikeControls();
    }

    public static void DrawToggle(AnimBool animation, GUIContent content, float spacing)
    {
        GUI.contentColor = EditorGUIUtility.isProSkin ? new Color(1f, 1f, 1f, 0.7f) : new Color(0f, 0f, 0f, 0.85f);//change the colour of the heading to get it to stand out

        if(!GUILayout.Toggle(true, content, "PreToolbar2", GUILayout.Width(spacing), GUILayout.MinWidth(20f)))
            animation.target = !animation.target;//invert

        GUI.contentColor = Color.white;
    }
}

/// <summary>
/// A helper to make horizontal groups easier
/// </summary>
public class Horizontal : IDisposable
{
    public Horizontal()
    {
        EditorGUILayout.BeginHorizontal();
    }

    public Horizontal(params GUILayoutOption[] options)
    {
        EditorGUILayout.BeginHorizontal(options);
    }

    public void Dispose()
    {
        EditorGUILayout.EndHorizontal();
    }
}

/// <summary>
/// A helper to make vertical groups easier
/// </summary>
public class Vertical : IDisposable
{
    public Vertical()
    {
        EditorGUILayout.BeginVertical();
    }

    public Vertical(GUIHelper.LayoutStyle style)
    {
        EditorGUILayout.BeginVertical(style.ToString());
    }

    public Vertical(params GUILayoutOption[] options)
    {
        EditorGUILayout.BeginVertical(options);
    }

    public void Dispose()
    {
        EditorGUILayout.EndVertical();
    }
}

/// <summary>
/// A helper to make colour changes easier
/// </summary>
public class ColourChange : IDisposable
{
    public ColourChange(Color colour)
    {
        GUI.color = colour;
    }

    public void Dispose()
    {
        GUI.color = Color.white;
    }
}

//FixedWidthLabel class. Extends IDisposable, so that it can be used with the "using" keyword.
public class FixedWidthLabel : IDisposable
{
    private readonly ZeroIndent indentReset; //helper class to reset and restore indentation

    public FixedWidthLabel(GUIContent label, params GUILayoutOption[] options)
        : this(label, null, options)
    {

    }

    public FixedWidthLabel(GUIContent label, GUIStyle labelStyle, params GUILayoutOption[] options)//	constructor.
    {//						state changes are applied here.
        EditorGUILayout.BeginHorizontal(options);// create a new horizontal group

        if(labelStyle != null)
            EditorGUILayout.LabelField(label, labelStyle,
                GUILayout.Width(GUI.skin.label.CalcSize(label).x +// actual label width
                    9 * EditorGUI.indentLevel));//indentation from the left side. It's 9 pixels per indent level
        else
            EditorGUILayout.LabelField(label,
                 GUILayout.Width(GUI.skin.label.CalcSize(label).x +// actual label width
                     9 * EditorGUI.indentLevel));//indentation from the left side. It's 9 pixels per indent level

        indentReset = new ZeroIndent();//helper class to have no indentation after the label
    }

    public FixedWidthLabel(string label)       //alternative constructor, if we don't want to deal with GUIContents
    {
        EditorGUILayout.BeginHorizontal();// create a new horizontal group

        GUIContent labelContent = new GUIContent(label);

        EditorGUILayout.LabelField(labelContent,
            GUILayout.Width(GUI.skin.label.CalcSize(labelContent).x +// actual label width
                9 * EditorGUI.indentLevel));//indentation from the left side. It's 9 pixels per indent level

        indentReset = new ZeroIndent();//helper class to have no indentation after the label
    }

    public void Dispose() //restore GUI state
    {
        indentReset.Dispose();//restore indentation
        EditorGUILayout.EndHorizontal();//finish horizontal group
    }
}

public class ZeroIndent : IDisposable //helper class to clear indentation
{
    private readonly int originalIndent;//the original indentation value before we change the GUI state
    public ZeroIndent()
    {
        originalIndent = EditorGUI.indentLevel;//save original indentation
        EditorGUI.indentLevel = 0;//clear indentation
    }

    public void Dispose()
    {
        EditorGUI.indentLevel = originalIndent;//restore original indentation
    }
}