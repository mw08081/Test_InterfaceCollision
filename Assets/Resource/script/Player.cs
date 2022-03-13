using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum InteractionCode : int
{
    Open = 0,
    Obatain,

};

public class Player : MonoBehaviour, IPlayer
{
    public bool CanInteraction { get; set; }

    void Start()
    {
        CanInteraction = true;
    }
    
    void Update()
    {
        Move();
        Attack();

        RayCastCheck();
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Vertical");
        float y = Input.GetAxisRaw("Horizontal");

        Vector3 moveDir = new Vector3(x, 0, 0);
        Vector3 rotDir = new Vector3(0, y, 0);

        transform.position += moveDir * 5f * Time.deltaTime;
        transform.Rotate(rotDir * Time.deltaTime * 30f);
    }

    public void Attack()
    {

    }

    public void RayCastCheck()
    {
        RaycastHit hitInfo;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 2f))
        {
            if (hitInfo.collider.GetComponent<IOpenable>() is IOpenable)
            {
                Debug.Log("u can Interact, Interact use 'F'");
                InteractionF(hitInfo);
            }
        }
    }

    public void InteractionF(RaycastHit hitInfo)
    {
        if (Input.GetKey(KeyCode.F) && CanInteraction)
        {
            CanInteraction = false;
            Open(hitInfo.collider.GetComponent<IOpenable>());
        }
    }

    void Open(IOpenable openTarget)
    {
        openTarget.Interact();
        Invoke("SetCanInteraction", 1f);
    }

    void SetCanInteraction()
    {
        CanInteraction = true;
    }
}
