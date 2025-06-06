using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro.Examples;
using UnityEngine;

public class CustomizableElement : MonoBehaviour
{
    [SerializeField]
    private CustomizationType _type;

    [SerializeField]
    private SpriteRenderer _spriteRenderer;

    // Lista para las opciones del sprite 
    [SerializeField]
    private List<PositionedSprite> _spriteOptions;

    [field: SerializeField]
    public int SpriteIndex { get; private set; }

    // Lista para las opciones de color
    [SerializeField]
    private List<Color> _colorOptions;

    [field: SerializeField]
    public int ColorIndex;

    [SerializeField]
    private List<SpriteRenderer> _copyColorTo;

    public Color CurrentColor => _colorOptions.Count  == 0 ? Color.white : _colorOptions[ColorIndex];

    [ContextMenu("Next Sprite")]
    public PositionedSprite NextSprite()
    {
        SpriteIndex = Mathf.Min(SpriteIndex + 1, _spriteOptions.Count - 1);
        //Actualizar el sprite 
        UpdateSprite();
        return _spriteOptions[SpriteIndex];
    }

    [ContextMenu("Previous Sprite")]
    public PositionedSprite PreviousSprite()
    {
        SpriteIndex = Mathf.Max(SpriteIndex - 1, 0);
        //Actualizar el sprite
        UpdateSprite();
        return _spriteOptions[SpriteIndex];
    }

    [ContextMenu("Next Color")]
    public Color NextColor()
    {
        ColorIndex = Mathf.Min(ColorIndex + 1, _colorOptions.Count - 1);
        //Actualizar el color
        ColorUpdate();
        return _colorOptions[ColorIndex];
    }

    [ContextMenu("Previous Color")]
    public Color PreviusColor()
    {
        ColorIndex = Mathf.Max(ColorIndex - 1, 0);
        //Actualizar el color
        ColorUpdate(); 
        return _colorOptions[ColorIndex];
    }

    [ContextMenu("Update Sprite Position Modifier")]
    public void UpdateSpritePositionModifier()
    {
        _spriteOptions[SpriteIndex].PositionModifier = transform.localPosition;
    }

    public CustomizationData GetCustomizationData()
    {
        return new CustomizationData(_type, _spriteOptions[SpriteIndex], _spriteRenderer.color);
    }


    private void UpdateSprite()
    {
        if (_spriteOptions.Count == 0) return;
        SpriteIndex = Mathf.Clamp(SpriteIndex, 0, _spriteOptions.Count - 1);
        var positionedSprite = _spriteOptions[SpriteIndex];
        _spriteRenderer.sprite = positionedSprite.Sprite;
        transform.localPosition = positionedSprite.PositionModifier;
    }

    private void ColorUpdate()
    {
        if (_colorOptions.Count == 0) return;
        ColorIndex = Mathf.Clamp(ColorIndex, 0, _colorOptions.Count - 1);
        var newColor = _colorOptions[ColorIndex];
        _spriteRenderer.color = newColor;
        _copyColorTo.ForEach(_spriteRenderer => _spriteRenderer.color = newColor);
    }

}
