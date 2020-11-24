using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*[RequireComponent(typeof(Collider))]
public class OVRSnapPoint : MonoBehaviour
{
    [SerializeField]
    public Transform snapTransform;
    [SerializeField]
    public bool snapPosition = true;
    [SerializeField]
    public bool snapRotation = true;

    private OVRGrabbable _snappedObject = null;
    protected Dictionary<OVRGrabbable, int> m_grabCandidates = new Dictionary<OVRGrabbable, int>();

    
    private void OnTriggerEnter(Collider other)
    {
        OVRGrabbable grabbable;
        if ((grabbable = other.GetComponent<OVRGrabbable>()) == null)
            return;
        int refCount = 0;
        m_grabCandidates.TryGetValue(grabbable, out refCount);
        m_grabCandidates[grabbable] = refCount + 1;
    }

    private void OnTriggerExit(Collider other)
    {
        OVRGrabbable grabbable;
        if ((grabbable = other.GetComponent<OVRGrabbable>()) == null)
            return;

        int refCount = 0;
        bool found = m_grabCandidates.TryGetValue(grabbable, out refCount);
        if (!found)
            return;
        if (refCount > 1)
            m_grabCandidates[grabbable] = refCount - 1;
        else
            m_grabCandidates.Remove(grabbable);
    }

    private void Update()
    {
        if (_snappedObject != null)
        {
            if (_snappedObject.isGrabbed)
                _snappedObject = null;
        }
        else
            TrySnap();
    }

    private void TrySnap()
    {
        float closestMagSq = float.MaxValue;
        OVRGrabbable closestGrabbable = null;
        Collider closestGrabbableCollider = null;

        foreach (var grabCandidate in m_grabCandidates.Keys)
        {
            if (grabCandidate.isGrabbed)
                continue;

            for (int j = 0; j < grabCandidate.grabPoints.Length; ++j)
            {
                Collider grabbableCollider = grabCandidate.grabPoints[j];
                // Store the closest grabbable
                Vector3 closestPointOnBounds = grabbableCollider.ClosestPointOnBounds(snapTransform.position);
                float grabbableMagSq = (snapTransform.position - closestPointOnBounds).sqrMagnitude;
                if (grabbableMagSq < closestMagSq)
                {
                    closestMagSq = grabbableMagSq;
                    closestGrabbable = grabCandidate;
                    closestGrabbableCollider = grabbableCollider;
                }
            }
        }

        if (closestGrabbable == null)
            return;
        _snappedObject = closestGrabbable;
        _snappedObject.SnapBegin(this, closestGrabbableCollider);
        
        if (snapPosition)
        {
            if (_snappedObject.snapOffset != null && _snappedObject.snapPosition)
                _snappedObject.transform.position = snapTransform.position + _snappedObject.snapOffset.position;
            else
                _snappedObject.transform.position = snapTransform.position;

        }
        if (snapRotation)
        {
            if (_snappedObject.snapOffset != null && _snappedObject.snapOrientation)
                _snappedObject.transform.rotation = snapTransform.rotation * _snappedObject.snapOffset.rotation;
            else
                _snappedObject.transform.rotation = snapTransform.rotation;
        }
    }
}
*/