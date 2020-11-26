using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    [SerializeField] private int numOfReflections;
    [SerializeField] private float maxLength;

    private LineRenderer lineRenderer;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 direction;

    private float remainingLength;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        
    }


    // Update is called once per frame
    void Update()
    {
        ray = new Ray(transform.position , transform.forward );

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, transform.position);

        remainingLength = maxLength;

        for (int i = 0; i < numOfReflections; i++)
        {
            if(Physics.Raycast(ray.origin , ray.direction , out hit , remainingLength))
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                remainingLength -= Vector3.Distance(ray.origin, hit.point);
                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));

                if (!hit.collider.CompareTag("Reflector"))
                {
                    break;
                }
            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }
        }
    }
}
