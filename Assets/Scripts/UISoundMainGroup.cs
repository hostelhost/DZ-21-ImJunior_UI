using UnityEngine;
using UnityEngine.Audio;

public class UISoundMainGroup : MonoBehaviour, ISoundGroup
{          
    private const float MaximumValume = 0f;                          
    private const float MinimumValume = -80f;                        
    private const int FormulaConversion = 20;                         

    [SerializeField] private AudioMixerGroup _mixer;                    
    [SerializeField] private AudioSource _background; 

    private float _currentValue;                                  
    private bool _isWorkingMusic; 

    private void Start() 
    {
        _isWorkingMusic = _background.playOnAwake;
    }

    public void TriggleMusic(bool isWorking) 
    {
        if (isWorking)
            OnMusic();
        else
            OFFMusic();
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

        if (_currentValue < MaximumValume)
            _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
        else
            _mixer.audioMixer.SetFloat(_mixer.name, MaximumValume);
    } 

    private void OFFMusic() 
    {
        _isWorkingMusic = false;

        if (_currentValue < MinimumValume)
            _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
        else
            _mixer.audioMixer.SetFloat(_mixer.name, MinimumValume);
    } 
}
