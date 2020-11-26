using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestIndicatorRegister : MonoBehaviour
{
    [Range(5,30)]
    [SerializeField] float destroyTimer = 20.0f;


    // Start is called before the first frame update
    void Start()
    {
        Invoke("Register", Random.Range(0, 8));
    }


    void Register()
    {
        if (DI_System.CheckIfObjectInSight(this.transform))
        {
            DI_System.CreateIndicator(this.transform);
            Debug.Log("INDICATOR CREATED");
        }
        Destroy(this.gameObject, destroyTimer);
    }
}
