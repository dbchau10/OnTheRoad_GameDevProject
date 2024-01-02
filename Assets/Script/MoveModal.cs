using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MoveModal : MonoBehaviour
{
    public string content;
    public TextMeshProUGUI alertContentText;
    public float speed = 2000.0f;
    private RectTransform rectTransform;
    private bool moveDown = false;
    private float targetY = 450f;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        MoveDownModal(content);
    }

    void Update()
    {
        if (moveDown)
        {
            // Di chuyển modal xuống dưới màn hình
            rectTransform.Translate(Vector3.down * speed * 12 * Time.deltaTime);

            // Kiểm tra nếu modal đã đạt vị trí dừng
            if (rectTransform.localPosition.y <= targetY)
            {
                moveDown = false;
                rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, targetY, rectTransform.localPosition.z);
            }
        }
    }

    public void MoveDownModal(string content)
    {
        // Set nội dung cho Text trong modal
        // Ví dụ: textObject.text = content;
        if (alertContentText != null)
        {
            alertContentText.text = content;
        }

        // Reset vị trí của modal về trên cùng của màn hình trước khi di chuyển
        rectTransform.localPosition = new Vector3(rectTransform.localPosition.x, Screen.height / 2, rectTransform.localPosition.z);
        moveDown = true;
    }
}
