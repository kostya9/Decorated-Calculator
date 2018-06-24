using System;
using System.Collections.Generic;

namespace NetMentoring.Decorator.Calculator
{
    public class OperationSequence
    {
        private readonly IDictionary<string, Func<IOperation, double, IOperation>> _operationFactories;
        private readonly IOperation _previousOperation;
        private readonly double _previousArgument;

        public OperationSequence(IDictionary<string, Func<IOperation, double, IOperation>> operationFactories, IOperation previousOperation, double previousArgument)
        {
            _operationFactories = operationFactories;
            _previousOperation = previousOperation;
            _previousArgument = previousArgument;
        }

        public OperationSequence Perform(string operationKey, double argument)
        {
            if (!_operationFactories.TryGetValue(operationKey, out var operationFactory))
                throw new ArgumentException($"The operation {operationKey} was not defined");

            var operation = operationFactory(_previousOperation, _previousArgument);
            return new OperationSequence(_operationFactories, operation, argument);
        }

        public double Result => _previousOperation.Perform(_previousArgument);
    }
}
