using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public int ID;

    public StateMachine(int id)
    {
        ID = id;
    }

    public delegate void DelegateNoArg();

    public DelegateNoArg OnEnter;
    public DelegateNoArg OnExit;
    public DelegateNoArg OnUpdate;

    public void Enter()
    {
        OnEnter?.Invoke();
    }

    public void Exit()
    {
        OnExit?.Invoke();
    }

    public void Update()
    {
        OnUpdate?.Invoke();
    }
}

public class FiniteStateMachine
{

    private Dictionary<int, StateMachine> stateMachineDict;

    private StateMachine currentStateMachine;

    public FiniteStateMachine()
    {
        stateMachineDict = new Dictionary<int, StateMachine>();
    }

    public void AddState(StateMachine state)
    {
        stateMachineDict.Add(state.ID, state);
    }

    public StateMachine GetState(int id)
    {
        if (stateMachineDict.ContainsKey(id))
        {
            return stateMachineDict[id];
        }
        else
        {
            return null;
        }
    }

    private void SetCurrentState(StateMachine newState)
    {

        // If new state is same as current state, do nothing
        if (currentStateMachine == newState)
        {
            return;
        }

        // Change state process

        // First, exit from the current state
        if (currentStateMachine != null)
        {
            currentStateMachine.Exit();
        }

        // Second, enter a new state
        newState.Enter();

        // Finally, update currentStateMachine variable
        currentStateMachine = newState;
    }

    public void ChangeCurrentState(int id)
    {
        if (stateMachineDict.ContainsKey(id))
        {
            if (id >= 10)
            {
                StateMachine PriceofCan = stateMachineDict[0];
                SetCurrentState(PriceofCan);
            }

            StateMachine newState = stateMachineDict[id];
            SetCurrentState(newState);
        }
    }

    public void UpdateCurrentState()
    {
        if (currentStateMachine != null)
        {
            currentStateMachine.Update();
        }
    }
}
