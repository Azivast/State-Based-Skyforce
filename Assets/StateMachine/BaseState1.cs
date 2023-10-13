using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseState1<EState> where EState : Enum
{
    public BaseState1(EState key) {
        StateKey = key;
    }

    public EState StateKey { get; private set; }
    
    public abstract void EnterState();
    public abstract void ExitState();
    public abstract void UpdateState();
    public abstract EState GetNextState();
    public abstract void OnTriggerEnter2D(Collider2D col);
    public abstract void OnTriggerStay2D(Collider2D col);
    public abstract void OnTriggerExit2D(Collider2D col);
}
