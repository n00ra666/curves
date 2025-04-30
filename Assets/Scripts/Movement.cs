using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Curve _curve;
    [SerializeField] float _speed = 1f;

    private float t = 0f;

    private void Update()
    {
        t = Mathf.PingPong(Time.time * _speed, 1f);

        Vector3 newPosition = _curve.GetPoint(t);

        transform.position = newPosition;
    }
}
