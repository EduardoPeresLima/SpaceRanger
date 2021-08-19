using Ship;
using UnityEngine;

namespace Gadgets
{
    public class GadgetHealth : Gadget
    {
        protected override void ModifyShip(Collider2D shipColl)
        {
            ShipHealth shipH = shipColl.GetComponent<ShipHealth>();
            shipH.IncreaseHealth();
        }
    }
}