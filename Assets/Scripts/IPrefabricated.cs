using System;
using UnityEngine.Events;

public enum PrefabricatedState { Empty, Correct, Wrong }

[System.Serializable]
public class PrefabricatedStateChangeEvent : UnityEvent<PrefabricatedState, PrefabricatedState, int> { }

public interface IPrefabricated
{
    PrefabricatedState state { get; }
    PrefabricatedStateChangeEvent stateChanged { get; set; }
}
