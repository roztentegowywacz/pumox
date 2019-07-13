using System;

namespace Pumox.Core.Types.Exceptions
{
    public class NotFoundException : Exception
    {
        public ulong EntityId { get; }
        public override string Message { get; }

        public NotFoundException(Type entityType, ulong entityId)
        {
            EntityId = entityId;
            Message = $"Entity {entityType.GetType()} with an Id: '{entityId}' "
                + "was not found.";
        }
    }
}