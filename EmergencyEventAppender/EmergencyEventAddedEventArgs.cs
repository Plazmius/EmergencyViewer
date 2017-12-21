using System;
using EmergencyViewer.Data.Entities;

namespace EmergencyEventAppender
{
    public class EmergencyEventAddedEventArgs : EventArgs
    {
        public EmergencyEventAddedEventArgs(EmergencyEvent emergencyEvent)
        {
            EmergencyEvent = emergencyEvent;
        }

        public EmergencyEvent EmergencyEvent { get; }
    }
}