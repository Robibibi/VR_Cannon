using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireCannon : MonoBehaviour
{
    public Rigidbody cannonBallPrefab;
    public Transform cannonEnd;
    public float fireSpeed;
    // Start is called before the first frame update
    void Start()
    {
        XRSimpleInteractable interactable = GetComponent<XRSimpleInteractable>();
        interactable.selectEntered.AddListener(OnSelectEnter);
    }

    void OnSelectEnter(SelectEnterEventArgs args)
    {
        print("Selected");
        Fire();
    }

    void Fire()
    {
        Rigidbody newBall = Instantiate(cannonBallPrefab, null);  // null = parent
        // Placer la newBall à la sortie du cannon
        newBall.transform.position = cannonEnd.position;
        // Donner une vitesse à newBall
        newBall.velocity = transform.forward * fireSpeed;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
