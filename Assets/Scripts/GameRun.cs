using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Analytics;

public class GameRun    : ScriptableObject {

    private string  _GRID;
    private uint   _score;
    private int     _currentDiffLevel=1;
    private int     _currentStreak;
    private int     _bestDiffLevel=1;
    private int     _bestStreak;

    
  

    private Dictionary<string, object> eventData= new Dictionary<string, object>();


    public GameRun() {
        GenerateGRID();

    }

    public uint IncreaseScore(int amount) {
        return _score +=(uint)amount;
    }
    
    public int DiffLevel {
        get { return _currentDiffLevel; }
        set {
            _currentDiffLevel = value;
            if (_currentDiffLevel > _bestDiffLevel) {
                _bestDiffLevel = _currentDiffLevel;
            }
        }
    }

    public int Streak {
        get {  return _currentStreak;}
        set {
            _currentStreak = value;
            if (_currentStreak > _bestStreak) {
                _bestStreak = _currentStreak;
            }
        }
    }

    private void GenerateGRID() {
        string key = "GRID:";
        var random = new System.Random();
        DateTime epochStart = new System.DateTime(1970, 1, 1, 8, 0, 0, System.DateTimeKind.Utc);
        double timestamp = (System.DateTime.UtcNow - epochStart).TotalSeconds;

        _GRID =key+ GetHashCode()
                          + "-" + String.Format("{0:X}", Convert.ToInt32(timestamp))
                          + "-" + String.Format("{0:X}", random.Next(1000000000)); 
    }


    public void GameOver() {
        GenerateEventData();
        Analytics.CustomEvent("GameRun", eventData);

    }



    public void GenerateEventData() {
        eventData.Add("GRID",_GRID);
        eventData.Add("Score", _score);
        eventData.Add("CurrentDifficultyLevel", _currentDiffLevel);
        eventData.Add("CurrentStreak", _currentStreak);
        eventData.Add("BestDifficultyLevel",_bestDiffLevel);
        eventData.Add("BestStreak", _bestStreak);


    }

}








