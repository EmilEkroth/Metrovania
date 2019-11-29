using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Character
{
    HealthHandler GetHealthHandler();
    DeathHandler GetDeathHandler();
    MoveHandler GetMoveHandler();
}
