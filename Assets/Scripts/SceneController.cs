using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadAnimalsScene()
    {
        SceneManager.LoadScene("AnimalsScene");
    }

    public void LoadFruitsScene()
    {
        SceneManager.LoadScene("FruitsScene");
    }

    public void LoadVegetablesScene()
    {
        SceneManager.LoadScene("VegetablesScene");
    }

    public void LoadCarsScene()
    {
        SceneManager.LoadScene("CarsScene");
    }

    public void LoadItemsScene()
    {
        SceneManager.LoadScene("ItemsScene");
    }

    public void LoadCountriesScene()
    {
        SceneManager.LoadScene("CountriesScene");
    }

    public void LoadHomeScene()
    {
        SceneManager.LoadScene("HomeScreenScene");
    }
}
