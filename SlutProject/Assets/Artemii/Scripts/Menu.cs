using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using static UnityEngine.UI.Toggle;

public class Menu : MonoBehaviour
{
    [SerializeField] UIDocument _document;
    [SerializeField] List<ButtonEvent> _buttonEvents;
    public void LoadScene(int bulidindex)
    {
        SceneManager.LoadScene(bulidindex);
    }
    public void Quit()
    {
        Application.Quit();

        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
    private void OnEnable()
    {
        _buttonEvents.ForEach(button => button.Activate(_document));
    }
    private void OnDisable()
    {
        _buttonEvents.ForEach(button => button.InActivate(_document));
    }
}
[System.Serializable]
public class ButtonEvent
{
    [SerializeField] string _buttonName = "";
    [SerializeField] UnityEvent unityEvent;
    Button button;
    public void Activate(UIDocument document)
    {
        if (button == null)
        {
            button = document.rootVisualElement.Q<Button>(_buttonName);
        }
        button.clicked += unityEvent.Invoke;
    }
    public void InActivate(UIDocument document)
    {
        button.clicked -= unityEvent.Invoke;
    }
}
