using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class RaycastReflection : MonoBehaviour
{
    [SerializeField] private int raysCount;
    [SerializeField] private float maxLength;

    [HideInInspector] public RaycastHit hit;
    public List<RaycastHit> hits = new List<RaycastHit>();
    private Ray ray;

    [HideInInspector] public LineRenderer lineRenderer;

    public bool isEnemy;

    private bool isGameStart;

    private void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();

        isGameStart = false;
    }

    private void Start()
    {
        UIManager.onStartGame += HandleStartGame;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameStart)
            CastRay(transform.position, transform.forward);
    }

    void CastRay(Vector3 position, Vector3 direction)
    {
        ray = new Ray(position, direction);

        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, position);
        float remainingLength = maxLength;

        for (int i = 0; i < raysCount; i++)
        {
            if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
            {

                hits.Add(hit);
                //Debug.DrawLine(position, hit.point, Color.red);
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);

                remainingLength -= Vector3.Distance(ray.origin, hit.point);

                ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                //direction = hit.normal;

                if (hit.collider.CompareTag("Enemy"))
                {
                    isEnemy = true;
                }
                else
                {
                    isEnemy = false;
                }

                if (!hit.collider.CompareTag("Reflector"))
                {
                    break;
                }

            }
            else
            {
                lineRenderer.positionCount += 1;
                lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength); ;

            }



        }
    }

    void HandleStartGame()
    {
        isGameStart = true;
    }
}
