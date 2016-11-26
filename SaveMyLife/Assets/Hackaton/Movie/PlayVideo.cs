using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayVideo : MonoBehaviour
{
    public MovieTexture movTexture;
    void Start()
    {
        GetComponent<RawImage>().material.mainTexture = movTexture;
        movTexture.loop = true;
        movTexture.Play();        
    }
}