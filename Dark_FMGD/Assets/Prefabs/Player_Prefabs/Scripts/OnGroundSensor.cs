using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnGroundSensor : MonoBehaviourPun
{
    public CapsuleCollider capcol;
    public float offset = 0.1f;
    
    private Vector3 point1;
    private Vector3 point2;
    private float radius;
    
    // Start is called before the first frame update
    void Awake()
    {
        radius = capcol.radius- 0.05f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if ((!photonView.IsMine || !PhotonNetwork.IsConnected)
        || gameObject.layer != LayerMask.NameToLayer("Enemy")) return;*/
        point1 = transform.position + transform.up * (radius - offset);
        point2 = transform.position + transform.up * (capcol.height-offset) - transform.up * radius;

        Collider[] outputCols = Physics.OverlapCapsule(point1, point2, radius,LayerMask.GetMask("IsGround"));
        if(outputCols.Length!=0)
        {
            SendMessageUpwards("IsGround");
        }
        else
        {
            SendMessageUpwards("IsNotGround");
        }
        
    }
}
