using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public static void ChangeScene(string sceneName){
        SceneManager.LoadScene(sceneName);
    }

    public static void ExitGame() {
        // Oyun sonlandırma kodu
        Application.Quit();

        // Unity Editor'da oyun modunu sonlandırmak için (editörde çalıştırırken)
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
