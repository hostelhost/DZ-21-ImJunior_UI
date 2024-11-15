using UnityEngine;
using UnityEngine.Audio;

public class MixerHashData : MonoBehaviour
{
    private const string MainGroup = "UIVolume";

    [SerializeField] private AudioMixerGroup _mixer;

    public int MainGroupID { get; private set; } 

    private void Start()
    {
        GetHashID();
    }

    private void GetHashID()
    {
    }
}
