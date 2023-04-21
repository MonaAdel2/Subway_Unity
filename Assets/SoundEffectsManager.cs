using UnityEngine;

public class SoundEffectsManager : MonoBehaviour
{
    [SerializeField] AudioClip coin;
    [SerializeField] AudioClip levelUp;
    [SerializeField] AudioClip jump;
    [SerializeField] AudioClip death;
    [SerializeField] AudioClip button;
    [SerializeField] AudioClip gameOver;

    AudioSource audioSource;
    [SerializeField] [Range(0 , 1)] float volume = 1;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void playCoinSound()
    {
        audioSource.PlayOneShot(coin , volume);
    }
    public void playLevelUpSound()
    {
        audioSource.PlayOneShot(levelUp , volume);
    }
    public void playJumpSound()
    {
        audioSource.PlayOneShot(jump , volume);
    }
    public void playDeathSound()
    {
        audioSource.PlayOneShot(death , volume);
    }
    public void playClickButtonSound()
    {
        audioSource.PlayOneShot(button , volume);
    }
    public void playGameOverSound()
    {
        audioSource.PlayOneShot(gameOver , volume);
    }
       
}
