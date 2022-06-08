using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sound : MonoBehaviour
{
    public AudioSource Player_hit_audio;
    public AudioSource Wall_hit_audio;
    public AudioSource Gol_audio;
    public AudioSource ice_Break_audio;
    public AudioSource wall_audio;
    public AudioSource invicible_audio;

    public AudioClip p1_clip;
    public AudioClip wall_hit_clip;
    public AudioClip goll_clip;
    public AudioClip ice_freeze_clip;
    public AudioClip ice_break_clip;
    public AudioClip wall_bigger_clip;
    public AudioClip wall_smaller_clip;
    public AudioClip invicible_clip;


    public void Player_hit_sound()
    {
        Player_hit_audio.PlayOneShot(p1_clip);
    }

    public void Wall_hit_Sound()
    {
        Wall_hit_audio.PlayOneShot(wall_hit_clip);
    }

    public IEnumerator Goll_Sound()
    {
        Gol_audio.Play();
        yield return new WaitForSecondsRealtime(2.5f);
        Gol_audio.Stop();
    }

    public void ice_freeze_sound()
    {
        ice_Break_audio.PlayOneShot(ice_freeze_clip);
    }
    public void ice_break_sound()
    {
        ice_Break_audio.PlayOneShot(ice_break_clip);
    }

    public void wall_bigger_sound()
    {
        wall_audio.PlayOneShot(wall_bigger_clip);
    }
    public void wall_smaller_sound()
    {
        wall_audio.PlayOneShot(wall_smaller_clip);
    }

    public void invicible_sound()
    {
        invicible_audio.PlayOneShot(invicible_clip);
    }


}
