using System;
using System.Collections.Generic;

namespace NetMentoring.Decorator.Calculator
{
    public class Calculator : OperationSequence
    {
        public Calculator(IDictionary<string, Func<IOperation, double, IOperation>> operations) : base(operations, new ConstantOperation(), 0)
        {

        }
    }
}
