[![GitHub](https://img.shields.io/github/license/devrafael-source/unity-event-manager)](https://github.com/devrafael-source/unity-event-manager/blob/master/LICENSE)
# unity-event-manager
Event Aggregator pattern for Unity.
___
## Getting started
### How to install:
1. Download and import to your project.
2. Done!

### How to use:
1. Go to the Manager_Events under `#region` Listerners.
2. Create a `public static string eventName = "EventName";` 
There is a template. You can use any name.
3. Now, anywhere, you can call ```Manager_AddListener.AddListener(eventName, yourFunction)```, ```Manager_AddListener.RemoveListener(eventName, yourFunction)``` and ```Manager_AddListener.Publish(eventName, IGameEvent)```.

### Notes  
You need to create a class, which can be in the same script, for **EACH** different event call which has different parameters.
```C#
public class SomeAnotherEvent : IGameEvent
{
  public int myInt = ;
}

public class SomeEvent : IGameEvent
{
  public string myString = "";
}
```
then, you can access whichever variable you want:
```C#
public void OnSomeEvent(IGameEvent gameEvent)
{
  SomeEvent someEvent = (SomeEvent)gameEvent;
  
  someEvent.myString = "It works!";
}
```

You need to create a `public static string eventName` in the `Manager_Events` for **EACH** different event. For example, a event for when the player move, other for when kill enemy, and so on. Normally, the number of event names is the same to the number of event classes.
