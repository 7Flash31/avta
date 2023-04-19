using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRoom : MonoBehaviour
{
    public Transform canvasPanel;

    public static CanvasRoom ins;
    private void Awake()
    {
        ins ??= this;
    }
}
