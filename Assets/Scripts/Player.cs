using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private void Update()
    {
        float horizontal = Input.GetAxis("Mouse X");
        transform.position += new Vector3(horizontal, 0, 0);
    }
}
