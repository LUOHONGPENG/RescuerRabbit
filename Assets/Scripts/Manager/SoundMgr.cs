using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoundType
{
    No,
    Stop,
    Protect,
    Follow,
    Thank,
    Tired
}

public class SoundMgr : MonoBehaviour
{
    public AudioSource auNo;
    public AudioSource auStop;
    public AudioSource auProtect;
    public AudioSource auFollow;
    public AudioSource auThank;
    public AudioSource auTired;



    public Dictionary<SoundType, AudioSource> dicSoundAudio = new Dictionary<SoundType, AudioSource>();
    public Dictionary<SoundType, float> dicSoundTime = new Dictionary<SoundType, float>();

    public void Init()
    {
        dicSoundAudio.Clear();
        dicSoundAudio.Add(SoundType.No, auNo);
        dicSoundAudio.Add(SoundType.Stop, auStop);
        dicSoundAudio.Add(SoundType.Protect, auProtect);
        dicSoundAudio.Add(SoundType.Follow, auFollow);
        dicSoundAudio.Add(SoundType.Thank, auThank);
        dicSoundAudio.Add(SoundType.Tired, auTired);


        dicSoundTime.Clear();
        dicSoundTime.Add(SoundType.Thank, 0.5f);

    }

    public void PlaySoundCatch()
    {
        int ran = Random.Range(0, 3);
        switch (ran)
        {
            case 0:
                PlaySound(SoundType.Protect);
                break;
            case 1:
                PlaySound(SoundType.Follow);
                break;
            case 2:
                PlaySound(SoundType.Stop);
                break;
        }
    }

    public void PlaySoundDead()
    {
        int ran = Random.Range(0, 10);
        if (ran < 5)
        {
            PlaySound(SoundType.No);
        }
    }

    public void PlaySoundThank()
    {
        int ran = Random.Range(0, 10);
        if (ran < 5)
        {
            PlaySound(SoundType.Thank);
        }
    }


    public void PlaySound(SoundType soundType)
    {
        if (dicSoundAudio.ContainsKey(soundType))
        {
            AudioSource targetSound = dicSoundAudio[soundType];

            float playTime = 0.2f;
            if (dicSoundTime.ContainsKey(soundType))
            {
                playTime = dicSoundTime[soundType];
            }

            targetSound.time = playTime;
            targetSound.Play();
        }
    }
}
