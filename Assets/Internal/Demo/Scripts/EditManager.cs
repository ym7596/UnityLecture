using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    [SerializeField]  private InputManager _inputManager;
    [SerializeField] private Transform _camTransform;
    [SerializeField] private BundleLoader _bundleLoader;

    private CameraController _camController;
    private TouchPhases phase;
    // Start is called before the first frame update
   
    private bool begin = false;
    public LayerMask ignoreLayer;


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

        if (CurrentObject)
        {
            int layerMask = ~ignoreLayer.value;
            RaycastHit hit;
            var ray = Camera.main.ScreenPointToRay(_inputManager.Pos);
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask(Config.groundLayer)))
            {
                SetMoveObject(CurrentObject, hit.point);
            }
        }
       if (phase == TouchPhases.None || _inputManager.IsUITouched)
           return;
        SetNoItem();
       
    
    }

    private void SetNoItem()
    {
       
        RaycastHit _hit;
        var camRay = Camera.main.ScreenPointToRay(_inputManager.Pos);
        switch (_inputManager.CurrentPhase)
        {
            case TouchPhases.None:
            {
            
            }
                break;
            case TouchPhases.Began:
            {
                
               
            }
                break;
            case TouchPhases.Held:
            {
            }
                break;
            case TouchPhases.Ended:
            {
                if (CurrentObject)
                {
                    CurrentObject = null;
                }
                else
                {
                       
                    if (Physics.Raycast(camRay, out _hit, 5000))
                    {
                        CurrentObject = _hit.collider.GetComponent<SpaceObject>();
                    }
                       
                }
                break;
            }
        }
    }

    public void RequestObject(string url)
    {
        _bundleLoader.GetAssetBundle(url, (result, data) =>
        {
            if (result)
            {
                var go = Instantiate(data, Vector3.zero, Quaternion.identity);
                go.layer = LayerMask.NameToLayer( Config.itemLayer);
                go.AddComponent<SpaceObject>();
            }
        });
    }

   
    

    private void SetMoveObject(SpaceObject obj, Vector3 pos)
    {
        obj.transform.position = GetSnapPos(pos);
    }

    private Vector3 GetSnapPos(Vector3 pos)
    {
        Vector3 result = new Vector3(
            RoundNearestGrid(pos.x), pos.y, RoundNearestGrid(pos.z));
        return result;
    }

    private float RoundNearestGrid(float f)
    {
        return Mathf.Round(f / Config.gridSize) * Config.gridSize;
    }
}
