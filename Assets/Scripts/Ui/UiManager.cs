using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class UiManager : MonoBehaviour
{
    public static UiManager Singleton;

    public UiWindow ActiveUiWindow;
    public GraphicRaycaster Raycaster;
    public PointerEventData PointerEventData;
    public EventSystem EventSystem;

    public List<UiWindow> UiWindowsPrefabs;
    private Dictionary<UiWindowType, UiWindow> _uiWindowsDic = new Dictionary<UiWindowType, UiWindow>();

    private void Awake()
    {
        Singleton = this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void OnEnable()
    {
        EventManager.Singleton.E_UiWindowActivated += ActivateUiWindow;
        EventManager.Singleton.E_UiWindowDisabled += DisableUiWindow;
    }

    private void OnDisable()
    {
        EventManager.Singleton.E_UiWindowActivated -= ActivateUiWindow;
        EventManager.Singleton.E_UiWindowDisabled -= DisableUiWindow;

    }
    // Start is called before the first frame update
    void Start()
    {
        foreach(UiWindow window in UiWindowsPrefabs)
        {
            _uiWindowsDic.Add(window.WindowType, window);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateUiWindow(UiWindowType type)
    {
        _uiWindowsDic.TryGetValue(type,out ActiveUiWindow);
        Cursor.lockState = CursorLockMode.None;
        ActiveUiWindow.gameObject.SetActive(true);

        switch (type)
        {
            case UiWindowType.UiBackpack:
                
                break;
        }
    }

    public void DisableUiWindow(UiWindowType type)
    {
        Cursor.lockState = CursorLockMode.Locked;
        ActiveUiWindow.gameObject.SetActive(false);
    }

}
