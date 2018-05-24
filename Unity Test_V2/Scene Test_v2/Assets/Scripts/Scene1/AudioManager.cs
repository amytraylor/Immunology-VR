using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {


    AudioSource guideAudio;
    public AudioClip[] aClips;
    public GameObject audioTrigger01;
    public GameObject audioTrigger02;
    public GameObject audioTrigger03;
    public GameObject audioTrigger04;
    public GameObject audioTrigger05;
    public GameObject audioTrigger06;
    public GameObject audioTrigger07;
    public GameObject audioTrigger08;
    public bool isStartLocked;

    bool introPlayed;
    AudioTrigger01 _audioTrigger01;
    AudioTrigger02 _audioTrigger02;
    AudioTrigger03 _audioTrigger03;
    AudioTrigger04 _audioTrigger04;
    AudioTrigger05 _audioTrigger05;
    AudioTrigger06 _audioTrigger06;
    AudioTrigger07 _audioTrigger07;
    AudioTrigger08 _audioTrigger08;

    //vive controller tracking and input
    public SteamVR_TrackedObject controller;
    private SteamVR_Controller.Device device
    {
        get { return SteamVR_Controller.Input((int)controller.index); }
    }

    private void Awake()
    {
        controller = GetComponent<SteamVR_TrackedObject>();

        guideAudio = GetComponent<AudioSource>();

        _audioTrigger01 = audioTrigger01.GetComponent<AudioTrigger01>();
        _audioTrigger02 = audioTrigger02.GetComponent<AudioTrigger02>();
        _audioTrigger03 = audioTrigger03.GetComponent<AudioTrigger03>();
        _audioTrigger04 = audioTrigger04.GetComponent<AudioTrigger04>();
        _audioTrigger05 = audioTrigger05.GetComponent<AudioTrigger05>();
        _audioTrigger06 = audioTrigger06.GetComponent<AudioTrigger06>();
        _audioTrigger07 = audioTrigger07.GetComponent<AudioTrigger07>();
        _audioTrigger08 = audioTrigger08.GetComponent<AudioTrigger08>();
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (device.GetHairTriggerDown() && !introPlayed && !guideAudio.isPlaying)
        {
            introPlayed = true;
            guideAudio.PlayOneShot(aClips[0], 1f);
            isStartLocked = true;
        }

        if (isStartLocked && !guideAudio.isPlaying)
        {
            isStartLocked = false;
        }

        if(_audioTrigger01.playAudio01 == true && !guideAudio.isPlaying)
        {
            _audioTrigger01.playAudio01 = false;
            guideAudio.PlayOneShot(aClips[1], 1f);
        }

        if (_audioTrigger02.playAudio02 == true)
        {
            _audioTrigger02.playAudio02 = false;
            guideAudio.PlayOneShot(aClips[2], 1f);
        }

        if (_audioTrigger03.playAudio03 == true)
        {
            _audioTrigger03.playAudio03 = false;
            guideAudio.PlayOneShot(aClips[3], 1f);
        }

        if (_audioTrigger04.playAudio04 == true)
        {
            _audioTrigger04.playAudio04 = false;
            guideAudio.PlayOneShot(aClips[4], 1f);
        }

        if (_audioTrigger05.playAudio05 == true)
        {
            _audioTrigger05.playAudio05 = false;
            guideAudio.PlayOneShot(aClips[5], 1f);
        }

        if (_audioTrigger06.playAudio06 == true)
        {
            _audioTrigger06.playAudio06 = false;
            guideAudio.PlayOneShot(aClips[6], 1f);
        }

        if (_audioTrigger07.playAudio07 == true)
        {
            _audioTrigger07.playAudio07 = false;
            guideAudio.PlayOneShot(aClips[7], 1f);
        }

        if (_audioTrigger08.playAudio08 == true)
        {
            _audioTrigger08.playAudio08 = false;
            guideAudio.PlayOneShot(aClips[8], 1f);
        }
    }
}
