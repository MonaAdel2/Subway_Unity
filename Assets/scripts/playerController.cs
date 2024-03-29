using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    [SerializeField] uiManager ui;
    private CharacterController controller;
    [SerializeField] int speed = 10;
    [Header("jumping")]
    [SerializeField] float jumpHeight = 4f;
    [Header("jumping")]
    [SerializeField] float gravity = -9.8f;
    [SerializeField] GameObject panel;
    Vector3 velocity;
    public Animator animator;
    float score;
    bool grounded;
    int MAX_SPEED = 20;


    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;

        float x = Input.GetAxis("Horizontal");

        Vector3 direction = new Vector3(x, 0, 1);
        score = ui.GetScore();
        controller.Move(direction * speed * Time.deltaTime);
       
        if (grounded && velocity.y < 0)
        {
            velocity.y = -2;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                jump();
            }
        }
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }

    void jump()
    {
        animator.SetTrigger("jump");
        velocity.y = Mathf.Sqrt(gravity * -2 * jumpHeight);
        FindObjectOfType<SoundEffectsManager>().playJumpSound();
    }

    void gameOver()
    {
        ui.gameOver();
    }

   public int IncreaseSpeed(int amount){
        speed += amount;
        speed = Mathf.Clamp(speed, 0, MAX_SPEED);
        return speed;
   }

   public void ActivatePanel(){
        panel.SetActive(true);
        Invoke("DeActivatePanel", 3);
    }

    public void DeActivatePanel(){
        panel.SetActive(false);
    
    }
}
