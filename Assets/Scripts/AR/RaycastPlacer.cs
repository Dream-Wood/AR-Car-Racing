using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class RaycastPlacer : MonoBehaviour
{
    public event Action OnSpawned;

    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject spawnedObject;
    
    [SerializeField] private bool isSpawned;

    private ARRaycastManager arRaycastManager;

    private List<ARRaycastHit> hits = new List<ARRaycastHit>();
    
    // Start is called before the first frame update
    void Start()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                var pos = hits[0].pose;
                
                if (!isSpawned)
                {
                    spawnedObject = Instantiate(prefab, pos.position, pos.rotation);
                    spawnedObject.transform.localScale = Vector3.one / 10f;
                    isSpawned = true;
                }
                else
                {
                    spawnedObject.transform.position = pos.position;
                    OnSpawned?.Invoke();
                }
            }
        }
    }
}
