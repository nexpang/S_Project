using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : Unit
{
    protected override IEnumerator Attack()
    {
        yield return new WaitForSeconds(0.1f);
    }
}
