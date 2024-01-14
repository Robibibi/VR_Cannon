using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using System;

public class RotateCannon : MonoBehaviour
{
    public GameObject rotator;
    public Transform leftController;
    public float rotateSpeed, thresholdAngle;
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
            // print("grab dir : " + grabDirection);
            // print("controller dir : " + controllerDirection);
            // print("angle : " + Vector3.Angle(grabDirection, controllerDirection));
            Vector3 newDir = leftController.transform.InverseTransformDirection(grabDirection).normalized;
            print("newDir : " + newDir);
            print(Math.Abs(newDir.x));


            if (Math.Abs(newDir.x) > thresholdAngle) {
                print("rot " + newDir.x * rotateSpeed);
                rotator.transform.Rotate(new Vector3(0, 1, 0), newDir.x * rotateSpeed);
                
            }
            // print("Selected");
        }

        
    }
}
