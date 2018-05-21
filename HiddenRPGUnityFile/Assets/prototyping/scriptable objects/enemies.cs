using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "enemy", menuName = "bbeg", order = 1)]
public class enemies : ScriptableObject
{
    public string Name;
    public int hp;
    public int expgiven;
    public Sprite sprite;
}
