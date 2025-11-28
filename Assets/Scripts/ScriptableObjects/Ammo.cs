using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ammo", menuName = "Scriptable Object/Ammo")]
public class Ammo : ScriptableObject
{
    public int id;
    public Sprite sprite;
    public string type;
    // public float speed;
    public float lifespan;
    public int damage;
}
