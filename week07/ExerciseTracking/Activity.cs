using System;

abstract class Activity
{
    private DateTime _date;
    private int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    public abstract double GetDistance(); // in kilometers
    public abstract double GetSpeed();    // in km/h
    public abstract double GetPace();     // in min/km

    public virtual string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min): " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}