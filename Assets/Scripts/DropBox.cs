using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DropBox : MonoBehaviour
{
    public bool resetTable;
    public GameObject dropEffect;
    public GameObject resultText;
    public void DropObject()
    {
        if (!resetTable)
        {
            StartCoroutine(SetDropEffect());
        }
    }

    private IEnumerator SetDropEffect()
    {
        dropEffect.SetActive(true);
        resultText.SetActive(true);
        resultText.transform.DOPunchScale(new Vector3(1.3f, 1.3f, 1.3f), 0.5f);
        yield return new WaitForSeconds(2f);
        resultText.SetActive(false);
        dropEffect.SetActive(false);
    }
}
