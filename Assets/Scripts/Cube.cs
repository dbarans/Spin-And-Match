using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public float rotationSpeed = 360f;
    private bool isRotating = false;
    private Quaternion targetRotation;
    private SpawnerManager spawnerManager;
    private GameObject[] walls;

    private void Awake()
    {
        spawnerManager = FindObjectOfType<SpawnerManager>();
        walls = GameObject.FindGameObjectsWithTag("Wall");

        for (int i = 0; i < walls.Length; i++)
        {
            walls[i].GetComponent<MeshRenderer>().material.color = spawnerManager.colors[i];
        }
    }

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                isRotating = false;
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                RotateObjectByAngle(90f, Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                RotateObjectByAngle(-90f, Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.W))
            {
                RotateObjectByAngle(90f, Vector3.forward);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                RotateObjectByAngle(-90f, Vector3.forward);
            }
        }
    }

    void RotateObjectByAngle(float angle, Vector3 axis)
    {
        targetRotation = Quaternion.AngleAxis(angle, axis) * transform.rotation;
        isRotating = true;
    }
}
