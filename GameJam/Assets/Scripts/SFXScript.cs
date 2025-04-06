using UnityEngine;

public class SFXScript : MonoBehaviour
{
    public static SFXScript instance;
    [SerializeField] private AudioSource objetoSFX;
    [SerializeField] private AudioSource loopSource = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void suenaClip(AudioClip clipSFX, Transform spawn, float volumen, float largo, bool setLargo = false)
    {
        AudioSource source = Instantiate(objetoSFX, spawn.position, Quaternion.identity);
        source.clip = clipSFX;
        source.volume = volumen;
        source.Play();
        source.loop = true;
        float largoClip;
        if (setLargo)
        {
            largoClip = largo;
        }
        else
        {
            largoClip = source.clip.length;

        }



        //Destroy(source.gameObject, largoClip);
    }

    public void loopClip(AudioClip clipSFX, Transform spawn, float volumen)
    {
        if (loopSource != null && loopSource.isPlaying)
        {
            loopSource.Stop();
            Destroy(loopSource.gameObject);
        }
        loopSource = Instantiate(objetoSFX, spawn.position, Quaternion.identity);
        loopSource.clip = clipSFX;
        loopSource.volume = volumen;
        loopSource.Play();
        loopSource.loop = true;
    }

    public void loopClipRestart(AudioClip clipSFX, Transform spawn, float volumen)
    {
        if (loopSource != null && !loopSource.isPlaying)
        {
            loopSource = Instantiate(objetoSFX, spawn.position, Quaternion.identity);
            loopSource.clip = clipSFX;
            loopSource.volume = volumen;
            loopSource.Play();
            loopSource.loop = true;
        }

    }

    public void stopClip()
    {
        if (loopSource != null && loopSource.isPlaying)
        {
            loopSource.Stop();
            Destroy(loopSource.gameObject);
        }
    }

    public void muteBtn(bool muted)
    {
        if (!muted)
        {
            unmuteAll();
        }
        else
        {
            muteAll();
        }
    }

    public void muteAll()
    {
        AudioListener.volume = 0;
    }

    public void unmuteAll()
    {
        AudioListener.volume = 1;
    }




}
