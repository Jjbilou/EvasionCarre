using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class LevelMenuChange : MonoBehaviour
{
    [SerializeField] GameObject levels;
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;
    float currentPosition;

    void Start()
    {
        currentPosition = levels.transform.position.x;
    }

    void Update()
    {
        if (levels.transform.position == new Vector3(960f, 440f, 0f))
        {
            leftArrow.SetActive(false);
        }
        if (levels.transform.position == new Vector3(-840f, 440f, 0f))
        {
            rightArrow.SetActive(false);
        }
        print(levels.transform.position);
    }

    public void Right()
    {
        levels.transform.DOMoveX(currentPosition - 1800f, 1f);
        currentPosition -= 1800f; 
    }

    public void Left()
    {
        levels.transform.DOMoveX(currentPosition + 1800f, 1f);
        currentPosition += 1800f;
    }

    public void Hide()
    {
        StartCoroutine(HideCoroutine());
    }

    public IEnumerator HideCoroutine()
    {
        rightArrow.SetActive(false);
        leftArrow.SetActive(false);

        yield return new WaitForSeconds(1f);

        rightArrow.SetActive(true);
        leftArrow.SetActive(true);
    }
}