using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSpawnPoint : MonoBehaviour
{
    //attached to SpawnPoint object in every level. Accessed when that level loads, and saves position in PlayerData.
    public Vector2 GetSpawnPoint() 
    {
        return this.transform.position;
    }
}
