using System.Collections;
using System.Collections.Generic;
using SoulTraders.Gameplay.Player;
using UnityEngine;

namespace SoulTraders.Gameplay.Interact
{
    public class ChestInteraction : MonoBehaviour, IInteractable
    {

        public Sprite closedSprite;
        public Sprite openSprite;

        private SpriteRenderer spriteRenderer;

        public bool chestOpen;

        // Start is called before the first frame update
        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = closedSprite;
            chestOpen = false;
        }

        // private void OnTriggerEnter2D(Collider2D other)
        // {
        //     if (other.GetComponentInParent<PlayerController>() != null)
        //     {
        //         OnInteract();
        //     }
        // }

        public void OnInteract()
        {
            spriteRenderer.sprite = openSprite;
            chestOpen = true;
        }
    }
}