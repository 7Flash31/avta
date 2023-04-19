using UnityEngine;
using Mirror;
using TMPro;

public class PlayerMovement : NetworkBehaviour
{
    public CharacterController _characterController;

    [SerializeField] private Transform groundCheck;
    [SerializeField] private TextMeshPro playerNameText;
    [SerializeField] private float walkingSpeed = 7;
    [SerializeField] private float runningSpeed = 15;
    [SerializeField] private float jumpForce = 10;
    private float groundDictsnse = 0.4f;
    private float CurrentSpeed;
    private float gravitry = -19.62f;
    private bool isGrounded;
    private Vector3 velocity;
    public LayerMask groundMask;

    public static PlayerMovement ins;
    private void Awake()
    {
        ins ??= this;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    [SyncVar(hook = nameof(OnNameChanged))]
    public string playerName;
    
    void OnNameChanged(string _Old, string _New)
    {
        playerNameText.text = playerName;
    }

    public override void OnStartLocalPlayer()
    {
        string name = DontDestroyOnLoadSC.Instance.InputPlayerName.text.ToString();
        CmdSetupPlayer(name);
    }

    [Command]
    public void CmdSetupPlayer(string _name)
    {
        playerName = _name;
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.collider.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    private void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDictsnse, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 move = transform.right * h + transform.forward * v;
        _characterController.Move(move * CurrentSpeed * Time.deltaTime);
        velocity.y += gravitry * Time.deltaTime;
        _characterController.Move(velocity * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravitry);
            isGrounded = false;
        }

        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {
            if(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                CurrentSpeed = walkingSpeed;
            }

            else
            {
                CurrentSpeed = runningSpeed;
            }
        }

        else
        {
            CurrentSpeed = walkingSpeed;
        }
    }
}
