using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] float borderWidth;

    Transform borderLeft;
    Transform borderRight;
    Transform borderTop;
    Transform borderBottom;

    // Start is called before the first frame update
    void Start()
    {
        borderLeft = GameObject.Find("Left").transform;
        borderRight = GameObject.Find("Right").transform;
        borderTop = GameObject.Find("Top").transform;
        borderBottom = GameObject.Find("Bottom").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float middleX = (borderRight.localPosition.x + borderLeft.localPosition.x) / 2.0f;
        float middleY = (borderTop.localPosition.y + borderBottom.localPosition.y) / 2.0f;

        borderLeft.localPosition = new Vector3(borderLeft.localPosition.x, middleY, 0.0f);
        borderRight.localPosition = new Vector3(borderRight.localPosition.x, middleY, 0.0f);
        borderTop.localPosition = new Vector3(middleX, borderTop.localPosition.y, 0.0f);
        borderBottom.localPosition = new Vector3(middleX, borderBottom.localPosition.y, 0.0f);

        float sizeX = Vector2.Distance(borderTop.position, borderBottom.position) + borderWidth;
        float sizeY = Vector2.Distance(borderLeft.position, borderRight.position) + borderWidth;

        borderLeft.localScale = new Vector3(borderWidth, sizeY, 1.0f);
        borderRight.localScale = new Vector3(borderWidth, sizeY, 1.0f);
        borderTop.localScale = new Vector3(sizeX, borderWidth, 1.0f);
        borderBottom.localScale = new Vector3(sizeX, borderWidth, 1.0f);
    }
}
