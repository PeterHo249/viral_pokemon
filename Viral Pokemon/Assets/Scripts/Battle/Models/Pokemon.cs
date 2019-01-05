using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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

    public Pokemon(int id, string name, int hp, int attack, int defense, int speed, int level)
    {
        this.id = id;
        this.pokemonName = name;
        this.maxHp = hp;
        this.attack = attack;
        this.defense = defense;
        this.speed = speed;
        this.level = level;
        this.skills = new List<PokemonSkill>();
        this.type = new List<int>();

        this.maxHp += (this.level - 1) * 30;
        this.attack += (this.level - 1) * 5;
        this.speed += (this.level - 1) * 5;
        this.defense += (this.level - 1) * 5;


        this.currentHp = this.maxHp;
    }

    public void LevelUp(int k)
    {
        this.maxHp -= (this.level - 1) * 30;
        this.attack -= (this.level - 1) * 5;
        this.speed -= (this.level - 1) * 5;
        this.defense -= (this.level - 1) * 5;

        this.level += k;

        this.maxHp += (this.level - 1) * 30;
        this.attack += (this.level - 1) * 5;
        this.speed += (this.level - 1) * 5;
        this.defense += (this.level - 1) * 5;

        this.currentHp = this.maxHp;
    }

    public Pokemon Clone()
    {
        return (Pokemon) this.MemberwiseClone();
    }
}
