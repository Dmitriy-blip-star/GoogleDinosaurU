using UnityEngine;

public class DesctopLayerPresenter : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] GameObject desktopLayer;

    private void Awake()
    {
#if UNITY_STANDALONE
        this.desktopLayer.SetActive(true); 
#endif
    }
}
