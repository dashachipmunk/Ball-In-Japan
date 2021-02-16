using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    float yPosition;
    public float xMax;
    [Tooltip("Ссылка на мяч")]
    public Ball ball;
    [Tooltip("Режим автоматической игры для проверки")]
    public bool autoplay;
    public GameManager gM;
    public HeartsBar healthOver;
    void Start()
    {
        yPosition = transform.position.y;
    }

    void Update()
    {
        if (gM.isPaused)
        {
            return;
        }
        if (healthOver.isDead)
        {
            return;
        }
        if (autoplay)
        {
            Vector3 ballPos = ball.transform.position;
            Vector3 newPadPos = new Vector3(ballPos.x, yPosition, 0);
            newPadPos.x = Mathf.Clamp(newPadPos.x, -xMax, xMax);
            transform.position = newPadPos;
        }
        else
        {
            Vector3 mousePixelPoint = Input.mousePosition;
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);
            Vector3 padNewPosition = new Vector3(mouseWorldPosition.x, yPosition, 0);

            padNewPosition.x = Mathf.Clamp(padNewPosition.x, -xMax, xMax);
            transform.position = padNewPosition;
        }
    }
    public void PadScale(float newSize)
    {
        transform.localScale = new Vector3(1, transform.localScale.y * newSize, 1);
    }
}
