using UnityEngine;
using UnityEngine.UI;

public class ActivatedByButton : MonoBehaviour
{
    [SerializeField] private AudioSource _saund;
    [SerializeField] private Button _button;

    private void OnEnable()
    {
        _button.onClick.AddListener(_saund.Play);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(_saund.Play);
    }
}
