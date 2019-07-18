using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject rain;
    void Start()
    {
      InvokeRepeating("Rain", 0, 0.3f);
    }
    void Rain()
    {
        Destroy(Instantiate(rain,transform.position,Quaternion.identity),2);
    }

}
