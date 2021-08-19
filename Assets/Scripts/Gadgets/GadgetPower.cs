using Ship;
using UnityEngine;

namespace Gadgets
{
    public class GadgetPower : Gadget
    {
        protected override void ModifyShip(Collider2D shipColl)
        {
            ShipShot shipS = shipColl.GetComponent<ShipShot>();
            shipS.TemporaryIncreaseShotRate(5f);
        }
    }
}