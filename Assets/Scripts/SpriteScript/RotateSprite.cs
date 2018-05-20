using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateSprite : MonoBehaviour
{

    void Update ()
    {
        transform.rotation *= Quaternion.Euler(.0f, .0f, Time.deltaTime * 100.0f);
	}
}
