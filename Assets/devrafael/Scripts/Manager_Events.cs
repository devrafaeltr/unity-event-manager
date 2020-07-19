using System.Collections.Generic;
using System;

#if UNITY_EDITOR
using UnityEngine;
#endif

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
            #if UNITY_EDITOR
            Debug.LogWarning($"There is no event called: {eventName}. Creating a new one.");   
            #endif
        }
        #if UNITY_EDITOR
        else
        {    
            Debug.Log($"Event: {eventName}. Adding {callbackToAdd.Method} from {callbackToAdd.Target}.");             
        }
        #endif

        callbackList.Add(callbackToAdd);
    }

    public static void RemoveListener(string eventName, Action<IGameEvent> callbackToRemove)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<IGameEvent>> callbackList))
        {
            callbackList?.Remove(callbackToRemove);

            #if UNITY_EDITOR
            Debug.Log($"Event: {eventName}. Removing {callbackToRemove.Method} from {callbackToRemove.Target}.");
            #endif
        }
        #if UNITY_EDITOR
        else
        {
            Debug.LogWarning($"There is no event called: {eventName}.");                    
        }
        #endif
    }


    public static void Publish(string eventName, IGameEvent eventInfos)
    {
        if (_eventDictionary.TryGetValue(eventName, out List<Action<IGameEvent>> callbackList))
        {
            Action<IGameEvent>[] callbackListAux = callbackList.ToArray();

            foreach (var callback in callbackListAux)
            {
                callback?.Invoke(eventInfos);
                if (callback != null)
                {
#if UNITY_EDITOR
                    Debug.Log($"Event: {eventName}. Calling {callback.Method} from {callback.Target}.");
#endif
                }
#if UNITY_EDITOR
                else
                {
                    Debug.LogWarning($"Event: {eventName}. Some callback is null.");                    
                }
#endif
            }
        }
    }
}
