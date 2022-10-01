using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EP.H.InputManager
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler instance;

        private RaycastHit hit;

        public Camera Cam;

        void Start()
        {
            instance = this;
        }

        void Update()
        {
            
        }

        public void HandleUnitMovement()
        {
            if(Input.GetMouseButtonDown(0))
            {
                //Create a ray
                Ray ray = Cam.ScreenPointToRay(Input.mousePosition);
                //Check if we hit someting
                if(Physics.Raycast(ray, out hit))
                {
                    //if we did do somthing with that data
                    LayerMask layerHit = hit.transform.gameObject.layer;

                    switch (layerHit.value)
                    {
                        case 11: //Units layer
                            //do something
                            SelectUnit(hit.transform);
                            break;
                        default: //if none of the above happens
                            //do something
                            break;
                    }
                }
            }
        }

        private void SelectUnit(Transform unit)
        {
            //lets set an obj on the unit called Highlight
            unit.Find("Highlight").gameObject.SetActive(true);
        }
    }
}
