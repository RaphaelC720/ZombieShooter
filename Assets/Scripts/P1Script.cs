using System.Collections;
using UnityEngine;

public class P1Script : MonoBehaviour
{
    public enum PlayerState
    {
        Idle = 0,
        Attacking = 1,
        Blocking = 2,
        TakingDmg = 3,
        Dying = 4
    }
    public enum QTEtype
    {
        Arrows = 0,
        Slider = 1,
        ShrinkingCircle = 2
    }
    public enum QTEresult
    {
        Miss = 0,
        Good = 1,
        Perfect = 2
    }

    public GameObject player;
    public SpriteRenderer mySR;
    public int CurrentHealth;
    public float MaxHealth;
    public PlayerState myState;
    public QTEtype myQTEtype;
    public EnemyScript enemy;
    public bool endTurn;

    public void Start()
    {
        mySR = GetComponent<SpriteRenderer>();

        PlayerState s = PlayerState.Idle;

        SetState(s);
    }

    public void Update()
    {

    }
    public void FixedUpdate()
    {
        switch (myState)
        {
            case PlayerState.Idle:
                mySR.color = Color.white;
                break;
            case PlayerState.Attacking:
                mySR.color = Color.white;
                break;
            case PlayerState.Blocking:
                mySR.color = Color.white;
                break;
            case PlayerState.TakingDmg:
                mySR.color = Color.red;
                break;
            case PlayerState.Dying:
                mySR.color = Color.grey;
                break;

        }
        switch (myQTEtype)
        {
            case QTEtype.Arrows:
                break;
            case QTEtype.Slider:
                break;
            case QTEtype.ShrinkingCircle:
                break;
        }

    }
    public void SetState(PlayerState s)
    {
        if (myState == s) { return; }
        myState = s;

        if (myState == PlayerState.Idle)
        {
            //myAnim.Play("Idle");
        }
        else if (myState == PlayerState.Attacking)
        {
            //myAnim.Play("Attacking");
        }
        else if (myState == PlayerState.Blocking)
        {
            //myAnim.Play("Block");
        }
        else if (myState == PlayerState.TakingDmg)
        {
            //myAnim.Play("Hurt");
        }
        else if (myState == PlayerState.Dying)
        {
            //myAnim.Play("Dying");
        }
    }

    IEnumerator DoQTE(QTEtype type, int missDmg, int goodDmg, int perfectDmg)
    {
        QTEresult result = QTEresult.Perfect;

        if (type == QTEtype.Arrows)
        {
            ArrowQTE aQTE = FindAnyObjectByType<ArrowQTE>();
            yield return StartCoroutine(aQTE.StartArrowQTE((r) => result = r));
        }
        if (type == QTEtype.Slider)
        {

        }
        if (type == QTEtype.ShrinkingCircle)
        {

        }

        if (result == QTEresult.Miss)
        {
            enemy.TakeDmg(missDmg);
        }
        else if (result == QTEresult.Good)
        {
            enemy.TakeDmg(goodDmg);
        }
        else if (result == QTEresult.Perfect)
        {
            enemy.TakeDmg(perfectDmg);
        }

        SetState(PlayerState.Idle);
        endTurn = true;
    }

    public void LightAttack()
    {
        SetState(PlayerState.Attacking);
        StartCoroutine(DoQTE(QTEtype.Arrows, 1, 5, 10));
    }
    public void MediumAttack()
    {
        SetState(PlayerState.Attacking);
        StartCoroutine(DoQTE(QTEtype.Slider, 0, 7, 20));
    }
    public void HeavyAttack()
    {
        SetState(PlayerState.Attacking);
        StartCoroutine(DoQTE(QTEtype.Arrows, 0, 15, 34));
    }
    public void TakeDmg(int dmg)
    {
        PlayerState s = PlayerState.TakingDmg;
        CurrentHealth -= dmg;
        SetState(s);
    }
    public void die()
    {
        PlayerState s = PlayerState.Dying;
        Destroy(player);
        SetState(s);
    }
}
