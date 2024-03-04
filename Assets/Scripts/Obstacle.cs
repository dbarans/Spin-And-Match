using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameObject targetObject;
    public float moveSpeed = 5f;
    private Vector3 direction;
    public Color obstacleColor;

    private void Awake()
    {
        
        targetObject = GameObject.FindGameObjectWithTag("Cube");
        direction = (targetObject.transform.position - transform.position).normalized;
        transform.LookAt(targetObject.transform);
        GetComponent<Renderer>().material.color = obstacleColor;

    }
    private void Update()
    {
       transform.position += direction * moveSpeed * Time.deltaTime;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Renderer renderer = collision.gameObject.GetComponent<Renderer>();
        Color objectColor = renderer.material.color;

        Debug.Log("Obstacle color: " + obstacleColor);
        Debug.Log("Object color: " + objectColor);
        if (objectColor == obstacleColor)
        {
           Destroy(gameObject);
        }
    }
}
