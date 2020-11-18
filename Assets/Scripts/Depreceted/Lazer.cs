using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float defDistanceRay = 100;
    public Transform laserFirePoint;
    public LineRenderer lineRenderer;
    private Transform m_Transform;

    private void Awake()
    {
        m_Transform = GetComponent<Transform>();
    }

    private void Update()
    {
        ShootLaser();
    }

    void ShootLaser()
    {
        if (Physics2D.Raycast(m_Transform.position, transform.right))
        {
            RaycastHit2D hit = Physics2D.Raycast(laserFirePoint.position, transform.right);
            Draw2DRay(laserFirePoint.position, hit.point);
        }
        else
        {
            Draw2DRay(laserFirePoint.position, laserFirePoint.transform.right * defDistanceRay);
        }
    }

    void Draw2DRay(Vector2 startPos, Vector2 endPos)
    {
         lineRenderer.SetPosition(0, startPos);
         lineRenderer.SetPosition(0, endPos);

    }
}
