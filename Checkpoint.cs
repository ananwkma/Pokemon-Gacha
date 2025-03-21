using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Checkpoint
{
    private int world;
    private int level;
    private List<Character> enemies;
    private bool completed;

    public int World { get; set; }
    public int Level { get; set; }
    public List<Character> Enemies { get; set; }
    public bool Completed { get; set; }

    public Checkpoint() { }
    
    public Checkpoint(int world, int level, List<Character> enemies, bool completed)
    {
        World = world;
        Level = level;
        Enemies = enemies;
        Completed = completed;
    }

    public void completeCheckpoint () {
        this.Completed = true;
    }
}
