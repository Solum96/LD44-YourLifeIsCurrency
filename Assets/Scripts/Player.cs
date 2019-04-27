using UnityEngine;

public class Player : MonoBehaviour
{
    public float Oxygen = 1f;
    public float Speed = 5f;
    public Vector2 MovBounds;
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //Movement och sånt
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movementVector = new Vector3(horizontal,0,vertical).normalized;
        var wantedPosition = transform.position + movementVector * Time.deltaTime * Speed;
        _rb.MovePosition(GameBounds.ClampToBounds(wantedPosition));

        //Oxygen drop
        Oxygen -= Time.deltaTime * 0.001f;

        
    }
    void OnCollisionEnter(Collision collision)
    {
        Oxygen -= 0.2f;
    }


}
