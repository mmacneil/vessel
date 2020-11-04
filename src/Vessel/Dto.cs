﻿using System;
using System.Collections.Generic;


namespace Vessel
{
    public class Dto<T> : IDto<T>
    {
        public T Payload { get; }
        public Status Status { get; }
        public IEnumerable<string> Errors { get; private set; } = new List<string>();
        public Exception Exception { get; private set; }

        public bool Succeeded => Status == Status.Success;

        public Dto(T payload)
        {
            Payload = payload;
        }

        private Dto(Status status)
        {
            Status = status;
        }

        public static Dto<T> Success(T value)
        {
            return new Dto<T>(value);
        }

        public static Dto<T> Failed(params string[] errorMessages)
        {
            return new Dto<T>(Status.Failed) { Errors = errorMessages };
        }

        public static Dto<T> Failed(Status resultStatus, params string[] errorMessages)
        {
            return new Dto<T>(resultStatus) { Errors = errorMessages };
        }

        public static Dto<T> Failed(Status resultStatus, Exception exception, params string[] errorMessages)
        {
            return new Dto<T>(resultStatus) { Errors = errorMessages, Exception = exception };
        }
    }
}
