using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public float horizontal { get; set; }
    public float vertical { get; set; }
    public bool mouseButtonDown { get; set; }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        mouseButtonDown = Input.GetMouseButtonDown(0);
    }
}
