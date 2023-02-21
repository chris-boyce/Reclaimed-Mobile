using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class UIAnim : MonoBehaviour
{
    Vector3 StartPos;
    Vector3 EndPos;
    public bool isBackground = false;
    public AnimationCurve Curve;
    public float SpeedOfAnim = 2f;
    private float ScaleBackground;
    private RectTransform RT;

    //Custom Editor that will add varaible if not applied to a background
    #region Editor
#if UNITY_EDITOR
    [CustomEditor(typeof(UIAnim))]
    public class UIAnimEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            UIAnim _UIAnim = (UIAnim)target;
            bool check = _UIAnim.isBackground;
            if (!check)
            {
                DrawItem(_UIAnim);
            }
        }

        static void DrawItem(UIAnim _UIAnim)
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Animated Object Varaiables");
            EditorGUILayout.BeginHorizontal();
            _UIAnim.StartPos = EditorGUILayout.Vector3Field("Start Pos : ", _UIAnim.StartPos);
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.BeginHorizontal();
            _UIAnim.EndPos = EditorGUILayout.Vector3Field("End Pos : ", _UIAnim.EndPos);
            EditorGUILayout.EndHorizontal();
        }
    }
#endif
    #endregion


    void Start()
    {
        if (isBackground) 
        {
            BackgroundScale();
            BackgroundScroll(); 
        }
        else 
        { 
            RunAnim(); 
        }
    }
    void BackgroundScale()
    {
        RT = GetComponent<RectTransform>();
        ScaleBackground = RT.sizeDelta.x / Screen.width;
        ScaleBackground += 0.1f;
        RT.sizeDelta = new Vector2(RT.sizeDelta.x * ScaleBackground, RT.sizeDelta.y * ScaleBackground);
    }

    void BackgroundScroll()
    {
 
        transform.position = new Vector3(Screen.width / 2, Screen.height - Screen.height * 1.75f, 0);
        LeanTween.moveY(gameObject, Screen.height / 2, SpeedOfAnim).setEase(Curve);
    }    


    void RunAnim()
    {

    }

 
}