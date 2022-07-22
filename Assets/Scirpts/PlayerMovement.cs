using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [HideInInspector]public float speed = 2000f;//скорость не меняется
    [HideInInspector]private CharacterController controller;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }
    void Update()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal") * speed, 0, Input.GetAxis("Vertical") * speed);
        controller.Move(move * Time.deltaTime * speed);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }   
    }
}