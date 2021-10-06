using System;
using UnityEngine;

namespace Neckkeys.Utilities.Sprites
{
    [Serializable]
    public class SpriteAnimation
    {
        int frame = 0;
        [Range(1f, 100f)]
        [SerializeField] float framesPerSecond = 20f;
        [SerializeField] Sprite[] sprites = new Sprite[0];
        float Period => 1f / framesPerSecond;
        float timer = 0f;

        SpriteRenderer spriteRenderer = null;

        public void SetSpriteRenderer(SpriteRenderer spriteRenderer)
        {
            this.spriteRenderer = spriteRenderer;
        }

        public void Reset()
        {
            timer = 0;
            frame = 0;

            if(sprites.Length > 0)
                spriteRenderer.sprite = sprites[frame];
        }

        public void Update()
        {
            if (sprites.Length == 0)
                return;

            if (TimerTick())
                spriteRenderer.sprite = sprites[IncrementFrame()];
        }

        int IncrementFrame()
        {
            if (sprites.Length == 0)
                return frame;

            frame++;
            frame = frame % sprites.Length;
            return frame;
        }

        bool TimerTick()
        {
            timer += Time.deltaTime;
            if (timer >= Period)
            {
                timer = 0f;
                return true;
            }
            return false;
        }
    }
}