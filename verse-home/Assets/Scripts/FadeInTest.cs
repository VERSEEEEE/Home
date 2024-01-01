using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeInTest : MonoBehaviour
{
    Image TestImage;
    Color tmpColor;
    void Start()
    {
        tmpColor = Color.black;
        tmpColor.a = 1f;  //255°ª
        TestImage = GetComponent<Image>();
        TestImage.color = tmpColor;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            tmpColor.a -= 0.01f;
            TestImage.color = tmpColor;
        }
    }
}
