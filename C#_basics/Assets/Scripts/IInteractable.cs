﻿public interface IInteractable : IAction, IInitialization
{
    bool IsInteractable { get; }
}