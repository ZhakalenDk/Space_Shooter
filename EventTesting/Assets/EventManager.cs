using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Events;
using System;

public class EventManager : MonoBehaviour
{
    private static EventManager instance;
    public static EventManager Instance
    {
        get
        {
            if ( instance == null )
            {
                instance = FindObjectOfType<EventManager> ();
                Instance.Initialize ();
                Debug.LogWarning ( instance.name );

                if ( instance == null )
                {
                    Debug.LogError ( "Somehting went wrong. Did you forget to add an Eventmanager to the scene?" );
                }
            }

            return instance;
        }
    }

    private Dictionary<string, Action> EventCollection;

    public void Begin_Listening_To( string _eventName, Action _event )
    {
        EventCollection.Add ( _eventName, _event );
        Debug.Log ( "Now listening to: " + _eventName );
    }

    public void Stop_Listening_To( string _eventName )
    {
        EventCollection.Remove ( _eventName );
        Debug.Log ( "Stopped listening to: " + _eventName );
    }

    public Action Get_Event( string _eventName )
    {
        Action toGet;
        EventCollection.TryGetValue ( _eventName, out toGet );
        Debug.Log ( "Getting: " + _eventName );

        return toGet;
    }

    private void Initialize()
    {
        EventCollection = new Dictionary<string, Action> ();
    }
}
