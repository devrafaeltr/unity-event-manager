using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube_Example : MonoBehaviour
{
    Material myMaterial;

    private void Awake()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnEnable()
    {
        Manager_Events.AddListener(Manager_Events.onCubeSpawn, OnCubeSpawn);
    }

    private void OnCubeSpawn(IGameEvent gameEvent)
    {
        Debug.Log($"Changing color on {name}");
        myMaterial.color = new Color(
        Random.Range(0f, 1f),
        Random.Range(0f, 1f),
        Random.Range(0f, 1f)
        );
    }

    private void OnDisable()
    {
        Manager_Events.RemoveListener(Manager_Events.onCubeSpawn, OnCubeSpawn);
    }
}