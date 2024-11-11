using UnityEngine;
using UnityEngine.Audio;

public class UISoundManager : MonoBehaviour
{
    //������!!!! 
    // 1. ��������� ����������� ����!
    // 2. ������� ��� ��� �� ��������, �� ����� ���� ���� ��������� �������. ��� ����� ������� ���������� ������������� ���� ������� ��������
    // 3. ����������� ������������ ������ ��� � ��������� "MixerHashData".
    // 4. ������� ���� ���� ��������. ��������� � ��������� ������.

    private const string MainGroup = "UIVolume";
    private const float MaximumValume = 0f;
    private const float MinimumValume = -80f;

    [SerializeField] private AudioMixerGroup _mixer;

    private int _formulaConversion = 20;
    private float _currentValue = 0;

    public void TriggleMusic(bool isWorking)
    {
        //��������� �����������������!!!!!!! ���� ��� �� ������� ���������� ����������������� ���
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
