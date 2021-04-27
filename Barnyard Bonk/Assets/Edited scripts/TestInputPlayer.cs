using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

//testing using the new input system
public class TestInputPlayer : MonoBehaviour
{
    public InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();
        //accessing player action map -- [.Shoot.performed] we can choose what happens when the shoot action is triggered / the keys linked to it are pressed
        controls.Player.Shoot.performed += context => Shoot(); 
            // now we take the Shoot() method and register it to this button.  context variable doesn't rly matter here
    }

    void Shoot()
    {
        Debug.Log("Shoot");
    }
}
