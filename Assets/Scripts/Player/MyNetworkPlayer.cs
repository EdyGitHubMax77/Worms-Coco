using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField] 
    string displayName = "Missing Name";

    [SyncVar (hook = nameof(HandlerDisplayColorUpdated))]
    [SerializeField]
    Color displayColor;

    /*Player Number Change
    [SyncVar(hook = nameof(HandlerDisplayNameUpdated))]
    [SerializeField]
    Color displayPlayer;
    */
    [SerializeField] Renderer render;

    [Server]
    public void SetDisplayName(string newDisplayName)
    {
        displayName = newDisplayName;

    }

    [Server]
    public void  SetColor(Color newColor)
    {
        displayColor = newColor;
        
    }

    [ContextMenu("UpdateColor")]
    [Server]
    private void UpdateColor()
    {
        displayColor = Color.black;
    }

    private void HandlerDisplayColorUpdated(Color oldColour, Color newColour)
    {
        render.material.SetColor("_Color", newColour);
    }
    /*
    private void HandlerDisplayNameUpdated(string oldDisplayName, string newDisplayName)
    {
        render.material.SetColor("_text", newDisplayName);
    }
    */
}
