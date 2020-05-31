using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bot_player : MonoBehaviour
{
    public Transform finishline;
    public float speed, y_speed;
    public LayerMask layer;
    public GameObject pos;

    private Rigidbody2D rb;

    bool click, ground = true;
    RaycastHit ray;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (!click)
        {
            if (Input.GetMouseButton(0))
            {
                ground = false;
                Vector3 clickpos = -Vector3.one;
                Plane plane = new Plane(Vector3.forward, 0f);
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                float distancetoplane;
                if (plane.Raycast(ray, out distancetoplane))
                {
                    clickpos = ray.GetPoint(distancetoplane);
                    pos.transform.position = new Vector3(clickpos.x, clickpos.y, -0.46f);
                }
            }
            if (!ground)
            {
                if (this.transform.position.y <= pos.transform.position.y)
                {
                    speed = 0.1f;
                    movement();
                }
                else
                {
                    speed = 0.05f;
                    movement();
                }
            }
        }
        else
        {
            speed = 0.2f;
            StopCoroutine(stop());
            movement();
        }
        if (this.transform.position.x > finishline.transform.position.x && !click)
        {
            movement();
            GameManager.charsize++;
            speed = 0.03f;
            y_speed = 0;
            click = true;
        }
    }
      
void movement()
    {
        transform.Translate(speed, y_speed, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "zemin")
        {
            ground = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "stairs")
        {
            speed = 0.01f;
            y_speed = 0.08f;
            rb.gravityScale = 0;
        }
    }
    IEnumerator stop()
    {
        yield return new WaitForSeconds(2);
        speed = 0f;
        y_speed = 0f;
    }
}
