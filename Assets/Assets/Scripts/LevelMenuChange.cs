using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class LevelMenuChange : MonoBehaviour
{
    [SerializeField] GameObject levels;
    [SerializeField] GameObject rightArrow;
    [SerializeField] GameObject leftArrow;
    float currentPosition;
    List<Button> buttons = new List<Button>(); 

    void Start()
    {
        currentPosition = levels.transform.position.x;
        GameObject[] levelsButtons = GameObject.FindGameObjectsWithTag("LevelsButtons");

        foreach (GameObject buttonObject in levelsButtons)
        {
            Button btn = buttonObject.GetComponent<Button>();
            buttons.Add(btn); 
        }
    }

    void Update()
    {
        if (levels.transform.position == new Vector3(960f, 440f, 0f))
        {
            leftArrow.SetActive(false);
        }
        if (levels.transform.position == new Vector3(-2640f, 440f, 0f))
        {
            rightArrow.SetActive(false);
        }
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

        foreach (Button btn in buttons)
        {
            btn.interactable = false;
        }

        yield return new WaitForSeconds(1.1f);

        rightArrow.SetActive(true);
        leftArrow.SetActive(true);

        foreach (Button btn in buttons)
        {
            btn.interactable = true;
        }
    }
}
