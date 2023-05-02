using UnityEngine;

public class MobileLayerPresenter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject mobilerLayer;

    private void Awake()
    {
#if UNITY_ANDROID || UNITY_IOS
        this.mobilerLayer.SetActive(true);
#endif
    }
}
