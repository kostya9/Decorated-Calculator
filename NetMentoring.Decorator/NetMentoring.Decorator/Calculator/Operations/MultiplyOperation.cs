namespace NetMentoring.Decorator.Calculator.Operations
{
    internal class MultiplyOperation : OperationBase
    {
        public MultiplyOperation(IOperation operation, double argument) : base(operation, argument)
        {
        }

        public override double Perform(double argument)
        {
            return PerformPrevious() * argument;
        }
    }
}
