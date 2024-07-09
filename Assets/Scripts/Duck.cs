using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duck : MonoBehaviour
{
    public Animator animator;
    public AudioClip clickSound; // Assign this in the Inspector
    public string animationTriggerName = "Clicked";
    public string animationStateName = "Idle"; // The state to revert to after the click animation
    public string animationBoolName = "isAnimating";

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
    }

    void OnMouseDown()
    {

        if (!isAnimating && audioSource.clip != null)
        {
            isAnimating = true;
            animator.SetBool(animationBoolName, isAnimating);
            // Trigger the animation
            if (animator != null)
            {
                animator.SetTrigger(animationTriggerName);
            }

            // Play the sound
            audioSource.Play();
            StartCoroutine(WaitForSoundAndReset(audioSource.clip.length));
        }
    }

    private IEnumerator WaitForSoundAndReset(float duration)
    {
        yield return new WaitForSeconds(1);

        // Reset the animation state
        if (animator != null)
        {
            animator.Play(animationStateName, 0, 0f);
        }

        isAnimating = false;
        animator.SetBool(animationBoolName, isAnimating);
    }
}
