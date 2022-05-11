using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingMachineExample : MonoBehaviour
{
    private FiniteStateMachine finiteStateMachine;
    private int x = 0;

    private void Initialize()
    {
        finiteStateMachine = new FiniteStateMachine();
     
        StateMachine _5PfState = new StateMachine(5);
        _5PfState.OnEnter += () => 
        {
            Debug.Log("5P, No can");
        };

        finiteStateMachine.AddState(_5PfState);

       
        
        StateMachine _10PfState = new StateMachine(10);
        _10PfState.OnEnter += () => 
        {
            Debug.Log("10P, No can");
        };

        finiteStateMachine.AddState(_10PfState);

       
        
        StateMachine _15PfState = new StateMachine(15);
        _15PfState.OnEnter += () => 
        {
            Debug.Log("Can");
            Debug.Log("Machine Reset");
            Debug.Log("---------------");
            x = 0;
        };

        finiteStateMachine.AddState(_15PfState);

        // Set default state
        finiteStateMachine.ChangeCurrentState(0);
    }

    private void Awake()
    {
        Initialize();
    }

    void Start()
    {
        Debug.Log("----Press Up Arrow to Add 5P----");
        Debug.Log("----Press Down Arrow to Add 10P----");
    }


    void Update()
    {
        UpdateKeyboardInput();
        finiteStateMachine.UpdateCurrentState();
    }

    private void UpdateKeyboardInput()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("Add 5P");
            x += 5;
            finiteStateMachine.ChangeCurrentState(x);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("Add 10P");
            x += 10;

            if (x > 15)
            {
                x = 15;
            }

            finiteStateMachine.ChangeCurrentState(x);
        }
    }
}
