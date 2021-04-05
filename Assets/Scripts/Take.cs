using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
  public GameObject bandeira1;
    public GameObject player;


  bool condicao;

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "PlayerPrincipal"){
        Debug.Log("Tocou objeto");
    // this.gameobject.transform.position = player.transform.position + new Vector3(1f,1f,1f);
    }
  }
}
