using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed = 5;
    public Vector2 MovBounds;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Movement och sånt
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var movementVector = new Vector3(horizontal,0,vertical).normalized;
        var wantedPosition = transform.position + movementVector * Time.deltaTime * Speed;
        transform.position = GameBounds.ClampToBounds(wantedPosition);
       

    }
}
