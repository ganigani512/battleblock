using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiBehaviour : IUnitBehaviour
{
    Unit unit;
    public void End()
    {
    }

    public void SetUp()
    {
    }

    public bool Update()
    {
        return false;
    }
    AiBehaviour(Unit _unit)
    {
        unit = _unit;
    }
}
