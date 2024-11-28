using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class UISoundAuxiliaryGroup : MonoBehaviour, ISoundGroup
{
    private const int FormulaConversion = 20;

    [SerializeField] private AudioMixerGroup _mixer;
    [SerializeField] private Slider _slider;

    private float _currentValue;

    private void OnEnable()
    {
        _slider.onValueChanged.AddListener(ChangeVolum);
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(ChangeVolum);
    }

    public void ChangeVolum(float volume)
    {
        _currentValue = Mathf.Log10(volume) * FormulaConversion;
        _mixer.audioMixer.SetFloat(_mixer.name, _currentValue);
    }
}
