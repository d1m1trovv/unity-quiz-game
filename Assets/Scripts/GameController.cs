using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private QuestionLoading questionCollection;
    private Question currentQuestion;
    private UIManager uiController;
    private SceneController sceneLoader;

    [SerializeField]
    private float delayBetweenQuestions;

    private void Awake()
    {
        questionCollection = FindObjectOfType<QuestionLoading>();
        uiController = FindObjectOfType<UIManager>();
        sceneLoader = FindObjectOfType<SceneController>();
    }

    private void Start()
    {
        PresentQuestion();
    }

    private void Update()
    {
        if(uiController.CheckTimer())
        {
            PresentQuestion();
        }

        uiController.UpdateTimer();
    }

    private void PresentQuestion()
    {
        if (!questionCollection.CheckIfAllHaveBeenAsked())
        {
            uiController.SetUpCurrentTime();
            currentQuestion = questionCollection.GetUnaskedQuestion();
            uiController.SetupUIForQuestion(currentQuestion);
            uiController.StartTimer();
            Update();
            //StartCoroutine(ShowNextQuestionAfterTimerEnds());
        }
        else
        {
            uiController.ShowEndGamePopup();
        }
    }

    public void SubmitAnswer(int answerNumber)
    {
        //uiController.StopTimer();
        bool isCorrect = answerNumber == currentQuestion.CorrectAnswer;
        uiController.HandleSubmittedAnswer(isCorrect);
     
        StartCoroutine(ShowNextQuestionAfterDelay());
    }

    private IEnumerator ShowNextQuestionAfterDelay()
    {
        uiController.StopTimer();
        yield return new WaitForSeconds(delayBetweenQuestions);
        PresentQuestion();
    }

    public void ReloadGame()
    {
        uiController.ResetScore();
        questionCollection.ResetIfAllQuestionsHaveBeenAsked();
        PresentQuestion();
    }
}
