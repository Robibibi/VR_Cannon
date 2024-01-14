using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class RotateCannon : MonoBehaviour
{
    public GameObject rotator;
    public float rotateSpeed, thresholdAngle;
    public Transform leftController;
    private XRSimpleInteractable interactable;
    private Vector3 grabDirection, controllerDirection;

    // Start is called before the first frame update
    void Start()
    {
        interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        grabDirection = args.interactableObject.transform.position - args.interactorObject.transform.position;
        print("grab dir : " + grabDirection);
        print("controller dir : " + args.interactorObject.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        if(interactable.isSelected) {
            controllerDirection = leftController.transform.forward;
            if (Vector3.Angle(grabDirection, controllerDirection) > thresholdAngle) {
                
            }
            // print("Selected");
            rotator.transform.Rotate(new Vector3(0, 1, 0), rotateSpeed);
        }

        
    }
}
