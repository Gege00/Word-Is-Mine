using UnityEngine;
using System.Collections;


public enum DifficultyLevel {
    Easy,Medium,Hard
}

public class Player {

    private string _name;
    private DifficultyLevel _difficultyLevel;
    private int  _healthPoint;
    private long _score;




    public Player(string name, DifficultyLevel diffLvl, int healthPoint) {
        _name = name;
        _difficultyLevel= diffLvl;
        _healthPoint = healthPoint;

    }


    public void IncreaseScore(int amount=1) {
        _score +=amount;
    }

    public void DecreaseScore(int amount=1) {
        _score -= amount;
    }

    public void DecreaseHealth(int amount=1) {
        _healthPoint -= amount;
    }
}
