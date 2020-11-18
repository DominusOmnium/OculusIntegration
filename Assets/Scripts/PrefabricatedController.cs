using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class PrefabricatedController : MonoBehaviour, IPrefabricated
{
    [SerializeField]
    private PrefabricatedStateChangeEvent _stateChanged;

    public PrefabricatedState currentState = PrefabricatedState.Empty;
    private int _correctPartsCount;
    private int partsCount;
    private List<IPrefabricated> prefabricatedList;

    public int correctPartsCount
    {
        get => _correctPartsCount;
        set
        {
            if (_correctPartsCount == value)
                return;
            _correctPartsCount = value;
            if (_correctPartsCount == 0)
                state = PrefabricatedState.Empty;
            else if (_correctPartsCount == partsCount)
                state = PrefabricatedState.Correct;
            else
                state = PrefabricatedState.Wrong;
        }
    }

    public PrefabricatedState state
    {
        get => currentState;
        private set
        {
            stateChanged?.Invoke(currentState, value, partsCount - correctPartsCount);
            currentState = value;
        }
    }
    public PrefabricatedStateChangeEvent stateChanged
    {
        get
        {
            if (_stateChanged == null)
                _stateChanged = new PrefabricatedStateChangeEvent();
            return _stateChanged;
        }
        set => _stateChanged = value;
    }

    void Awake()
    {
        prefabricatedList = new List<IPrefabricated>();
        for (int i = 0; i < transform.childCount; i++)
        {
            IPrefabricated p = transform.GetChild(i).GetComponent<IPrefabricated>();
            if (p != null)
                prefabricatedList.Add(p);
        }
        currentState = PrefabricatedState.Empty;
        correctPartsCount = 0;
        partsCount = prefabricatedList.Count;
    }

    private void OnEnable()
    {
        foreach (var p in prefabricatedList)
            p.stateChanged.AddListener(onChildStateChanged);
    }

    private void OnDisable()
    {
        foreach (var p in prefabricatedList)
            p.stateChanged.RemoveListener(onChildStateChanged);
    }

    void onChildStateChanged(PrefabricatedState oldState, PrefabricatedState newState, int wrongParts)
    {
        switch (newState)
        {
            case PrefabricatedState.Correct:
                correctPartsCount++;
                break;
            case PrefabricatedState.Wrong:
                if (oldState == PrefabricatedState.Correct)
                    correctPartsCount--;
                break;
            case PrefabricatedState.Empty:
                if (oldState == PrefabricatedState.Correct)
                    correctPartsCount--;
                break;
        }
    }
}
