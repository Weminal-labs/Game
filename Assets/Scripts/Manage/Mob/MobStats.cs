using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

[System.Serializable]
public class MobStats
{
    private string id_mob { get; set; }
    private int mob_type { get; set; }
    private int health { get; set; }
    private int maxHealth { get; set; }
    private int damage { get; set; }
    private int speed { get; set; }
    private int level { get; set; }
    private int exp { get; set; }
    private int maxExp { get; set; }
    private float[] position { get; set; }
    private string name { get; set; }
    private string history { get; set; }
    private bool inBuilding { get; set; }
    public MobStats() { }
    public MobStats(int mob_type, int minHealth, int maxHealth, int minDamage, int maxDamage, int minSpeed, int maxSpeed, string name, string history)
    {
        this.mob_type = mob_type;
        this.id_mob = generateID();
        this.maxHealth = Random.Range(minHealth, maxHealth);
        this.health = this.maxHealth;
        this.damage = Random.Range(minDamage, maxDamage);
        this.speed = Random.Range(minSpeed, maxSpeed);
        this.level = 1;
        this.exp = 0;
        this.maxExp = 5;
        this.name = name;
        this.history = history;
        this.inBuilding = false;
    }
    public MobStats(string id, int mob_type, int maxHealth, int Damage, int Speed, string name, string history)
    {
        this.id_mob = id;
        this.mob_type = mob_type;
        this.maxHealth = maxHealth;
        this.health = this.maxHealth;
        this.damage = Damage;
        this.speed = Speed;
        this.level = 1;
        this.exp = 0;
        this.maxExp = 5;
        this.name = name;
        this.history = history;
        this.inBuilding = false;
    }
    public MobStats(MobStats mob, Vector3 position)
    {
        this.mob_type = mob.mob_type;
        this.id_mob = mob.id_mob;
        this.health = mob.health;
        this.maxHealth = mob.maxHealth;
        this.damage = mob.damage;
        this.speed = mob.speed;
        this.level = mob.level;
        this.exp = mob.exp;
        this.maxExp = mob.maxExp;
        this.name = mob.name;
        this.history = mob.history;
        this.inBuilding = false;
        this.position = new float[3];
        this.position[0] = position.x;
        this.position[1] = position.y;
        this.position[2] = position.z;
    }
    public int getMobType()
    {
        return this.mob_type;
    }
    public string getId()
    {
        return id_mob;
    }
    public void setHealth(int health)
    {
        this.health += health;
        if(this.health < 0)
        {
            this.health = 0;
        }
    }
    private void setHealthLvUp()
    {
        if(this.mob_type == 0)
        {
            this.maxHealth += Random.Range(10, 20);
        }
        if (this.mob_type == 1)
        {
            this.maxHealth += Random.Range(5, 10);
        }
        if (this.mob_type == 2)
        {
            this.maxHealth += Random.Range(3, 6);
        }
        this.health = this.maxHealth;
    }
    public int getHealth()
    {
        return health;
    }
    public int getMaxHealth()
    {
        return maxHealth;
    }
    private void setDamageLvUp()
    {
        if (this.mob_type == 0)
        {
            this.damage += Random.Range(5, 10);
        }
        if (this.mob_type == 1)
        {
            this.damage += Random.Range(7, 14);
        }
        if (this.mob_type == 2)
        {
            this.damage += Random.Range(3, 6);
        }  
    }
    public int getDamage()
    {
        return damage;
    }
    public int getSpeed()
    {
        return speed;
    }
    public int getLevel()
    {
        return level;
    }
    public void setExp(int exp)
    {
        if (this.exp + exp >= this.maxExp)
        {
            this.exp = this.exp + exp - this.maxExp;
            this.maxExp = level * 5 + this.maxExp;
            level += 1;
            setDamageLvUp();
            setHealthLvUp();
        }
        else
        {
            this.exp += exp;
        }
    }
    public int getExp()
    {
        return exp;
    }
    public int getMaxExp()
    {
        return maxExp;
    }
    public string getName()
    {
        return name;
    }
    public string getHistory()
    {
        return history;
    }
    public void setPos(Vector3 pos)
    {
        this.position[0] = pos.x;
        this.position[1] = pos.y;
        this.position[2] = pos.z;
    }
    public float[] getPos()
    {
        return this.position;
    }

    private string generateID()
    {
        return new string(System.Guid.NewGuid().ToString());
    }

    public void setInBuilding(bool inbuilding)
    {
        this.inBuilding = inbuilding;
    }
    public bool isInBuilding()
    {
        return this.inBuilding;
    }
    public void setNewID(string id)
    {
        this.id_mob = id;
    }
}
