using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

    public Material[] material;           // 割り当てるマテリアル

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Explosion"))
        {
            switch (GlobalStateManager.expNum)
            {
                case 1:
                    GetComponent<Renderer>().material = material[1];
                    break;

                case 2:
                    GetComponent<Renderer>().material = material[2];
                    break;

                default:
                    break;
            }
        }
    }
}
