using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public int score = 0;    
    public TextMeshProUGUI scoreText;
    public GameObject quackTextPrefab;
    public Canvas canvas;
    public static GameManager GM;
    void Awake()
    {
        GM = this;
        if(SceneManager.GetActiveScene().name == "Level01")
            StartScore(0);
    }

    public void StartGame(){
        SceneChanger.ChangeScene("Level01");
    }

    void StartScore(int amount){
        score = amount;
        UpdateScoreText(score.ToString());
    }
    
    public void UpdateScore(int amount){
        score += amount;
        UpdateScoreText(score.ToString());
    }
    void UpdateScoreText(System.String str){
        scoreText.text = "Score: " + str;
    }
    public void SpawnQuack(){
        if (quackTextPrefab != null && canvas != null)
        {
            // Instantiate the text prefab
            GameObject quackTextInstance = Instantiate(quackTextPrefab, canvas.transform);

            // Set a random position within the canvas
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            RectTransform quackTextRectTransform = quackTextInstance.GetComponent<RectTransform>();

            // Calculate random position within canvas bounds
            float randomX = UnityEngine.Random.Range((-canvasRectTransform.rect.width / 2) , (canvasRectTransform.rect.width / 2) );
            float randomY = UnityEngine.Random.Range((-canvasRectTransform.rect.height / 2) , (canvasRectTransform.rect.height / 2) );
            quackTextRectTransform.anchoredPosition = new Vector2(randomX, randomY);

            // Optionally destroy the text after a certain time
            Destroy(quackTextInstance, 1.5f); // Adjust the duration as needed
        }
        else
        {
            Debug.LogWarning("Quack text prefab or canvas is not assigned.");
        }
    }
}
