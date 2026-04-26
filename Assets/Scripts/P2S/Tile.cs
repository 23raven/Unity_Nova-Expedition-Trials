using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Tile : MonoBehaviour, IPointerClickHandler
{
    public int id;
    public Image image;

    public Color defaultColor = Color.white;
    public Color activeColor = Color.green;
    public Color clickColor = Color.cyan;

    private MiniGameTwo game;

    public void Init(MiniGameTwo gameManager)
    {
        game = gameManager;
        SetDefault();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        StartCoroutine(ClickFeedback());
        game.OnTileClicked(id);
    }

    public void Highlight()
    {
        image.color = activeColor;
    }

    public void SetDefault()
    {
        image.color = defaultColor;
    }

    IEnumerator ClickFeedback()
    {
        image.color = clickColor;
        yield return new WaitForSeconds(0.2f);
        image.color = defaultColor;
    }
}