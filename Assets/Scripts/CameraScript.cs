using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private Transform playerBody;
    private float speedRotate = CanvasPlayer.SensitivityValue;
    private float xRot;

    public static CameraScript ins;
    private void Awake()
    {
        ins ??= this;
    }

    private void LateUpdate()
    {
        if(PauseGame.IsPause)
        {
            return;
        }

        Vector2 mou = new Vector2(Input.GetAxisRaw("Mouse X") * speedRotate, Input.GetAxisRaw("Mouse Y") * speedRotate);

        if(CanvasPlayer.ins.EscapeOpened)
        {
            speedRotate = 0;
        }

        if(CanvasPlayer.ins.EscapeOpened == false)
        {
            speedRotate = CanvasPlayer.SensitivityValue;
        }

        xRot -= mou.y;
        xRot = Mathf.Clamp(xRot, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerBody.Rotate(Vector3.up * mou.x);
    }
}
