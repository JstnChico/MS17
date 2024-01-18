using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Transform teleportTarget;
    public GameObject thePlayer;
    public FadeScreen fadeScreen;

    void Start()
    {
        StartCoroutine(Teleport1());
    }

    IEnumerator Teleport1()
    {
        fadeScreen.Fadeout();
        yield return new WaitForSeconds(fadeScreen.fadeDuration);
        fadeScreen.Fadein();
        thePlayer.transform.position = teleportTarget.transform.position;
    }
}
