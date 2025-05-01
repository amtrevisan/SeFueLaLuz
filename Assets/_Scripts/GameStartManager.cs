using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStartManager : MonoBehaviour
{
    public Light[] startingLights;
    public float lightDelay = 1f;
    public AudioSource powerDownSFX;
    public MonoBehaviour player; 
    public GameObject flashlight;
    public AudioSource creepyMusicSource;

    void Start()
    {
        // Lights on at start
        foreach (Light l in startingLights)
            l.enabled = true;

        // Disable player control
        if (player != null)
            player.enabled = false;

        // Disable flashlight
        if (flashlight != null)
            flashlight.SetActive(false);

        // Start intro sequence
        Invoke(nameof(TriggerBlackout), lightDelay);
    }

    void TriggerBlackout()
    {
        // Turn off lights
        foreach (Light l in startingLights)
            l.enabled = false;

        // Play power-down sound
        if (powerDownSFX != null)
            powerDownSFX.Play();

        // Enable player control
        if (player != null)
            player.enabled = true;

        // Enable flashlight
        if (flashlight != null)
            flashlight.SetActive(true);
        
        // Creepy Music
        if (creepyMusicSource != null && !creepyMusicSource.isPlaying)
        creepyMusicSource.Play();
        }

    public static void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}