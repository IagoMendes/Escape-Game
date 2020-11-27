using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LivesUI : MonoBehaviour
{
    //public GameObject player;
    [SerializeField]
    RectTransform thrusterLivesFill;

    void SetLivesAmount(float _amount)
    {
        thrusterLivesFill.localScale = new Vector3(_amount/3,1f, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        float lives = PlayerPrefs.GetInt("Lives");
        //gameObject.GetComponent<Text>().text = "Lives " + lives.ToString();
        SetLivesAmount(lives);
    }
}
