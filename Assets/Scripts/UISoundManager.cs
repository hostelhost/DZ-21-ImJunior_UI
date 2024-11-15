using UnityEngine;
using UnityEngine.Audio;

public class UISoundManager : MonoBehaviour
{
    //������!!!! 

    // 1. ���������� ��������� ���� ���� �����. ��� �� ��������� �� 3 ������ ������. 1. ������� ������. 2. ������. 3.��������
    // 2. ���������� ����� �� ��������� ��� ����������� �����.(����������� ��� ����� ��������)
    //3. ����������� ���� ������� ���������, � �������� 1-�� ������. ����� �������.!

    private const string MainGroup = "UIVolume";              // ����� ���� 3-� �������
    private const float MaximumValume = 0f;                          // ����� ���� 3-� �������
    private const float MinimumValume = -80f;                        // ����� ���� 3-� �������
    private const int FormulaConversion = 20;                         // ����� ���� 3-� �������

    [SerializeField] private AudioMixerGroup _mixer;                    // ����� ���� 3-� �������
    [SerializeField] private AudioSource _background; //����� ������ �������� ������

    private float _currentValue;                                  // ����� ���� 3-� �������
    private bool _isWorkingMusic; //����� ������ �������� ������

    private void Start() //����� ������ �������� ������
    {
        _isWorkingMusic = _background.playOnAwake;
    }

    public void TriggleMusic(bool isWorking) //����� ������ �������� ������
    {
        if (isWorking)
            OnMusic();
        else
            OFFMusic();
    }

    public void ChangeVolum(float volume)                              // ����� ���� 3-� �������
    {
        _currentValue = Mathf.Log10(volume) * FormulaConversion;

        if (_isWorkingMusic)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
    }

    private void OnMusic() //����� ������ �������� ������
    {
        _isWorkingMusic = true;

        if (_currentValue < MaximumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MaximumValume);
    } 

    private void OFFMusic() //����� ������ �������� ������
    {
        _isWorkingMusic = false;

        if (_currentValue < MinimumValume)
            _mixer.audioMixer.SetFloat(MainGroup, _currentValue);
        else
            _mixer.audioMixer.SetFloat(MainGroup, MinimumValume);
    } 
}
