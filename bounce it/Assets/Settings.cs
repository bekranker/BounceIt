using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.Audio;


public class Settings : MonoBehaviour
{
    [SerializeField] private ButtonEffect _MusicButton;
    [SerializeField] private ButtonEffect _SoundButton;
    [SerializeField] private AudioMixer _AudioMixer;
    [SerializeField] private float MusicStartVolume, SoundStartVolume;
    [SerializeField] private Image SoundImage, MusicImage;
    [SerializeField] private Sprite SoundSprite, MusicSprite, MutedSoundSprite, MutedMusicSprite;
    private bool _didMuteMusic, _didMuteSound;
    private Canvas _canvas;


    private void Awake()
    {
        

        #region Singelton
        List<Settings> me = FindObjectsOfType<Settings>().ToList();


        if (me != null)
        {
            for (int i = 0; i < me.Count; i++)
            {

                print(me[i].name);

                if (me[i] != this)
                    Destroy(transform.parent);
                else
                    DontDestroyOnLoad(transform.parent);
            }
        }
        else
            DontDestroyOnLoad(transform.parent);
        #endregion
    }

    private void Start()
    {
        _canvas = transform.parent.GetComponent<Canvas>();
        _canvas.renderMode = RenderMode.ScreenSpaceCamera;
        _canvas.worldCamera = Camera.main;

        CheckMusic();
        CheckSound();

        _MusicButton._doClick = SetMusic;
        _SoundButton._doClick = SetSound;
    }



    public void SetSound()
    {
        _didMuteSound = !_didMuteSound;


        if (_didMuteSound)
        {
            SoundImage.sprite = MutedSoundSprite;
            _AudioMixer.SetFloat("Sound", -80);
            PlayerPrefs.SetString("Muted Sound", "Muted Sound");
        }
        else
        {
            SoundImage.sprite = SoundSprite;
            _AudioMixer.SetFloat("Sound", SoundStartVolume);

            PlayerPrefs.DeleteKey("Muted Sound");
        }

    }

    public void SetMusic()
    {
        _didMuteMusic = !_didMuteMusic;

        if (_didMuteMusic)
        {
            MusicImage.sprite = MutedMusicSprite;
            _AudioMixer.SetFloat("Music", -80);
            PlayerPrefs.SetString("Muted Music", "Muted Music");
        }
        else
        {
            MusicImage.sprite = MusicSprite;
            _AudioMixer.SetFloat("Music", MusicStartVolume);
            if (PlayerPrefs.HasKey("Muted Music"))
                PlayerPrefs.DeleteKey("Muted Music");
        }

    }
    private void CheckMusic()
    {
        if (PlayerPrefs.HasKey("Music Volume"))
        {
            if (PlayerPrefs.HasKey("Muted Music"))
            {
                _AudioMixer.SetFloat("Music", -80);
                MusicImage.sprite = MutedMusicSprite;
                _didMuteMusic = !_didMuteMusic;
            }
            else
            {
                MusicImage.sprite = MusicSprite;
                _AudioMixer.SetFloat("Music", PlayerPrefs.GetFloat("Music Volume"));
            }
        }
        else
        {
            _AudioMixer.SetFloat("Music", MusicStartVolume);
            PlayerPrefs.SetFloat("Music Volume", MusicStartVolume);
        }

    }

    private void CheckSound()
    {
        if (PlayerPrefs.HasKey("Sound Volume"))
        {
            if (PlayerPrefs.HasKey("Muted Sound"))
            {
                _AudioMixer.SetFloat("Sound", -80);
                SoundImage.sprite = MutedSoundSprite;
                _didMuteSound = !_didMuteSound;
            }
            else
            {
                SoundImage.sprite = SoundSprite;
                _AudioMixer.SetFloat("Sound", PlayerPrefs.GetFloat("Sound Volume"));
            }
        }
        else
        {
            _AudioMixer.SetFloat("Sound", SoundStartVolume);
            PlayerPrefs.SetFloat("Sound Volume", SoundStartVolume);
        }

    }
}
