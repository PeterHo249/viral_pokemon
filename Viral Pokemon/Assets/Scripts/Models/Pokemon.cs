using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pokemon
{
    public int id;
    public string pokemonName;
    public int maxHp;
    public int currentHp;
    public int attack;
    public int defense;
    public int speed;
    public List<int> type;
    public List<PokemonSkill> skills;
    public int level;
    public int exp;

    public Pokemon(int id, string name, int hp, int attack, int defense, int speed, int level)
    {
        this.id = id;
        this.pokemonName = name;
        this.maxHp = hp;
        this.currentHp = this.maxHp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.level = level;
        this.skills = new List<PokemonSkill>();
        this.type = new List<int>();
    }
}
