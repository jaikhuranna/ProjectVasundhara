using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class HandAnimator : MonoBehaviour
{
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    private TriggerInputDetector XRinput;
    private Animator handAnimator;


    private void Start()
    {
        XRinput = FindObjectOfType<TriggerInputDetector>();
        handAnimator = GetComponent<Animator>();
    }

    void Update()
    {
        handAnimator.SetFloat("Trigger", pinchAnimationAction.action.ReadValue<float>());
        handAnimator.SetFloat("Grip", gripAnimationAction.action.ReadValue<float>());
    }
    
}
