using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class ScreenManager : MonoBehaviour
{
    public static ScreenManager instance = null;
    public bool useCameras;

    [SerializeField] private List<GameScreen> screens = new List<GameScreen>();
    private int select = 0;
    private int last = 0;

    private void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance == this)
        {
            Debug.LogError("Clone instance! [ScreenManger]");
            Destroy(gameObject);
        }

        foreach (var s in screens)
        {
            s.UI.SetActive(false);
            
            if (useCameras)
            {
                s.Camera.Priority = 0;
            }
        }

        OpenScreen(0);
    }

    public void OpenScreen(int id)
    {
        select = id;
        screens[last].UI.SetActive(false);

        if (useCameras)
        {
            screens[last].Camera.Priority = 0;
            screens[select].Camera.Priority = 100;
        }
        
        screens[select].UI.SetActive(true);
        last = id;
    }

    public void GoBack()
    {
        OpenScreen(screens[select].Owner);
    }
}