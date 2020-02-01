using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearSight2 : MonoBehaviour
{
    public float DistanceToPlayer = 5.0f;
    public float FadeInTimeout = 0.6f;
    public float FadeOutTimeout = 0.2f;
    public float TargetTransparency = 0.3f;
    public LayerMask layerMask;
    private float layerNum;
    // Update is called once per frame
    void Update()
    {
        RaycastHit[] hits; // you can also use CapsuleCastAll() 
                           // TODO: setup your layermask it improve performance and filter your hits. 
        hits = Physics.RaycastAll(transform.position, transform.forward, DistanceToPlayer);
        foreach (RaycastHit hit in hits)
        {
            Renderer R = hit.collider.GetComponent<Renderer>();
            if (R == null)
            {
                continue;
            }
            else
            {
                layerNum = Mathf.Log(layerMask.value, 2);
            }// no renderer attached? go to next hit 
             // TODO: maybe implement here a check for GOs that should not be affected like the player
            AutoTransparent2 AT = R.GetComponent<AutoTransparent2>();
            if (AT == null && hit.collider.gameObject.layer != layerNum)  //if its a an object that should become transparent and if no script is attached, attach one
            {
                AT = R.gameObject.AddComponent<AutoTransparent2>();
                AT.FadeInTimeout = FadeInTimeout;
                AT.FadeOutTimeout = FadeOutTimeout;
                AT.TargetTransparency = TargetTransparency;
            }
            else if (AT)
                AT.BeTransparent(); // get called every frame to reset the falloff
        }
    }
}
