// PlayerManager.cs — добавить вызов анимации при подборе монеты
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coins = 0;
    public GameManagerTwo gameManager;

    private AnimationController animationController; // добавить

    void Start()
    {
        animationController = GetComponent<AnimationController>(); // добавить
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            animationController?.PlayPickUp(); // добавить
            Destroy(other.gameObject);
        }

        // остальное без изменений...
        if (other.CompareTag("Enemy"))
        {
            gameManager.Defeat();
            Debug.Log("Player died 💀");
            Destroy(gameObject);
        }

        if (other.CompareTag("Spaceship") && coins == 8)
        {
            Debug.Log("Level completed! 🎉");
            gameManager.Victory();
        }

        if (coins == 8)
        {
            gameManager.showBackText();
        }
    }
}