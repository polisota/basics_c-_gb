using System;
using UnityEngine;
using Random = UnityEngine.Random;

public abstract class InteractiveObject : MonoBehaviour
{
    public bool IsInteractable { get; protected set; } = true;
    [SerializeField] protected bool DestroyImmediately;

    private void OnTriggerEnter(Collider other)
    {
        if (!IsInteractable || !other.CompareTag("Player"))
        {
            return;
        }
        Interaction(other.gameObject);
        if (DestroyImmediately)
        {
            Destroy(gameObject);
        }

    }

    protected abstract void Interaction(GameObject interacted);   

    public int CompareTo(InteractiveObject other)
    {
        return name.CompareTo(other.name);
    }
}