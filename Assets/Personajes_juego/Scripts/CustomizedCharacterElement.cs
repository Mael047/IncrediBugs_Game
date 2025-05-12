using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CustomizedCharacterElement : MonoBehaviour
{
    [field: SerializeField]
    public CustomizationType Type { get; private set; }

    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        var customization = CustomizableCharacter.CachedData.FirstOrDefault(d => d.Type == Type);
        if (customization == null) return;

        _spriteRenderer.color = customization.Color;
        _spriteRenderer.sprite = customization.Sprite.Sprite;
        transform.localPosition = customization.Sprite.PositionModifier;
    }
}
