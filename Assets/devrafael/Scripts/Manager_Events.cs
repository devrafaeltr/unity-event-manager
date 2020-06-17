using System.Collections.Generic;
using System;

public class Manager_Events
{
    #region Listerners 
    //public static string templateEventName = "TemplateEventName"
    public static string onWPress = "OnWPress";
    public static string onCubeSpawn = "OnCubeSpawn";
    #endregion

    private static Dictionary<string, List<Action<IGameEvent>>> _eventDictionary = new Dictionary<string, List<Action<IGameEvent>>>();

    public static void AddListener(string eventName, Action<IGameEvent> callbackToAdd)
    {
        if (!_eventDictionary.TryGetValue(eventName, out List<Action<IGameEvent>> callbackList))
        {
            callbackList = new List<Action<IGameEvent>>();
            _eventDictionary.Add(eventName, callbackList);
        }

        callbackList.Add(callbackToAdd);
    }

    public static void RemoveListener(string eventName, Action<IGameEvent> callbackToRemove)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<IGameEvent>> callbackList))
        {
            callbackList?.Remove(callbackToRemove);
        }
    }

    public static void Publish(string eventName, IGameEvent eventInfos)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<IGameEvent>> callbackList))
        {
            Action<IGameEvent>[] callbackListAux = callbackList.ToArray();
            
            foreach (var callback in callbackListAux)
            {
                callback?.Invoke(eventInfos);
            }
        }
    }
}
