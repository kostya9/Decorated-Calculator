using System;

namespace NetMentoring.Decorator.Calculator.Operations
{
    internal class LambdaOperation : OperationBase
    {
        private readonly Func<double, double, double> _operation;

        public LambdaOperation(IOperation previousOperation, double argument, Func<double, double, double> operation) : base(previousOperation, argument)
        {
            _operation = operation;
        }

        public override double Perform(double argument)
        {
            return _operation(PerformPrevious(), argument);
        }
    }
}
