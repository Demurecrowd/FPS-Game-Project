using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable
{
    void ShotReaction(RaycastHit hit, int damageAmount);
}
