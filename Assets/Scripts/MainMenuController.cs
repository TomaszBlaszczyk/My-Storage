using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Canvas mainMenuCanvas;
    public Canvas levelCanvas;
    public Canvas playCanvas;
    public Canvas optionsCanvas;
    public Canvas storeCanvas;

    public Canvas challenge_1;
    public Canvas challenge_2;
    public Canvas challenge_3;

    public Image musicImage;
    public Image soundsImage;

    public Sprite musicON;
    public Sprite musicOFF;
    public Sprite soundsON;
    public Sprite soundsOFF;

    private bool musicActive = true;
    private bool soundsActive = true;

    public AudioSource musicAudioSource;
    public AudioSource soundsAudioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    void Start()
    {
        mainMenuCanvas.enabled = true;  //Aktywne okno głównego menu
        levelCanvas.enabled = false;
        optionsCanvas.enabled = false;
        storeCanvas.enabled = false;
        playCanvas.enabled = false;
        challenge_1.enabled = false;
        challenge_2.enabled = false;
        challenge_3.enabled = false;

        MusicAndSounds();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChooseLevelButton()
    {
        mainMenuCanvas.enabled = false;
        levelCanvas.enabled = true;      //Aktywny ekran wyboru poziomu
        optionsCanvas.enabled = false;
        storeCanvas.enabled = false;
    }

    public void PlayButton()
    {
        playCanvas.enabled = true;      //Aktywny wybór typu wyzwania
        levelCanvas.enabled = false;
    }

    public void OptionsButton()
    {
        mainMenuCanvas.enabled = false;
        levelCanvas.enabled = false;
        optionsCanvas.enabled = true;   //Aktywne opcje
        storeCanvas.enabled = false;
    }

    public void StoreButton()
    {
        mainMenuCanvas.enabled = false;
        levelCanvas.enabled = false;
        optionsCanvas.enabled = false;
        storeCanvas.enabled = true;     //Aktywny sklep
    }

    public void BackButton()
    {
        if(playCanvas.enabled == true)
        {
            playCanvas.enabled = false;
            levelCanvas.enabled = true;
            challenge_1.enabled = false;
            challenge_2.enabled = false;
            challenge_3.enabled = false;
        }
        else
        {
            mainMenuCanvas.enabled = true;  //Ponownie aktywowane jedynie okno głównego menu
            levelCanvas.enabled = false;
            optionsCanvas.enabled = false;
            storeCanvas.enabled = false;
        }       
    }

    public void ChallengeType_1()
    {
        PlayerPrefs.SetInt("Challenge Type", 1);
        challenge_1.enabled = true;
        challenge_2.enabled = false;
        challenge_3.enabled = false;
    }
    public void ChallengeType_2()
    {
        PlayerPrefs.SetInt("Challenge Type", 2);
        challenge_1.enabled = false;
        challenge_2.enabled = true;
        challenge_3.enabled = false;
    }
    public void ChallengeType_3()
    {
        PlayerPrefs.SetInt("Challenge Type", 3);
        challenge_1.enabled = false;
        challenge_2.enabled = false;
        challenge_3.enabled = true;
    }

    public void Time_2()
    {
        PlayerPrefs.SetInt("Time", 2);
    }
    public void Time_5()
    {
        PlayerPrefs.SetInt("Time", 5);
    }
    public void Time_10()
    {
        PlayerPrefs.SetInt("Time", 10);
    }

    public void Objects_10()
    {
        PlayerPrefs.SetInt("Objects", 10);
    }
    public void Objects_20()
    {
        PlayerPrefs.SetInt("Objects", 20);
    }
    public void Objects_40()
    {
        PlayerPrefs.SetInt("Objects", 40);
    }

    public void Points_2000()
    {
        PlayerPrefs.SetInt("Points", 2000);
    }
    public void Points_5000()
    {
        PlayerPrefs.SetInt("Points", 5000);
    }
    public void Points_10000()
    {
        PlayerPrefs.SetInt("Points", 10000);
    }

    public void ToLevel_1()
    {
        SceneManager.LoadScene(1);  //Przekierowanie do ekranu ładowania
    }

    public void MusicButton()
    {
        musicActive = !musicActive;     //Zmiana stanu muzyki na stan przeciwny
        MusicAndSounds();
    }

    public void SoundsButton()
    {
        soundsActive = !soundsActive;   //Zmiana stanu dźwięków na stan przeciwny
        MusicAndSounds();
    }

    public void MusicAndSounds()    //Włączanie i wyłączanie muzyki i dźwieków + podmiana ikon na przyciskach
    {
        if(musicActive == true)
        {
            musicAudioSource.mute = false;
            musicImage.sprite = musicON;
        }
        else
        {
            musicAudioSource.mute = true;
            musicImage.sprite = musicOFF;
        }

        if(soundsActive == true)
        {
            soundsAudioSource.mute = false;
            soundsImage.sprite = soundsON;
        }
        else
        {
            soundsAudioSource.mute = true;
            soundsImage.sprite = soundsOFF;
        }
    }
}
