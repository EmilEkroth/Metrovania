using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeReference] private HealthHandler healthHandler;
    [SerializeReference] private DeathHandler deathHandler;
    [SerializeReference] private MoveHandler moveHandler;

    public HealthHandler GetHealthHandler() { return healthHandler; }
    public DeathHandler GetDeathHandler() { return deathHandler; }
    public MoveHandler GetMoveHandler() { return moveHandler; }
}
