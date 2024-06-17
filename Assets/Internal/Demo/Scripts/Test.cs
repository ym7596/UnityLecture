using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField]  private InputManager _inputManager;
    [SerializeField] private Transform _camTransform;

    private CameraController _camController;
    private TouchPhases phase;
    // Start is called before the first frame update
   
    private bool begin = false;
    public SpaceObject CurrentObject { get; private set; }

    private Ray _ray;
    private void Start()
    {
        _camController = new CameraController(_camTransform,_inputManager);
    }
    

    // Update is called once per frame
    void Update()
    {
        phase = _inputManager.CurrentPhase;
       _camController.Update();

       if (phase == TouchPhases.None || _inputManager.IsUITouched)
           return;
        SetNoItem();
       
    
    }

    private void SetNoItem()
    {
        if (CurrentObject)
        {
            int layerMask = ~ignoreLayer.value;
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(_inputManager.Pos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity , layerMask))
            {
                SetMoveObject(CurrentObject,hit.point);
            }
        }
        RaycastHit _hit;
        switch (_inputManager.CurrentPhase)
        {
            case TouchPhases.None:
            {
            
            }
                break;
            case TouchPhases.Began:
            {
                var camRay = Camera.main.ScreenPointToRay(_inputManager.Pos);
                if (Physics.Raycast(camRay, out _hit, 5000))
                {
                    CurrentObject = _hit.collider.GetComponent<SpaceObject>();
                }
               
            }
                break;
            case TouchPhases.Held:
            {
            }
                break;
            case TouchPhases.Ended:
            {
                CurrentObject = null;
                break;
            }
        }
    }

    public LayerMask ignoreLayer;

 
    

    private void SetMoveObject(SpaceObject obj, Vector3 pos)
    {
        obj.transform.position = pos;
    }
}
