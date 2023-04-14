using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Singelton : MonoBehaviour
{
    public GameObject me;

    private AudioSource _bg;




    private void Awake()
    {
        #region Singelton
        List<Singelton> me = FindObjectsOfType<Singelton>().ToList();


        if (me != null)
        {
            for (int i = 0; i < me.Count; i++)
            {

                print(me[i].name);

                if (me[i] != this)
                    Destroy(gameObject);
                else
                    DontDestroyOnLoad(gameObject);
            }
        }
        else
            DontDestroyOnLoad(this);
        #endregion

        _bg = GetComponentInChildren<AudioSource>();

        InvokeRepeating("PlayMusicWithDelay", 0, _bg.clip.length);

    }

    IEnumerator sa()
    {
        yield return new WaitForSeconds(3);
        _bg.Play();
    }


    private void PlayMusicWithDelay()
    {
        StartCoroutine(sa());
        print("sa");
    }
}