using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float startingTime = 15f;
    float currentTime = 0f;
    bool stopTimer = true;
    int scoreText = 0;

    [SerializeField]
    private Text questionText;
    [SerializeField]
    private GameObject questionImage;
    [SerializeField]
    private Button[] answerButtons;
    [SerializeField]
    private Text score;
    [SerializeField]
    private Text timer;

    [SerializeField]
    private GameObject correctAnswerPopup;
    [SerializeField]
    private GameObject wrongAnswerPopup;
    [SerializeField]
    private GameObject endGamePopup;
    [SerializeField]
    private Text finalScore;

    public void SetupUIForQuestion(Question question)
    {
        correctAnswerPopup.SetActive(false);
        wrongAnswerPopup.SetActive(false);
        questionImage.SetActive(true);
        endGamePopup.SetActive(false);
        //questionImage.gameObject.SetActive(false);

        questionText.text = question.QuestionText;
        questionImage.GetComponent<Image>().sprite = question.QuestionImage;
        //timer.text = question.Time;

        for (int i = 0; i < question.Answers.Length; i++)
        {
            answerButtons[i].GetComponentInChildren<Text>().text = question.Answers[i];
            answerButtons[i].gameObject.SetActive(true);
            questionImage.SetActive(true);
        }

        for (int i = question.Answers.Length; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(false);
        }
    }

    public void HandleSubmittedAnswer(bool isCorrect)
    {
        ToggleAnswerButtons(false);
        if (isCorrect)
        {
            UpdateScore();
            ShowCorrectAnswerPopup();
        }
        else
        {
            ShowWrongAnswerPopup();
        }
    }

    private void ToggleAnswerButtons(bool value)
    {
        for (int i = 0; i < answerButtons.Length; i++)
        {
            answerButtons[i].gameObject.SetActive(value);
        }
    }

    private void ShowCorrectAnswerPopup()
    {
        correctAnswerPopup.SetActive(true);
        questionImage.SetActive(false);
    }

    private void ShowWrongAnswerPopup()
    {
        wrongAnswerPopup.SetActive(true);
        questionImage.SetActive(false);
    }

    public void ShowEndGamePopup()
    {
        endGamePopup.SetActive(true);
    }

    public void ResetScore()
    {
        scoreText = 0;
        score.text = scoreText.ToString();
    }

    public void SetUpCurrentTime()
    {
        currentTime = startingTime;
    }

    public void UpdateTimer()
    {
        timer.color = Color.blue;
        currentTime -= 1 * Time.deltaTime;
        //timer.text = currentTime.ToString("0");

        if(currentTime <= 5)
        {
            timer.fontSize = 50;
            timer.color = Color.red;
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            stopTimer = true;
        }
    }

    public void StopTimer()
    {
        stopTimer = true;
    }

    public void StartTimer()
    {
        stopTimer = false;
        StartCoroutine(updateCoroutine());
    }

    private IEnumerator updateCoroutine()
    {
        while (!stopTimer)
        {
            timer.text = currentTime.ToString("0");
            yield return new WaitForSeconds(0.2f);
        }
    }

    public bool CheckTimer()
    {
        if(currentTime == 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void UpdateScore()
    {
        scoreText += 100;
        score.text = scoreText.ToString();
        finalScore.text = scoreText.ToString();
    }

}
