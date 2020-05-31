using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target;
    GameObject[] _player,_bot;
    public float smoothSpeed = 0.125f;
    public Vector3 offset;
    void Start()
    {
        _player = GameObject.FindGameObjectsWithTag("Player");
    }
    void FixedUpdate()
    {
        Vector3 desiredPosition = _player[GameManager.charsize].transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
        if (GameManager.charsize > 0)
        {
            _player[GameManager.charsize].gameObject.GetComponent<bot_player>().enabled = true;
        }
    }
}
