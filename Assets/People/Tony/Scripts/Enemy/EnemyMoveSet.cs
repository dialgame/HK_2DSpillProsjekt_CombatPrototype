public class EnemyMoveSet
{
    // Overworld moveset fields
    public string overworldName;
    public float overworldSpeed;

    // Combat moveset fields
    public string combatName;
    public int combatDamage;
    public float combatCooldown;

    public EnemyMoveSet(string overworldName, float overworldSpeed, string combatName, int combatDamage, float combatCooldown)
    {
        this.overworldName = overworldName;
        this.overworldSpeed = overworldSpeed;
        this.combatName = combatName;
        this.combatDamage = combatDamage;
        this.combatCooldown = combatCooldown;
    }

    // Overworld moveset function
    public void UseOverworldMove()
    {
        // Code to execute overworld move
    }

    // Combat moveset function
    public void UseCombatMove()
    {
        // Code to execute combat move
    }
}
