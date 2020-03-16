using UnityEngine;

public class ManagerEvent_Example2 : MonoBehaviour
{
    public GameObject prefabExample = null;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            float x = Random.Range(0, 10);
            float z = Random.Range(0, 10);
            Vector3 pos = new Vector3(x, 0, z);

            Instantiate(prefabExample, pos, Quaternion.identity);            
            Manager_Events.Publish(Manager_Events.onCubeSpawn, new CubeSpawnEvent(Time.realtimeSinceStartup, pos));
        }
    }
}