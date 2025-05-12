using UnityEngine;
using System.Collections;

public class Rin_Change : MonoBehaviour
{
    // Reference to the SpriteRenderer component
    private SpriteRenderer spriteRenderer;

    // Reference to the new sprite you want to set
    public Sprite jumpSprite;

    public Sprite kickSprite;
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    private Sprite originalSprite;
    private Animator animator;
    private Vector2 y;


    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer attached to the current GameObject
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
        animator = GetComponent<Animator>();
        y =  transform.position;
         
    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(up) || Input.GetKeyDown(left)){
            // Check if a SpriteRenderer is attached
            if (spriteRenderer != null && jumpSprite != null)
            {
                Vector3 newPosition = transform.position;
                // Change the sprite to the new one
                animator.enabled = false;
                spriteRenderer.sprite = jumpSprite;
                newPosition.y += 4.25f;
                transform.position = newPosition;
                StartCoroutine(returnToNormal());
            }
            else
            {
                Debug.LogWarning("SpriteRenderer or newSprite is not set properly.");
            }
        }
        if(Input.GetKeyDown(down) || Input.GetKeyDown(right)){
            // Check if a SpriteRenderer is attached
            if (spriteRenderer != null && kickSprite != null)
            {
                // Change the sprite to the new one
                animator.enabled = false;
                spriteRenderer.sprite = kickSprite;
                StartCoroutine(returnToNormal());
            }
            else
            {
                Debug.LogWarning("SpriteRenderer or newSprite is not set properly.");
            }
        }
    }

    public IEnumerator returnToNormal(){

        yield return new WaitForSeconds(0.1f);
        spriteRenderer.sprite = originalSprite;
        transform.position = y;
        animator.enabled = true;
    }
}

