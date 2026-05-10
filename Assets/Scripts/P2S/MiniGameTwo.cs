using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameTwo : MonoBehaviour
{
    public List<Tile> tiles;
    public GameManagerOne gameManager;
    private List<int> sequence = new List<int>();
    private int currentIndex = 0;
    private bool isPlayerTurn = false;

    void Start()
    {
        foreach (var tile in tiles)
        {
            tile.Init(this);
        }

        GenerateSequence();
        StartCoroutine(ShowSequence());
    }

    void GenerateSequence()
    {
        sequence.Clear();

        List<int> available = new List<int>();
        for (int i = 0; i < tiles.Count; i++)
            available.Add(i);

        // без повторений
        for (int i = 0; i < tiles.Count; i++)
        {
            int randIndex = Random.Range(0, available.Count);
            sequence.Add(available[randIndex]);
            available.RemoveAt(randIndex);
        }
    }

    IEnumerator ShowSequence()
    {
        isPlayerTurn = false;

        foreach (int id in sequence)
        {
            tiles[id].Highlight();
            yield return new WaitForSeconds(0.5f);

            tiles[id].SetDefault();
            yield return new WaitForSeconds(0.2f);
        }

        isPlayerTurn = true;
        currentIndex = 0;
    }

    public void OnTileClicked(int id)
    {
        if (!isPlayerTurn) return;

        if (sequence[currentIndex] == id)
        {
            currentIndex++;

            if (currentIndex >= sequence.Count)
            {
                Debug.Log("Правильно ✅");
                gameManager.WinMiniGame();
                isPlayerTurn = false;
            }
        }
        else
        {
            Debug.Log("Неправильно ❌");
            isPlayerTurn = false;
        }
    }
}