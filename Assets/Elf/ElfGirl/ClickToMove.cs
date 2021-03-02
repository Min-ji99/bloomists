using System.Collections;
using System.Collections.Generic;
using UnityEngine;





public class ClickToMove : MonoBehaviour
{
    private Camera camera;
    private Animator animator;

    private bool isMove;
    private Vector3 destination;

    private void Awake()
    {
        camera = Camera.main;
        animator = GetComponent<Animator>();

    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            RaycastHit hit;
            if (Physics.Raycast(camera.ScreenPointToRay(Input.mousePosition), out hit))
            {
                SetDestination(hit.point);
            }
        }
        Move();
    }

    private void SetDestination(Vector3 dest)
    {
        destination = dest;
        isMove = true;
        animator.SetBool("Walk", true);
    }

    private void Move()
    {
        if (isMove)
        {

            if (Vector3.Distance(transform.position, destination) <= 0.1f)
            {
                isMove = false;
                animator.SetBool("Walk", false);
            }

            var dir = destination - transform.position;
            transform.forward = dir;
            transform.position += dir.normalized * Time.deltaTime * 1f;

        }

    }



}
