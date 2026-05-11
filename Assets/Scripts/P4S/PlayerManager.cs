using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int coins = 0;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            coins++;
            Destroy(other.gameObject); // удаляем монетку
        }

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Player died 💀");
            Destroy(gameObject); // удаляем игрока
        }

        if (other.CompareTag("Spaceship") && coins == 9)
        {
            Debug.Log("Level completed! 🎉");
            // Здесь можно добавить код для перехода на следующий уровень или отображения экрана победы
        }
    }
}