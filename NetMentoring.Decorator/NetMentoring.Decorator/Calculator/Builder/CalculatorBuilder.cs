using NetMentoring.Decorator.Calculator.Operations;
using System;
using System.Collections.Generic;

namespace NetMentoring.Decorator.Calculator.Builder
{
    public class CalculatorBuilder
    {
        private readonly Dictionary<string, Func<IOperation, double, IOperation>> _operationFactories;

        public CalculatorBuilder()
        {
            _operationFactories = new Dictionary<string, Func<IOperation, double, IOperation>>();
        }

        public CalculatorBuilder AddDefaultOperations()
        {
            return AddOperation("+", (o, a) => new PlusOperation(o, a))
                .AddOperation("-", (o, a) => new MinusOperation(o, a))
                .AddOperation("/", (o, a) => new DivideOperation(o, a))
                .AddOperation("*", (o, a) => new MultiplyOperation(o, a));
        }

        public CalculatorBuilder AddOperation(string key, Func<IOperation, double, IOperation> operationFactory)
        {
            _operationFactories[key] = operationFactory;
            return this;
        }

        public CalculatorBuilder AddOperation(string key, Func<double, double, double> operation)
        {
            _operationFactories[key] = (o, a) => new LambdaOperation(o, a, operation);
            return this;
        }

        public Calculator Build()
        {
            return new Calculator(_operationFactories);
        }
    }
}
