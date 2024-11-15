using UnityEngine;
using UnityEngine.Audio;

public class UISoundManager : MonoBehaviour
{
    //Задачи!!!! 

    // 1. Определить оставляем один этот класс. или же разбиваем на 3 разных класса. 1. главная группа. 2. кнопки. 3.беграунд
    // 2. определить нужен ли интерфейс или обстрактный класс.(разобраться что лучше подходит)
    //3. комментарии ниже упрощат понимание, в разборка 1-го пункта. затем удалить.!

    private const string MainGroup = "UIVolume";              // Нужно ВСЕМ 3-м КЛАССАМ
    private const float MaximumValume = 0f;                          // Нужно ВСЕМ 3-м КЛАССАМ
    private const float MinimumValume = -80f;                        // Нужно ВСЕМ 3-м КЛАССАМ
    private const int FormulaConversion = 20;                         // Нужно ВСЕМ 3-м КЛАССАМ

    [SerializeField] private AudioMixerGroup _mixer;                    // Нужно ВСЕМ 3-м КЛАССАМ
    [SerializeField] private AudioSource _background; //нужен только главному классу

    private float _currentValue;                                  // Нужно ВСЕМ 3-м КЛАССАМ
    private bool _isWorkingMusic; //нужен только главному классу

    private void Start() //нужен только главному классу
    {
        _isWorkingMusic = _background.playOnAwake;
    }

    public void TriggleMusic(bool isWorking) //нужен только главному классу
    {
        if (isWorking)
            OnMusic();
        else
            OFFMusic();
    }

    public void ChangeVolum(float volume)                              // Нужно ВСЕМ 3-м КЛАССАМ
    {
        _currentValue = Mathf.Log10(volume) * FormulaConversion;

        if (_isWorkingMusic)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
    }

    private void OnMusic() //нужен только главному классу
    {
        _isWorkingMusic = true;

        if (_currentValue < MaximumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MaximumValume);
    } 

    private void OFFMusic() //нужен только главному классу
    {
        _isWorkingMusic = false;

        if (_currentValue < MinimumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MinimumValume);
    } 
}
