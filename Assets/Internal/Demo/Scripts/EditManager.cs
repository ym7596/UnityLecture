using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditManager : MonoBehaviour
{
    [SerializeField]  private InputManager _inputManager;
    [SerializeField] private Transform _camTransform;
    private BundleLoader _bundleLoader;

    [SerializeField] private SpaceObjectDataSO _spaceObjectDataSO;

    private CameraController _camController;
    private TouchPhases phase;
    // Start is called before the first frame update
   
    private bool begin = false;
    private int _index = 0;
    
    public LayerMask ignoreLayer;

    private SpaceObject _currentObject;
    public SpaceObject CurrentObject 
    {
        get
        {

        return _currentObject; 
        }
        
        private set
        {
            if(value == null)
            {
                
                _currentObject?.SetSelect(false);
                _currentObject = value;
            }
            else
            {
                _currentObject = value;
                _currentObject.SetSelect(true);
            }
        } 
    
    }

    private Ray _ray;
    private void Start()
    {
        _bundleLoader = new BundleLoader();
        _camController = new CameraController(_camTransform,_inputManager);
    }
    

    // Update is called once per frame
    void Update()
    {
        phase = _inputManager.CurrentPhase;
       _camController.Update();
        Ray ray = Camera.main.ScreenPointToRay(_inputManager.Pos);
        if (CurrentObject)
        {
            int layerMask = ~ignoreLayer.value;
            RaycastHit hit;
           
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, LayerMask.GetMask(Config.groundLayer)))
            {
                SetMoveObject(CurrentObject, hit.point);
            }
        }
       if (phase == TouchPhases.None || _inputManager.IsUITouched)
           return;
        SetNoItem(ray);
       
    
    }

    private void SetNoItem(Ray ray)
    {
        RaycastHit _hit;
       // var camRay = Camera.main.ScreenPointToRay(_inputManager.Pos);
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
                    if (Physics.Raycast(ray, out _hit, 5000))
                    {
                        CurrentObject = _hit.collider.GetComponent<SpaceObject>();
                    }
                }
                break;
            }
        }
    }

   
    public void TestRequest(string id)
    {
        InteriorModel model = _spaceObjectDataSO.interiorModels.Find(x => x.id == id);
        
        RequestObject(model);
    }

    private void RequestObject(InteriorModel model)
    {
        _bundleLoader.GetAssetBundle(model.bundleData.bundleId, (result, data) =>
         {
             if (result)
             {
                 var go = Instantiate(data, Vector3.zero, Quaternion.identity);
                 go.layer = LayerMask.NameToLayer(Config.itemLayer);
                 var so = go.AddComponent<SpaceObject>();
                
                so.SetData(model.bundleData.bundleId, model.category, _index);
                 _index++;
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
