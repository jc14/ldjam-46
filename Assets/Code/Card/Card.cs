using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public abstract class Card<T> : MonoBehaviour, IPointerClickHandler where T : CardAsset
{
    public TMP_Text titleText;
    public TMP_Text descriptionText;

    protected T asset;

    protected Board board;

    protected Animator animator;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        switch (eventData.button)
        {
            case PointerEventData.InputButton.Left:
                OnLeftClick();
                break;
            case PointerEventData.InputButton.Right:
                OnRightClick();
                break;
        }
    }

    public void Setup(Board board, T asset)
    {
        this.board = board;
        this.asset = asset;

        Render();
    }

    public void Delete()
    {
        Destroy(gameObject);
    }

    protected void Render()
    {
        titleText.text = asset.Title;
        descriptionText.text = asset.Description;

        OnRender();
    }

    public abstract void Initialize();
    protected abstract void OnLeftClick();
    protected abstract void OnRightClick();
    protected abstract void OnRender();
}
