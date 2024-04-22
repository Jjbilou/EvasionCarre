using UnityEngine;

public class Borders : MonoBehaviour
{
    [SerializeField] float borderWidth;

    Transform borderLeft;
    Transform borderRight;
    Transform borderTop;
    Transform borderBottom;

    public float movingLeftTime = 0.0f;
    public float movingRightTime = 0.0f;
    public float movingTopTime = 0.0f;
    public float movingBottomTime = 0.0f;

    public float scalingLeftTime = 0.0f;
    public float scalingRightTime = 0.0f;
    public float scalingTopTime = 0.0f;
    public float scalingBottomTime = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        borderLeft = transform.Find("Left");
        borderRight = transform.Find("Right");
        borderTop = transform.Find("Top");
        borderBottom = transform.Find("Bottom");
    }

    void LateUpdate()
    {
        if (Time.frameCount % 2 == 0) // Update left and right borders
        {
            // Getting rotations in randians the borders currently have
            float topRotation = Mathf.PI * borderTop.localEulerAngles.z / 180.0f;
            float bottomRotation = Mathf.PI * borderBottom.localEulerAngles.z / 180.0f;

            // Getting the half of borders lengths
            Vector3 topHalfVector = (borderTop.localScale.x - borderWidth) / 2.0f * new Vector3(Mathf.Cos(topRotation), Mathf.Sin(topRotation));
            Vector3 bottomHalfVector = (borderBottom.localScale.x - borderWidth) / 2.0f * new Vector3(Mathf.Cos(bottomRotation), Mathf.Sin(bottomRotation));


            // Getting localPositions of borders ends
            Vector3 topLeft = borderTop.localPosition - topHalfVector;
            Vector3 topRight = borderTop.localPosition + topHalfVector;

            Vector3 bottomLeft = borderBottom.localPosition - bottomHalfVector;
            Vector3 bottomRight = borderBottom.localPosition + bottomHalfVector;

            // Getting rotations in degrees that the borders should have
            float leftAngle = Mathf.Atan2(topLeft.y - bottomLeft.y, topLeft.x - bottomLeft.x) * 180.0f / Mathf.PI - 90.0f;
            float rightAngle = Mathf.Atan2(topRight.y - bottomRight.y, topRight.x - bottomRight.x) * 180.0f / Mathf.PI - 90.0f;

            borderLeft.localRotation = Quaternion.Euler(0.0f, 0.0f, leftAngle);
            borderRight.localRotation = Quaternion.Euler(0.0f, 0.0f, rightAngle);

            // Scale the borders if they are not getting scaled by a GameEvent
            if (scalingLeftTime <= 0.0f)
            {
                borderLeft.localScale = new Vector3(borderWidth, Vector3.Distance(topLeft, bottomLeft) + borderWidth);
            }
            else
            {
                scalingLeftTime -= Time.deltaTime;
            }
            if (scalingRightTime <= 0.0f)
            {
                borderRight.localScale = new Vector3(borderWidth, Vector3.Distance(topRight, bottomRight) + borderWidth);
            }
            else
            {
                scalingRightTime -= Time.deltaTime;
            }

            // Move the borders if they are not getting moved by a GameEvent
            if (movingLeftTime <= 0.0f)
            {
                borderLeft.localPosition = Vector3.Lerp(topLeft, bottomLeft, 0.5f);
            }
            else
            {
                movingLeftTime -= Time.deltaTime;
            }
            if (movingRightTime <= 0.0f)
            {
                borderRight.localPosition = Vector3.Lerp(topRight, bottomRight, 0.5f);
            }
            else
            {
                movingRightTime -= Time.deltaTime;
            }
        }
        else // Update top and bottom borders
        {
            // Getting rotations in randians the borders currently have
            float leftRotation = Mathf.PI * (borderLeft.localEulerAngles.z / 180.0f + 0.5f);
            float rightRotation = Mathf.PI * (borderRight.localEulerAngles.z / 180.0f + 0.5f);

            // Getting the half of the borders lengths
            Vector3 leftHalfVector = (borderLeft.localScale.y - borderWidth) / 2.0f * new Vector3(Mathf.Cos(leftRotation), Mathf.Sin(leftRotation));
            Vector3 rightHalfVector = (borderRight.localScale.y - borderWidth) / 2.0f * new Vector3(Mathf.Cos(rightRotation), Mathf.Sin(rightRotation));

            // Getting localPositions of borders ends
            Vector3 leftTop = borderLeft.localPosition + leftHalfVector;
            Vector3 leftBottom = borderLeft.localPosition - leftHalfVector;

            Vector3 rightTop = borderRight.localPosition + rightHalfVector;
            Vector3 rightBottom = borderRight.localPosition - rightHalfVector;

            // Getting rotations in degrees that the borders should have
            float topAngle = Mathf.Atan2(rightTop.y - leftTop.y, rightTop.x - leftTop.x) * 180.0f / Mathf.PI;
            float bottomAngle = Mathf.Atan2(rightBottom.y - leftBottom.y, rightBottom.x - leftBottom.x) * 180.0f / Mathf.PI;

            borderTop.localRotation = Quaternion.Euler(0.0f, 0.0f, topAngle);
            borderBottom.localRotation = Quaternion.Euler(0.0f, 0.0f, bottomAngle);

            // Scale the borders if they are not getting scaled by a GameEvent
            if (scalingTopTime <= 0.0f)
            {
                borderTop.localScale = new Vector3(Vector3.Distance(rightTop, leftTop) + borderWidth, borderWidth);
            }
            else
            {
                scalingTopTime -= Time.deltaTime;
            }
            if (scalingBottomTime <= 0.0f)
            {
                borderBottom.localScale = new Vector3(Vector3.Distance(rightBottom, leftBottom) + borderWidth, borderWidth);
            }
            else
            {
                scalingBottomTime -= Time.deltaTime;
            }

            // Move the borders if they are not getting moved by a GameEvent
            if (movingTopTime <= 0.0f)
            {
                borderTop.localPosition = Vector3.Lerp(leftTop, rightTop, 0.5f);
            }
            else
            {
                movingTopTime -= Time.deltaTime;
            }
            if (movingBottomTime <= 0.0f)
            {
                borderBottom.localPosition = Vector3.Lerp(leftBottom, rightBottom, 0.5f);
            }
            else
            {
                movingBottomTime -= Time.deltaTime;
            }
        }
    }
}
