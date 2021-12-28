﻿namespace OpenSage.Logic.AI.AIStates
{
    internal sealed class ExitContainerState : State
    {
        private uint _containerObjectId;

        internal override void Load(SaveFileReader reader)
        {
            reader.ReadVersion(1);

            reader.ReadObjectID(ref _containerObjectId);
        }
    }
}
