using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator animator;
    private Transform transform;
    [SerializeField] private int joyId;
    [SerializeField] private float speed;

    [SerializeField] private GameObject punching, kick;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform = GetComponent<Transform>();
        animator = GetComponent<Animator>();

        punching.SetActive(false);
        kick.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Joy" + joyId + "Box"))
        {
            punching.SetActive(true);
            animator.SetBool("Punching", true);
        }
        if (Input.GetButtonDown("Joy" + joyId + "Circle"))
        {
            kick.SetActive(true);
            animator.SetBool("Kick", true);
        }

        // Horizontal movement

        // TODO - Diferenciar joysticks
        float move = Input.GetAxis("Horizontal");

        if (move > 0) {
            animator.SetBool("Forward", true);
            animator.SetBool("Backward", false);
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        } else if (move < 0) {
            animator.SetBool("Backward", true);
            animator.SetBool("Forward", false);
            transform.Translate(Vector3.left * -speed * Time.deltaTime);
        } else {
            animator.SetBool("Forward", false);
            animator.SetBool("Backward", false);
        }
    }

    public void EndFightMovement(string movement)
    {
        animator.SetBool(movement, false);
        switch (movement)
        {
            case "Punching":
                punching.SetActive(false);
                break;
            case "Kick":
                kick.SetActive(false);
                break;
            default:
                break;
        }
    }
}
