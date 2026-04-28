using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dots : MonoBehaviour, IPointerClickHandler
{
    public int colorId;
    public Image image;

    private MiniGameThree game;
    public bool isUsed = false;

    public void Init(MiniGameThree manager)
    {
        game = manager;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (isUsed) return;

        game.OnDotClicked(this);
    }

    public void SetUsed()
    {
        isUsed = true;
        image.color = image.color * 0.5f; // затемнение
    }
}