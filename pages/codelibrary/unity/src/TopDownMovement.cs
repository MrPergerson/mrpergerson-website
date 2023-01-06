using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TopDownMovement : MonoBehaviour
{
    private Rigidbody rb;
    private float rotation;
    [SerializeField] private GameObject playerModel;
    private LayerMask lookMask;

    [SerializeField] private int speed = 5;
    [SerializeField] private int rotationSpeed = 5;
    [SerializeField] private int rotateSmoothing = 1000;

    public Vector3 MoveDirection { get; private set; }
    public bool IsMoving { get; private set; }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        foreach (Transform t in this.transform)
        {
            if (t.tag == "Model")
            {
                playerModel = t.gameObject;
                break;
            }
        }

        lookMask = LayerMask.GetMask("Default");
    }

    public void Move(Vector2 dir)
    {
        IsMoving = dir.sqrMagnitude > 0;
        

        if(IsMoving)
        {
            MoveDirection = new Vector3(dir.x, 0, dir.y).normalized;
            var processedDir = new Vector3(MoveDirection.x * speed, rb.velocity.y, MoveDirection.z * speed);

            rb.MovePosition(rb.position + processedDir * Time.deltaTime);
        }
    }

    public void RotateUsingMouse(Vector2 mousePosition)
    {
        var ray = Camera.main.ScreenPointToRay(mousePosition);

        if (Physics.Raycast(ray, out var hit, Mathf.Infinity, lookMask))
        {
            var heading = hit.point - transform.position;

            heading.y = 0;

            playerModel.transform.forward = heading;

        }     
    }

    public void RotateUsingGamepad(Vector2 look)
    {
        var playerDirection = Vector3.right * look.x + Vector3.forward * look.y;

        if (playerDirection.sqrMagnitude > 0.01f)
        {
            Quaternion newRotation = Quaternion.LookRotation(playerDirection, Vector3.up);
            playerModel.transform.rotation = Quaternion.RotateTowards(playerModel.transform.rotation, newRotation, rotateSmoothing * Time.deltaTime);
        }
    }

    public void RotateTowardsDirection(Vector3 dir)
    {
        var RotateTo = Vector3.RotateTowards(playerModel.transform.forward, dir, rotationSpeed * Time.deltaTime, 0f);
        playerModel.transform.rotation = Quaternion.LookRotation(RotateTo);
    }
}
