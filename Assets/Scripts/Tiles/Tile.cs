using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Tile : MonoBehaviour
{

    [SerializeField] protected SpriteRenderer _renderer;
    [SerializeField] private GameObject _hightlight;

    public virtual void Init(int x, int y)
    {

    }

    void OnMouseEnter()
    {
        _hightlight.SetActive(true);
    }

    void OnMouseExit()
    {
        _hightlight.SetActive(false);
    }
}
