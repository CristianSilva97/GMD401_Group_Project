using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ButtonWiggleEffect : MonoBehaviour
{
    public void WiggleButton()
    {
        StartCoroutine(WiggleEffect());
    }

    private IEnumerator WiggleEffect()
    {
        // Scale up
        transform.localScale = new Vector3(1.1f, 1.1f, 1.1f);
        yield return new WaitForSeconds(0.1f); // wait for 0.1 seconds

        // Scale down to normal
        transform.localScale = Vector3.one;
    }
}

