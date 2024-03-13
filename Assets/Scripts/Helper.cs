using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Helper : MonoBehaviour
{
    [SerializeField] private RaycastPlacer placer;
    [SerializeField] private Button btn;
    
    // Start is called before the first frame update
    void Start()
    {
        btn.interactable = false;
        
        placer.OnSpawned += () => btn.interactable = true;
    }
    
}
