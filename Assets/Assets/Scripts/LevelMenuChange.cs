using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelMenuChange : MonoBehaviour
{
    [SerializeField] Transform levels;
    [SerializeField] GameObject leftArrow;
    [SerializeField] GameObject rightArrow;
    readonly List<Button> buttons = new(); 

    void Start()
    {
        GameObject[] levelsButtons = GameObject.FindGameObjectsWithTag("LevelsButtons");

        foreach (GameObject buttonObject in levelsButtons)
        {
            Button btn = buttonObject.GetComponent<Button>();
            buttons.Add(btn); 
        }
    }

    void LateUpdate()
    {
        if (levels.localPosition.x > -1.0f)
        {
            leftArrow.SetActive(false);
        }

        if (levels.localPosition.x < -2559.0f)
        {
            rightArrow.SetActive(false);
        }
    }

    public void Right()
    {
        levels.DOMoveX(-1800f / 1920.0f * Screen.width, 1f).SetRelative();
    }

    public void Left()
    {
        levels.DOMoveX(1800f / 1920.0f * Screen.width, 1f).SetRelative();
    }

    public void Hide()
    {
        StartCoroutine(HideCoroutine());
    }

    public IEnumerator HideCoroutine()
    {
        leftArrow.SetActive(false);
        rightArrow.SetActive(false);

        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }

        yield return new WaitForSeconds(1.1f);

        leftArrow.SetActive(true);
        rightArrow.SetActive(true);

        foreach (Button btn in buttons)
        {
            btn.interactable = true;
        }
    }
}
