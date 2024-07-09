using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Duck : MonoBehaviour
{
    public Animator animator;
    public AudioClip clickSound; // Assign this in the Inspector
    public TextMeshProUGUI scoreText;
    public string animationTriggerName = "Clicked";
    public string animationStateName = "Base Layer.duck_idle"; // The state to revert to after the click animation
    public string animationBoolName = "isAnimating";

    
    public int score = 0;    

    public GameObject quackTextPrefab;
    public Canvas canvas;

    private AudioSource audioSource;
    private bool isAnimating = false;

    void Start()
    {
        // Add an AudioSource component if it doesn't exist
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Assign the AudioClip to the AudioSource
        if (clickSound != null)
        {
            audioSource.clip = clickSound;
        }
        else
        {
            Debug.LogWarning("Click sound is not assigned.");
        }
        // Start default score text
        scoreText.text = "Score: "+score.ToString();
    }

    void OnMouseDown()
    {

        if (!isAnimating && audioSource.clip != null)
        {
            isAnimating = true;
            animator.SetBool(animationBoolName, isAnimating);
            // Trigger the "Quack" animation
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
            }
            
            // Play the sound
            audioSource.Play();
            StartCoroutine(WaitForSoundAndReset(audioSource.clip.length));
        }
        // FX when on click
        SpawnQuack();
        // Add 1 to curr score
        UpdateScore(1);     
    }

    private IEnumerator WaitForSoundAndReset(float duration)
    {
        yield return new WaitForSeconds(1);
        
        // Reset the animation state
        // if (animator != null)
        // {
        //     animator.Play(animationStateName, 0, 0f);
        // }
        
        // Return to idle animation
        isAnimating = false;
        animator.SetBool(animationBoolName, isAnimating);
        
        // Bug fix for spammed click results unnecessary animation
        animator.ResetTrigger(animationTriggerName);
    }

    private void SpawnQuack(){
        if (quackTextPrefab != null && canvas != null)
        {
            // Instantiate the text prefab
            GameObject quackTextInstance = Instantiate(quackTextPrefab, canvas.transform);

            // Set a random position within the canvas
            RectTransform canvasRectTransform = canvas.GetComponent<RectTransform>();
            RectTransform quackTextRectTransform = quackTextInstance.GetComponent<RectTransform>();

            // Calculate random position within canvas bounds
            float randomX = Random.Range((-canvasRectTransform.rect.width / 2) , (canvasRectTransform.rect.width / 2) );
            float randomY = Random.Range((-canvasRectTransform.rect.height / 2) , (canvasRectTransform.rect.height / 2) );
            quackTextRectTransform.anchoredPosition = new Vector2(randomX, randomY);

            // Optionally destroy the text after a certain time
            Destroy(quackTextInstance, 1.5f); // Adjust the duration as needed
        }
        else
        {
            Debug.LogWarning("Quack text prefab or canvas is not assigned.");
        }
    }
    public void UpdateScore(int point){
        score += point;
        scoreText.text = "Score: "+score.ToString();
    }
}
