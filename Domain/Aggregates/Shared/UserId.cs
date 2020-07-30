﻿using Domain.Infrastructure;
using System;

namespace Domain.Aggregates.Shared
{
    public class UserId : Value<UserId>
    {
        public Guid Value { get; private set; }

        public UserId(Guid value)
        {
            if (value == default)
                throw new ArgumentNullException(nameof(value), "User id cannot be empty");

            Value = value;
        }

        public static implicit operator Guid(UserId self) => self.Value;
    }
}
