﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SitecoreIoC
{
    [Serializable]
    public class MultipleApplicationFound : Exception
    {
        public MultipleApplicationFound()
        {
        }

        public MultipleApplicationFound(string message)
            : base(message)
        {
        }

        public MultipleApplicationFound(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected MultipleApplicationFound(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context)
        {
        }

        public MultipleApplicationFound(IEnumerable<Type> applications)
            : this(String.Join(", ", applications))
        {
        }
    }
}
