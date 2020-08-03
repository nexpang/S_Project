using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : RightUnit
{
    protected override IEnumerator Attack()
    {
        isAttack = true;
        yield return new WaitForSeconds(0.1f);
        isAttack = false;
    }
}
