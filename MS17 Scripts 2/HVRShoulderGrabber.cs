﻿using HurricaneVR.Framework.Core.Grabbers;
using UnityEngine;

namespace HurricaneVR.Framework.Core.Utils
{

    /// <summary>
    /// Specialized shoulder inventory collector that will check the hand's velocity to prevent grabbing when we feel like the player is throwing something
    /// </summary>
    public class HVRShoulderGrabber : HVRSocketContainerGrabber
    {
        public override bool CanHover(HVRGrabbable grabbable)
        {
            if (!base.CanHover(grabbable))
                return false;

            var handGrabber = grabbable.PrimaryGrabber as HVRHandGrabber;
            if (handGrabber == null)
                return false;

            //if a forward throw is happening don't grab it
            var velocity = handGrabber.ComputeThrowVelocity(grabbable, out var dummy);
            velocity.y = transform.position.y;
            if (Vector3.Dot(velocity.normalized, transform.forward) > 0f)
                return false;

            return true;
        }
    }
}
