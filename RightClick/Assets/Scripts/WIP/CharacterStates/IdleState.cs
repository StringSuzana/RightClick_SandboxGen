using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : CharacterState
{
    public override CharacterState HandleInput()
    {
        return this;
    }
}
