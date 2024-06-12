using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryLine : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private PlayerAimAndShoot _playerAimAndShoot;
    [SerializeField] private Transform _bulletSpawnPoint;
    [Header("Trajectory Line Smoothness/Lenght")]
    [SerializeField] private int _segmentCount = 50;
    [SerializeField] private float _curveLenght = 10f;

    private Vector2[] _segments;
    private LineRenderer _lineRenderer;

    private BulletBehaviour _bulletBehaviour;

    private float _projectileSpeed;
    private float _projectileGravityFromRB;

    private const float TIME_CURVE_ADDITION = 0.5F;

    private void start()
    {
        _segments = new Vector2[_segmentCount];

        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = _segmentCount;


        _bulletBehaviour = _playerAimAndShoot.GetComponent<BulletBehaviour>();
        

    }

    private void update()
    {
        Vector2 startPos= _bulletSpawnPoint.position;
        _segments[0]= startPos;
        _lineRenderer.SetPosition(0, startPos);

        Vector2 startVelocity = transform.right * _projectileSpeed;
        
        for (int i=1;i< _segmentCount;i++)
        {
        
            float timeOffset = (i * Time.fixedDeltaTime * _curveLenght);
            Vector2 gravityOffset = TIME_CURVE_ADDITION * Physics2D.gravity * _projectileGravityFromRB * Mathf.Pow(timeOffset, 2);

            _segments[i] = _segments[0] + startVelocity * timeOffset + gravityOffset;
            _lineRenderer.SetPosition(i, _segments[i]);
        }



    }
}
