using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestionLoading : MonoBehaviour
{
    private Question[] allQuestions;

    private void Awake()
    {
        LoadAllQuestions();
    }

    private void LoadAllQuestions()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if(currentScene.name == "AnimalsScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/AnimalsQuestions");
        }

        else if (currentScene.name == "FruitsScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/FruitsQuestions");
        }

        else if (currentScene.name == "VegetablesScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/VegetablesQuestions");
        }

        else if (currentScene.name == "CarsScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/CarsQuestions");
        }

        else if (currentScene.name == "ItemsScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/ItemsQuestions");
        }

        else if (currentScene.name == "CountriesScene")
        {
            allQuestions = Resources.LoadAll<Question>("Questions/CountriesQuestions");
        }

    }

    public Question GetUnaskedQuestion()
    {
        var question = allQuestions
            .Where(t => t.QuestionAsked == false)
            .OrderBy(t => Random.Range(0, int.MaxValue))
            .FirstOrDefault();

        question.QuestionAsked = true;
        return question;
    }

    public bool CheckIfAllHaveBeenAsked()
    {
        if (allQuestions.Any(t => t.QuestionAsked == false) == false)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ResetIfAllQuestionsHaveBeenAsked()
    {
        if (allQuestions.Any(t => t.QuestionAsked == false) == false)
        {
            ResetQuestions();
        }
    }

    private void ResetQuestions()
    {
        foreach (var question in allQuestions)
            question.QuestionAsked = false;
    }
}
