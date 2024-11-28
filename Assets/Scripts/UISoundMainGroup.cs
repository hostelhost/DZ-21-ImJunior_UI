using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISoundMainGroup : MonoBehaviour, ISoundGroup
{                        
    private const float MinimumValume = -80f;                        
    private const int FormulaConversion = 20;                         

    [SerializeField] private AudioMixerGroup _mixer;                    
    [SerializeField] private AudioSource _background;
    [SerializeField] private Slider _slider;
    [SerializeField] private Toggle _toggle;

    private float _currentValue;                                  
    private bool _isWorkingMusic; 

    private void Start() 
    {
        _isWorkingMusic = _background.playOnAwake;
    }

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolum);
        _toggle.onValueChanged.AddListener(TriggleMusic);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolum);
        _toggle.onValueChanged.RemoveListener(TriggleMusic);
    }

    private void TriggleMusic(bool isWorking) 
    {
        if (isWorking)
            OnMusic();
        else
            TurnOffMusic();
    }

    public void ChangeVolum(float volume)                              
    {
        _currentValue = Mathf.Log10(volume) * FormulaConversion;

        if (_isWorkingMusic)
            _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
    }

    private void OnMusic()
    {
        _isWorkingMusic = true;
        _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
    }

    private void TurnOffMusic()
    {
        _isWorkingMusic = false;
        _mixer.audioMixer.SetFloat(_mixer.name, MinimumValume);
    }
}