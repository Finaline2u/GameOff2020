using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInfo
{
    public string itemTag;
    public Vector3 spawnPosition;

    public ItemInfo(string itemTag, Vector3 spawnPosition) {
        this.itemTag = itemTag;
        this.spawnPosition = spawnPosition;
    }
}
