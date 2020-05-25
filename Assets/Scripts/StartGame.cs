using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StartGame : XRBaseInteractable
{
    protected override void Awake()
    {
        base.Awake();
        onHoverEnter.AddListener(OnButtonPress);
    }
    private void OnButtonPress(XRBaseInteractor interactor)
    {
        Debug.Log("ey start game");
    }
}
