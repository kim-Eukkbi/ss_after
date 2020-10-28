using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchParticle : MonoBehaviour
{
    [SerializeField]
    private Color[] colors = null;
    [SerializeField]
    private float moveSpeed = 0.5f;
    [SerializeField]
    private float sizeSpeed = 0.5f;
    [SerializeField]
    private float colorSpeed = 0.5f;
    [SerializeField]
    private float nimSize = 0.1f;
    [SerializeField]
    private float maxSize = 0.3f;

    private float size = 0;
    private Vector2 direction = Vector2.zero;
    private SpriteRenderer touchSprite;
    private void OnEnable()
    {
        touchSprite = GetComponent<SpriteRenderer>();
        direction = new Vector2(Random.Range(-3, 3), Random.Range(-3, 3));
        size = Random.Range(nimSize, maxSize);
        transform.localScale = new Vector2(size, size);
        touchSprite.color = colors[Random.Range(0, colors.Length)];
    }
    private void Update()
    {
        transform.Translate(direction * moveSpeed);
        transform.localScale = Vector2.Lerp(transform.localScale, Vector2.zero, Time.deltaTime * sizeSpeed);

        Color color = touchSprite.color;
        color.a = Mathf.Lerp(touchSprite.color.a , 0 , Time.deltaTime * colorSpeed);
        touchSprite.color = color;

        if(touchSprite.color.a <= 0.1f)
        {
            PoolManager.instance.InsertQueue(gameObject, PoolManager.PoolType.PARTICLE);
        }
    }
}
