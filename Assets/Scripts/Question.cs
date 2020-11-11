using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu]
public class Question : ScriptableObject
{
    [SerializeField]
    private Sprite questionImage;
    public Sprite QuestionImage { get { return questionImage; } }

    [SerializeField]
    private string questionText;
    public string QuestionText { get { return questionText; } }

    [SerializeField]
    private string time;
    public string Time { get { return time; } }

    [SerializeField]
    private string[] answers;
    public string[] Answers { get { return answers; } }

    [SerializeField]
    private int correctAnswer;
    public int CorrectAnswer { get { return correctAnswer; } }

    public bool QuestionAsked { get; internal set; }

    private void OnValidate()
    {
        if (correctAnswer > answers.Length)
        {
            correctAnswer = 0;
        }

        RenameScriptableObjectToMatchQuestionAndAnswer();
    }

    private void RenameScriptableObjectToMatchQuestionAndAnswer()
    {
        string desiredName = string.Format("{0} [{1}]",
            questionText.Replace("?", ""),
            answers[correctAnswer]);

        string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
        string shouldEndWith = "/" + desiredName + ".asset";
        if (assetPath.EndsWith(shouldEndWith) == false)
        {
            Debug.Log("Want to rename to " + desiredName);
            AssetDatabase.RenameAsset(assetPath, desiredName);
            AssetDatabase.SaveAssets();
        }
    }
}

