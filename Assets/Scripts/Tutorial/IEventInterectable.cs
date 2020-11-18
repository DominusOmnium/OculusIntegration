using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public interface  IEventInterectable
{
    void Resolve(int nQuest);
    //void Finish(int nquest);
    UnityEvent GetEvent(int nEvent);

    GameObject GetGameObject();
}
