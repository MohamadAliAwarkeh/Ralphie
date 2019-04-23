using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDestructable : MonoBehaviour
{
    public GameObject leafOne;
    public GameObject leafTwo;
    public GameObject leafThree;
    public GameObject leafFour;
    public AudioSource audioClip;

    public void Start()
    {
        audioClip = GetComponent<AudioSource>();
    }

    public void Destroy()
    {
        Instantiate(leafOne, transform.position, Quaternion.identity);
        Instantiate(leafTwo, transform.position, Quaternion.identity);
        Instantiate(leafThree, transform.position, Quaternion.identity);
        Instantiate(leafFour, transform.position, Quaternion.identity);
        audioClip.Play();
        Destroy(gameObject);
    }
}
