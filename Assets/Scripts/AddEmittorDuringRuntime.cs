using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddEmittorDuringRuntime : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var b = GetComponent<BulletHell.ProjectileEmitterAdvanced>();
        BulletHell.ProjectileManager.Instance.AddEmitter(b, 99999);
        BulletHell.ProjectileManager.Instance.RegisterEmitter(b);
    }
}
