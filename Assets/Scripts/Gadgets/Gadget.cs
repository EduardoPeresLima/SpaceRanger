using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gadgets
{
    public abstract class Gadget : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!other.CompareTag("Player")) return;
            ModifyShip(other);
            Destroy(gameObject);
        }

        protected abstract void ModifyShip(Collider2D shipColl);
    }
}