using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class ARInteractableObject : MonoBehaviour
{
    //List of interactables I am interacting with
    private List<ARInteractableObject> _interactables = new List<ARInteractableObject>();
    //State of this interactable
    protected enum State
    {
        Idle, Active
    }
    protected State ARObjectState = State.Idle;

    //Get ARInteractableObject when trigger enters and exits
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<ARInteractableObject>(out var interactable))
        {
            AddInteractable(interactable);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<ARInteractableObject>(out var interactable))
        {
            RemoveInteractable(interactable);
        }
    }

    protected void AddInteractable(ARInteractableObject interactable)
    {
        _interactables.Add(interactable);
        SetState(State.Active);
    }

    protected void RemoveInteractable(ARInteractableObject interactable)
    {
        _interactables.Remove(interactable);
        if(_interactables.Count == 0) SetState(State.Idle);
    }

    //what happens when this object gets disabled
    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.RemoveInteractable(this);
        }
        _interactables.Clear();
        SetState(State.Idle);
    }
    
    //update the state of this AR object
    protected virtual void SetState(State state)
    {
        ARObjectState = state;
    }
}
