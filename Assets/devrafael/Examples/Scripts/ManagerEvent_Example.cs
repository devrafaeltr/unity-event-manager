using UnityEngine;

public class ManagerEvent_Example : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            Manager_Events.Publish(Manager_Events.onWPress, new WPressEvent());
        }
    }
}