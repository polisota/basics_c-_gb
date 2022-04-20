using UnityEngine;

public abstract class Player : MonoBehaviour
{
    public float Speed = 3.0f;
    protected Rigidbody _rigidbody;
    float moveHorizontal;
    float moveVertical;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    protected void Move()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        _rigidbody.AddForce(movement * Speed / Time.deltaTime);
    }
}