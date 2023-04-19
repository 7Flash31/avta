using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    public static DestroyGameObject ins;
    private void Awake()
    {
        ins ??= this;
    }

    public void DestroyOBJ()
    {
        Destroy(gameObject);
    }
}
