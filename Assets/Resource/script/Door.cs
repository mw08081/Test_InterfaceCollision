using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IOpenable
{
    public bool IsOpen { get; set; }
    
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void PrintLog()
    {
        
    }

    public void Interact()
    {
        if(IsOpen)
        {
            Close();
        }
        else
        {
            Open();
        }
    }

    public void Open()
    {
        IsOpen = true;
        StartCoroutine("OpenCoroutine");
    }

    public void Close()
    {
        IsOpen = false;
        StartCoroutine("CloseCoroutine");

    }

    IEnumerator OpenCoroutine()
    {
        yield return null;

        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(-Vector3.up);

            yield return new WaitForSeconds(0.003f);
        }
    }

    IEnumerator CloseCoroutine()
    {
        yield return null;

        for (int i = 0; i < 90; i++)
        {
            transform.Rotate(Vector3.up);

            yield return new WaitForSeconds(0.003f);
        }
    }

}
