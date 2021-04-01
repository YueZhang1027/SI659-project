using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

namespace oculus
{
    public class SetFloor : MonoBehaviour
    {
        static List<XRInputSubsystem> k_CachedSubsystems = new List<XRInputSubsystem>();
        XRInputSubsystem m_InputSubsystem;

        private void Start()
        {
            SetTrackingOriginMode();
        }

        public void SetTrackingOriginMode()
        {
            if (m_InputSubsystem == null)
            {
                SubsystemManager.GetInstances(k_CachedSubsystems);
                if (k_CachedSubsystems.Count != 0)
                    m_InputSubsystem = k_CachedSubsystems[0];
            }

            Debug.Log($"Tracking Origin Mode is [{m_InputSubsystem.GetTrackingOriginMode()}]");
            if (m_InputSubsystem.TrySetTrackingOriginMode(TrackingOriginModeFlags.Floor))
                Debug.Log($"Successfully set tracking origin mode to [{m_InputSubsystem.GetTrackingOriginMode()}]");
            else
                Debug.Log("Failed to set tracking origin mode");
        }
    }
}
