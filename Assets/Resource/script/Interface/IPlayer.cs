using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IPlayer
{
    bool CanInteraction { get; set; }

    void Move();
    void Attack();
    void InteractionF(RaycastHit hitInfo);
}