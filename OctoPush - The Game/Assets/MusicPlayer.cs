using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    protected MusicPlayer() { }
    private static MusicPlayer instance = null;

    public static MusicPlayer Instance
    {
        get
        {
            if (MusicPlayer.instance == null)
            {
                DontDestroyOnLoad(MusicPlayer.instance);
                MusicPlayer.instance = new MusicPlayer();
            }
            return MusicPlayer.instance;
        }
    }

    void Awake()
    {
        if (instance == null)
        {
            //If I am the first instance, make me the Singleton
            instance = this;
            DontDestroyOnLoad(this);

            // Play music
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != instance)
                Destroy(this.gameObject);
        }
    }
}
