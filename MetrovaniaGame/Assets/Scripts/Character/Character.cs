using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeReference] private GameManager gameManager;
    [SerializeReference] private HealthHandler healthHandler;
    [SerializeReference] private DeathHandler deathHandler;
    [SerializeReference] private MoveHandler moveHandler;
    [SerializeReference] private AttackHandeler attackHandeler;

    public HealthHandler GetHealthHandler() { return healthHandler; }
    public DeathHandler GetDeathHandler() { return deathHandler; }
    public MoveHandler GetMoveHandler() { return moveHandler; }
    public AttackHandeler GetAttackHandeler() { return attackHandeler; }

    private void OnValidate() 
    {
        #region GameManager
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        if(!gameManager.ObjectExists(GetComponent<Collider2D>()))
            gameManager.AddCharacter(gameObject.GetComponent<Collider2D>(), this);
        #endregion

        //Initzialising components:

        #region MoveHandeler
        if (moveHandler != null)
        {
            moveHandler.SetTransform(transform);
            moveHandler.SetRigidbody(gameObject.GetComponent<Rigidbody2D>());
        }
        #endregion

        #region AttackHandeler
        if (attackHandeler != null)
        {
            attackHandeler.SetCharacter(this);
        }
        #endregion
    }

    private void Start()
    {
        if(moveHandler == null)
        {
            moveHandler = (MoveHandler)ScriptableObject.CreateInstance("StaticMoveHandeler");
        }
    }

    private void FixedUpdate()
    { //Pushing fixed update to components:
        moveHandler.FixedUpdate();
    }
}
