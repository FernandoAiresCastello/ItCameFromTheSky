using UnityEngine;
 using System.Collections;
 
 public class MainCameraController : MonoBehaviour
 {
     [SerializeField]
     public Transform target;
 
     [SerializeField]
     private Vector3 offsetPosition = new Vector3(0.0f,0.2f,-1.0f);
 
     [SerializeField]
     private Space offsetPositionSpace = Space.Self;
 
     [SerializeField]
     private bool lookAt = false;
 
     private void Update()
     {
         Refresh();
     }
 
     public void Refresh()
     {
         if(target == null)
         {
             Debug.LogWarning("Missing target ref !", this);
 
             return;
         }
 
         // compute position
         if(offsetPositionSpace == Space.Self)
         {
             transform.position = target.TransformPoint(offsetPosition);
         }
         else
         {
             transform.position = target.position + offsetPosition;
         }
 
         // compute rotation
         if(lookAt)
         {
             transform.LookAt(target);
         }
         else
         {
             transform.rotation = target.rotation;
         }
     }
 }
 