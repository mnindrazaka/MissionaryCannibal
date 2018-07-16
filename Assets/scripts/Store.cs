using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Store : MonoBehaviour
{
  public Timer timer;
  public HighScore highscore;

  void Start()
  {
    Load();
  }

  public void Save()
  {
    string destination = Application.persistentDataPath + "/save.dat";
    FileStream file;

    if (File.Exists(destination))
      file = File.OpenWrite(destination);
    else
      file = File.Create(destination);

    TimeSpan highScoreTimeSpan = highscore.highScore;
    TimeSpan currentTimeSpan = timer.stopwatch.Elapsed;

    GameData gameData = new GameData();
    gameData.highScore = highScoreTimeSpan;

    if (TimeSpan.Compare(highScoreTimeSpan, currentTimeSpan) == 1)
    {
      gameData.highScore = currentTimeSpan;
    }

    BinaryFormatter bf = new BinaryFormatter();
    bf.Serialize(file, gameData);
    file.Close();
  }

  public void Load()
  {
    string destination = Application.persistentDataPath + "/save.dat";
    FileStream file;

    if (File.Exists(destination))
      file = File.OpenRead(destination);
    else
    {
      Debug.LogError("File not found");
      return;
    }

    BinaryFormatter bf = new BinaryFormatter();
    GameData gameData = (GameData)bf.Deserialize(file);
    highscore.highScore = gameData.highScore;

    Debug.Log(new DateTime(gameData.highScore.Ticks).ToString("mm:ss"));

    file.Close();
  }
}