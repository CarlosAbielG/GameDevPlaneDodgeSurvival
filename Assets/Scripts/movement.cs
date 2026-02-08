using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    public float moveSpeed = 5f;

    public float padding = 0.2f;

    public float tiltAmount = 20f;
    public float tiltSmooth = 10f;

    Camera cam;

    float baseZ;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        baseZ = transform.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        float y = Input.GetAxis("Vertical");//move w/s

        //movement only on y
        Vector2 next = rb.position + Vector2.up*y*moveSpeed * Time.fixedDeltaTime;

        //clamp y to camera view
        float halfH = cam.orthographicSize;
        float minY = cam.transform.position.y - halfH + padding;
        float maxY = cam.transform.position.y + halfH + padding;

        next.y = Mathf.Clamp(next.y, minY, maxY);

        rb.MovePosition(next);

        //tilt
        float targetZ = baseZ + (y* tiltAmount);
        float z = Mathf.LerpAngle(transform.eulerAngles.z, targetZ, tiltSmooth * Time.fixedDeltaTime);
        transform.rotation = Quaternion.Euler(0,0,z);
    }
}
