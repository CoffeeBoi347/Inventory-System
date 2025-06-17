using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class RotateObject : MonoBehaviour
{
    public float quaternion;
    public Rigidbody2D rb;

    private void Start()
    {
        StartCoroutine(DestroyObjectAfterTime(5f));
    }

    private void Update()
    {
        rb.AddTorque(quaternion * Time.deltaTime);
    }

    private IEnumerator DestroyObjectAfterTime(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(this.gameObject);
    }
}