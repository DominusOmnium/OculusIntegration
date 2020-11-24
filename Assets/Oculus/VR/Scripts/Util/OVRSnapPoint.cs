/************************************************************************************
Copyright : Copyright (c) Facebook Technologies, LLC and its affiliates. All rights reserved.

Licensed under the Oculus Master SDK License Version 1.0 (the "License"); you may not use
the Utilities SDK except in compliance with the License, which is provided at the time of installation
or download, or which otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at
https://developer.oculus.com/licenses/oculusmastersdk-1.0/

Unless required by applicable law or agreed to in writing, the Utilities SDK distributed
under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF
ANY KIND, either express or implied. See the License for the specific language governing
permissions and limitations under the License.
************************************************************************************/

using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
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
        if ((grabbable = other.GetComponent<OVRGrabbable>() ?? other.GetComponentInParent<OVRGrabbable>()) == null)
            return;
        int refCount = 0;
        m_grabCandidates.TryGetValue(grabbable, out refCount);
        m_grabCandidates[grabbable] = refCount + 1;
    }

    private void OnTriggerExit(Collider other)
    {
        OVRGrabbable grabbable;
        if ((grabbable = other.GetComponent<OVRGrabbable>() ?? other.GetComponentInParent<OVRGrabbable>()) == null)
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
            if (_snappedObject.snapTransform != null)
                _snappedObject.transform.position = snapTransform.position - /*(_snappedObject.snapTransform.position - _snappedObject.transform.position)*/_snappedObject.snapTransform.localPosition;
            else
                _snappedObject.transform.position = snapTransform.position;

        }
        if (snapRotation)
        {
            if (_snappedObject.snapTransform != null)
                _snappedObject.transform.rotation = snapTransform.rotation * (_snappedObject.snapTransform.rotation * Quaternion.Inverse(_snappedObject.transform.rotation));
            else
                _snappedObject.transform.rotation = snapTransform.rotation;
        }
    }
}