using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public enum TurnOrder
    {
        nullTurn = 0,
        PlayerTurn = 1,
        EnemyTurn = 2,
    }
    public P1Script player;
    public EnemyScript enemy;
    public CanvasManager canvasManager;
    public GameObject AttackUI;

    public TurnOrder CurrentTurn;

    public void Start()
    {
        CurrentTurn = TurnOrder.PlayerTurn;
    }
    public void Update()
    {
        switch (CurrentTurn)
        {
            case TurnOrder.nullTurn:
                player.SetState(P1Script.PlayerState.Idle);
                AttackUI.SetActive(false);
                break;
            case TurnOrder.PlayerTurn:
                player.SetState(P1Script.PlayerState.Idle);
                AttackUI.SetActive(true);
                break;
            case TurnOrder.EnemyTurn:
                AttackUI.SetActive(false);
                break;
        }
        
        if (CurrentTurn == TurnOrder.PlayerTurn && player.endTurn)
        {
            player.endTurn = false;
            CurrentTurn = TurnOrder.EnemyTurn;
        }
        if (CurrentTurn == TurnOrder.EnemyTurn && enemy.endTurn)
        {
            enemy.endTurn = false;
            CurrentTurn = TurnOrder.PlayerTurn;
        }

    }
}
