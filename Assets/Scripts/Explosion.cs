using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.explosion);
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
}
