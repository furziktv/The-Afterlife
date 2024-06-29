using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] private int money;
    private bool isActive;
    private Coins player;
    private bool isOppened;
    public Sprite oppenedImage;
    public SpriteRenderer spriteChest;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Coins>() && !isOppened)
        {
            player = other.GetComponent<Coins>();
            isActive = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<Coins>())
            isActive = false;
    }
    private void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.E) && !isOppened)
        {
            player.coins += money;
            spriteChest.sprite = oppenedImage;
            isOppened = true;
            
        }
    }
}
