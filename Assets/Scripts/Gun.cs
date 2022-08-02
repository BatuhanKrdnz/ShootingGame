using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public float launchForce;
    public Transform shotPoint;

    public GameObject dot;
    GameObject[] dots;
    public int numberOfDots;
    public float spaceBetweenDots;

    Vector2 direction;

    private void Start()
    {
        dots = new GameObject[numberOfDots];
        for(int i = 0; i < numberOfDots; i++)
        {
            dots[i] = Instantiate(dot, shotPoint.position, Quaternion.identity);
        }
    }

    void Update()
    {
        Vector2 gunPosition = transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePosition - gunPosition;
        transform.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
        for (int i = 0; i < numberOfDots; i++)
        {
            dots[i].transform.position = DotPosition(i * spaceBetweenDots);
        }
    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(bullet, shotPoint.position, shotPoint.rotation);
        newBullet.GetComponent<Rigidbody2D>().velocity = transform.right * launchForce;
    }

    Vector2 DotPosition(float t)
    {
        Vector2 position = (Vector2)shotPoint.position + (direction.normalized * launchForce * t) + 0.5f * Physics2D.gravity * (t * t);
        return position;
    }

  
}
