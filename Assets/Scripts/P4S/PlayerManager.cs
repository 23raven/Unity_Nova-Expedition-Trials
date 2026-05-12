using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coins = 0;
    public GameManagerTwo gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject); // удаляем монетку
        }

        if (other.CompareTag("Enemy"))
        {
            gameManager.Defeat(); // вызываем метод поражения в GameManagerTwo  
            Debug.Log("Player died 💀");
            Destroy(gameObject); // удаляем игрока
        }

        if (other.CompareTag("Spaceship") && coins == 8)
        {
            Debug.Log("Level completed! 🎉");
            // Здесь можно добавить код для перехода на следующий уровень или отображения экрана победы
        }
    }
}