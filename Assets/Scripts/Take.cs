using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Take : MonoBehaviour
{
  public GameObject bandeira1;

  private void OnTriggerEnter(Collider other)
  {
    if(other.gameObject.tag == "PlayerPrincipal"){
      bandeira1.SetActive(true);
    }
  }
}
