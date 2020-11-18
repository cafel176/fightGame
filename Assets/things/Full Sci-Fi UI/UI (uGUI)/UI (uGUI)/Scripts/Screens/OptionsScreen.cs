using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace K2Games
{
    public class OptionsScreen : MonoBehaviour
    {
        public static OptionsScreen Instance;

        public TransitionalObject mainTransition;

        public Text musicVolumeLabel, soundEffectsVolumeLabel;
        public Slider musicVolumeSlider, soundEffectsVolumeSlider;
        public Animator closeButton;//needed to kill the animations so the transitional object can edit the images

        void Start()
        {
            Instance = this;
            gameObject.SetActive(false);
            closeButton.enabled = false;
        }

        public void Show()
        {
            gameManager.instance.pause(true);
            musicVolumeSlider.value = gameManager.instance.music;
            musicVolumeLabel.text = Mathf.RoundToInt(musicVolumeSlider.value) + "%";
            soundEffectsVolumeSlider.value = gameManager.instance.SE;
            soundEffectsVolumeLabel.text = Mathf.RoundToInt(soundEffectsVolumeSlider.value) + "%";
            mainTransition.TriggerTransition();
            MainMenu.Instance.Minimise();
        }

        public void Close()
        {
            gameManager.instance.pause(false);
            mainTransition.TriggerFadeOut();
            MainMenu.Instance.Show();
            PlayerPrefs.SetFloat("se",gameManager.instance.SE);
            PlayerPrefs.SetFloat("music", gameManager.instance.music);
            closeButton.enabled = false;
        }

        /// <summary>
        /// Called once the transitions have finished to allow user input
        /// </summary>
        public void EnableButtonPresses()
        {
            closeButton.enabled = true;
            closeButton.Play("Highlighted");
        }

        public void SetMusicVolume()
        {
            musicVolumeLabel.text = Mathf.RoundToInt(musicVolumeSlider.value) + "%";
            gameManager.instance.setMusicVolume(musicVolumeSlider.value);
            //Set music volume here!
        }

        public void SetSoundEffectsVolume()
        {
            soundEffectsVolumeLabel.text = Mathf.RoundToInt(soundEffectsVolumeSlider.value) + "%";
            gameManager.instance.setSEVolume(soundEffectsVolumeSlider.value);
            //Set sound effects volume here!
        }
    }
}