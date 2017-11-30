using System;
using System.Collections.Generic;
using System.Text;

namespace BarbecueManager.Patterns.Application.Messages
{
    public abstract class AbstractQueryPredicate
    {
        public int Offset { get; set; }
        public int Limit { get; set; }
    }
}
