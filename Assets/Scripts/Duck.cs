using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Duck : MonoBehaviour
{
    // Animation
    public Animator animator;    
    public string animationTriggerName = "Clicked";
    public string animationStateName = "Base Layer.duck_idle"; // The state to revert to after the click animation
    public string animationBoolName = "isAnimating";
    
    // Audio
    public AudioClip clickSound;
    private AudioSource audioSource;
    private bool isAnimating = false;
    
    // Score
    public int score = 0;    
    public TextMeshProUGUI scoreText;
    public GameObject quackTextPrefab;
    public Canvas canvas;
    
    // Cursor Change 
    public Texture2D onHoverCursor;
    public Texture2D clickCursor;
    public Texture2D defaultCursor;

    // GameManager
    public GameManager GM;
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

    // Changes cursor when hovering on the duck
    // void OnMouseEnter(){
    //      Cursor.SetCursor(onHoverCursor, Vector2.zero, CursorMode.Auto);
    // }
    // void OnMouseExit(){
    //     Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    // }
    // void OnMouseUp(){
    //     Cursor.SetCursor(onHoverCursor, Vector2.zero, CursorMode.Auto);
    // }
    void OnMouseDown()
    {
        // Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
        if (GM.isExitPanelActive) return;
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
        GM.SpawnQuack();
        // Add 1 to curr score
        GM.UpdateScore(1);
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
}
