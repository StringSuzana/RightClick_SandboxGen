using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    public virtual CharacterState HandleInput()
    {
        return this;
    }
    public virtual void HandlePhysics()
    {

    }
}
