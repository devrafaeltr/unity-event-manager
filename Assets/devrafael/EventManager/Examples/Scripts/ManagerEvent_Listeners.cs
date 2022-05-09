using UnityEngine;

public class ManagerEvent_Listeners : MonoBehaviour
{
    private void OnEnable()
    {
        Manager_Events.AddListener(Manager_Events.onWPress, OnWPress);
        Manager_Events.AddListener(Manager_Events.onCubeSpawn, OnCubeSpawn);
    }    

    private void OnWPress(IGameEvent exampleEvent)
    {
        Debug.Log("W Pressed");
    }

    private void OnCubeSpawn(IGameEvent gameEvent)
    {
        CubeSpawnEvent cubeSpawnEvent = (CubeSpawnEvent)gameEvent;
        Debug.Log($"New cube spawned at {cubeSpawnEvent.spawnPos}, time spawned: {cubeSpawnEvent.spawnTime}");
    }

    private void OnDisable()
    {
        Manager_Events.RemoveListener(Manager_Events.onWPress, OnWPress);
        Manager_Events.RemoveListener(Manager_Events.onCubeSpawn, OnCubeSpawn);
    }
}