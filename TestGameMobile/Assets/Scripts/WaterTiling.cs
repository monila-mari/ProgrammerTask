using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterTiling : MonoBehaviour
{
    public float textureScaleX = 70.0f; 
    public float textureScaleY = 70.0f;  

    void Start()
    {
        // ��������� �������� �������� �� ���������
        GetComponent<MeshRenderer>().material.mainTextureScale = new Vector2(textureScaleX, textureScaleY);
    }
}
