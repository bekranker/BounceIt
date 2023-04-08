using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    public List<IObserver> _observers = new List<IObserver>();

    public void AddObserver(IObserver _observer)
    {
        _observers.Add(_observer);
    }

    public void RemoveObserver(IObserver _observer)
    {
        _observers.Remove(_observer);
    }

    public void NotifyObserver(IObserver _observer)
    {
        _observers.ForEach((_observer) =>
        {
            _observer.OnNotify();
        });
    }


}
