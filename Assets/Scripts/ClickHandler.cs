using UnityEngine;

public class ClickHandler : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 clickPosition = Input.mousePosition;
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;
            float halfScreenWidth = screenWidth / 2f;
            float halfScreenHeight = screenHeight / 2f;

            float xValue = clickPosition.x - halfScreenWidth;
            float yValue = clickPosition.y - halfScreenHeight;

            xValue = Mathf.Clamp(xValue, -30f, 30f);
            yValue = Mathf.Clamp(yValue, -30f, 30f);

            Debug.Log(xValue + ", " + yValue);
        }
    }
}
