using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Utilites
{
    public static int playerDeaths = 0;

    public static string UpdateDeathCount(ref int countReference)
    {
        countReference += 1;
        return countReference.ToString();
    }


    public static void RestartLevel()
    {
       Debug.Log("Player Deaths: " + playerDeaths);
       UpdateDeathCount(ref playerDeaths);
       Debug.Log("Player Deaths: " + playerDeaths);
    }

    public static bool RestartLevel(int SceneIndex)
    {
        SceneManager.LoadScene(SceneIndex);
        Time.timeScale = 1.0f;
        return true;
    }
}
