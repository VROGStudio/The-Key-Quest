using System;
using System.Collections.Generic;
using UnityEngine;

public static class newEvents
{
    private static List<newEvent> Events = new List<newEvent>();

    public static bool EventExist(string name)
    {
        foreach (var evt in Events)
        {
            if (evt.EventName == name)
                return true;
        }

        return false;
    }

    public static bool Induce(string name)
    {
        foreach (var evt in Events)
        {
            if (evt.EventName == name)
            {
                evt.EventInduce();
                return true;
            }
        }

        Debug.LogWarning("Event: '" + name + "' does not exist!");
        return false;
    }

    public static bool Create(string name)
    {
        foreach (var evt in Events)
        {
            if (evt.EventName == name)
            {
                Debug.LogWarning("Event: '" + name + "' already exists!");
                return false;
            }
        }

        Events.Add(new newEvent(name));
        return true;
    }

    public static bool Sub(string name, Func<bool> subscriber)
    {
        foreach (var evt in Events)
        {
            if (evt.EventName == name)
                return evt.Subscribe(subscriber);
        }

        Debug.LogWarning("Event: '" + name + "' does not exist!");
        return false;
    }

    public static bool UnSub(string name, Func<bool> subscriber)
    {
        foreach (var evt in Events)
        {
            if (evt.EventName == name)
                return evt.UnSubscribe(subscriber);
        }

        Debug.LogWarning("Event: '" + name + "' does not exist!");
        return false;
    }

    private class newEvent
    {
        private List<Func<bool>> subscribers = new List<Func<bool>>();
        public string EventName;

        public newEvent(string name)
        {
            EventName = name;
        }

        public bool Subscribe(Func<bool> sub)
        {
            foreach (var subscriber in subscribers)
            {
                if (subscriber == sub)
                {
                    Debug.LogWarning("Event: '" + EventName + "' is already subscribed!");
                    return false;
                }
            }

            subscribers.Add(sub);
            return true;
        }

        public bool UnSubscribe(Func<bool> sub)
        {
            if (subscribers.Remove(sub))
                return true;

            Debug.LogWarning("'" + sub.ToString() + "' is not a subscriber of event '" + EventName + "'!");
            return false;
        }

        public bool EventInduce()
        {
            for (int i = 0; i < subscribers.Count; i++)
            {

                if (!subscribers[i]())
                {

                    return false;

                }
            }



            return true;
        }
    }
}
