using System.Collections;


public class KillEnemySignal
{
    public Enemy Enemy { get; }

    public KillEnemySignal(Enemy enemy)
    {
        Enemy      = enemy;
    }
}
