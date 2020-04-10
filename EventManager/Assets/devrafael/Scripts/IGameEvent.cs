public interface IGameEvent { }

#region Examples
public class WPressEvent : IGameEvent
{

}

public class CubeSpawnEvent : IGameEvent
{
    public float spawnTime = 0;
    public UnityEngine.Vector3 spawnPos = UnityEngine.Vector3.zero;

    public CubeSpawnEvent(float time, UnityEngine.Vector3 pos)
    {
        spawnTime = time;
        spawnPos = pos;
    }
}
#endregion Examples
