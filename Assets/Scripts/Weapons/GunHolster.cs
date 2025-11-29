using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolster : MonoBehaviour
{
    private float _xInput;
    private float _yInput;

    void Update()
    {
        GetInput();
        Vector2 movement = new Vector2(_xInput, _yInput);
        // if (movement != Vector2.zero)
        // {
        //     Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, movement);
        //     transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, 800 * Time.deltaTime);
        // }

    }

    private void GetInput()
    {
        _xInput = Input.GetAxisRaw("Horizontal");
        _yInput = Input.GetAxisRaw("Vertical");
    }
}
