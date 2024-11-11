using UnityEngine;
using UnityEngine.Audio;

public class UISoundManager : MonoBehaviour
{
    //Задачи!!!! 
    // 1. Прочитать комментарий ниже!
    // 2. Сделать так что бы ползунок, не менял звук если выключена галочка. Или пусть галочка включается автоматически если трогают ползунок
    // 3. Попробовать захешировать данные как в аниматоре "MixerHashData".
    // 4. Сделать звук всем обьектам. Причисать и прилизать проект.

    private const string MainGroup = "UIVolume";
    private const float MaximumValume = 0f;
    private const float MinimumValume = -80f;

    [SerializeField] private AudioMixerGroup _mixer;

    private int _formulaConversion = 20;
    private float _currentValue = 0;

    public void TriggleMusic(bool isWorking)
    {
        //ПРОВЕРИТЬ РОБОТОСПОСОБНОСТЬ!!!!!!! Если все ок удалить работающий закоментированный код
        if (isWorking)
            OnMusic();       
        else       
            OFFMusic();        

        //if (isWorking)
        //    _mixer.audioMixer.SetFloat(MainGroup, _maximumValume);      
        //else
        //    _mixer.audioMixer.SetFloat(MainGroup, _minimumValume);
    }

    public void ChangeVolum(float volume)
    {
        _currentValue = Mathf.Log10(volume) * _formulaConversion;
        _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
    }

    private void OnMusic()
    {
        if (_currentValue < MaximumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MaximumValume);
    }

    private void OFFMusic()
    {
        if (_currentValue < MinimumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MinimumValume);
    }
}
