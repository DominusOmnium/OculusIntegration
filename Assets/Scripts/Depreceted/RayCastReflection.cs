using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*[RequireComponent(typeof(LineRenderer))]
public class RayCastReflection : MonoBehaviour
{
    public int reflections;
    public float maxLength;
    private LineRenderer m_LineRenderer;
    private Ray m_Ray;
    private RaycastHit m_Hit;
    private Vector3 m_Direction;

    private void Awake()
    {
        m_LineRenderer = GetComponent<LineRenderer>();
    }

    private void Update()
    {
        m_Ray = new Ray(transform.position, transform.forward);
        m_LineRenderer.positionCount = 1;
        m_LineRenderer.SetPosition(0, transform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            if (Physics.Raycast(m_Ray.origin, m_Ray.direction, out m_Hit, remainingLength))
            {
                m_LineRenderer.positionCount += 1;
                m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1, m_Hit.point);
                remainingLength -= Vector3.Distance(m_Ray.origin, m_Hit.point);
                m_Ray = new Ray(m_Hit.point, Vector3.Reflect(m_Ray.direction, m_Hit.normal));
                if (m_Hit.collider.tag != "Mirror")
                    break;
            }
            else
            {
                m_LineRenderer.positionCount += 1;
                m_LineRenderer.SetPosition(m_LineRenderer.positionCount - 1,
                    m_Ray.origin + m_Ray.direction * remainingLength);
            }
        }
    }
}
*/