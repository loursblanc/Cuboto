using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighScore : IEquatable<HighScore>
{
    public string PlayerName;
    public int Score;

    public override bool Equals(object obj)
    {
        return Equals(obj as HighScore);
    }

    public bool Equals(HighScore other)
    {
        return other != null &&
               PlayerName == other.PlayerName &&
               Score == other.Score;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(PlayerName, Score);
    }
}
