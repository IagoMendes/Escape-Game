using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BulletsUI : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        float bullets = PlayerPrefs.GetInt("Bullets");
        gameObject.GetComponent<Text>().text = bullets.ToString(); // + "/15";
    }
}
