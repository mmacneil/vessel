using System;
using System.Collections.Generic;


namespace Vessel
{
    public class TransferObject<T> : ITransferObject<T>
    {
        public T Payload { get; }
        public Status Status { get; }
        public IEnumerable<string> Errors { get; private set; } = new List<string>();
        public Exception Exception { get; private set; }

        public bool Succeeded => Status == Status.Success;

        public TransferObject(T payload)
        {
            Payload = payload;
        }

        private TransferObject(Status status)
        {
            Status = status;
        }

        public static TransferObject<T> Success(T value)
        {
            return new TransferObject<T>(value);
        }

        public static TransferObject<T> Failed(params string[] errorMessages)
        {
            return new TransferObject<T>(Status.Failed) { Errors = errorMessages };
        }

        public static TransferObject<T> Failed(Status resultStatus, params string[] errorMessages)
        {
            return new TransferObject<T>(resultStatus) { Errors = errorMessages };
        }

        public static TransferObject<T> Failed(Status resultStatus, Exception exception, params string[] errorMessages)
        {
            return new TransferObject<T>(resultStatus) { Errors = errorMessages, Exception = exception };
        }
    }
}
