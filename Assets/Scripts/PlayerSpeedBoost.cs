using System.Collections;
using UnityEngine;

public class PlayerSpeedBoost : MonoBehaviour
{
    public float boostScale = 1.5f;

    void Update()
    {
        if(Input.GetKey(KeyCode.Space))
            Time.timeScale = boostScale;
        else
            Time.timeScale = 1f;
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}
