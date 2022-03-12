using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IOpenable
{
    bool IsOpen { get; set; }

    void PrintLog();

    void Interact();
    void Open();
    void Close();
}