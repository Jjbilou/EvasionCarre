using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] float borderWidth;
    
    GameObject borderLeft;
    GameObject borderRight;
    GameObject borderTop;
    GameObject borderBottom;

    // Start is called before the first frame update
    void Start()
    {
        borderLeft = GameObject.Find("Left");
        borderRight = GameObject.Find("Right");
        borderTop = GameObject.Find("Top");
        borderBottom = GameObject.Find("Bottom");
    }

    // Update is called once per frame
    void LateUpdate()
    {
        float sizeX = Vector2.Distance(borderTop.transform.position, borderBottom.transform.position) + borderWidth;
        float sizeY =  Vector2.Distance(borderLeft.transform.position, borderRight.transform.position) + borderWidth;

        borderLeft.transform.localScale = new Vector3(borderWidth, sizeY, 1.0f);
        borderRight.transform.localScale = new Vector3(borderWidth, sizeY, 1.0f);
        borderTop.transform.localScale = new Vector3(sizeX, borderWidth, 1.0f);
        borderBottom.transform.localScale = new Vector3(sizeX, borderWidth, 1.0f);
    }
}
