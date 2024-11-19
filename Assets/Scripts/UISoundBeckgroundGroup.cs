using UnityEngine;
using UnityEngine.Audio;

public class UISoundBeckgroundGroup : MonoBehaviour, ISoundGroup
{
    private const int FormulaConversion = 20;

    [SerializeField] private AudioMixerGroup _mixer;

    private float _currentValue;

    public void ChangeVolum(float volume)
    {
        _currentValue = Mathf.Log10(volume) * FormulaConversion; 
        _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
    }
}
