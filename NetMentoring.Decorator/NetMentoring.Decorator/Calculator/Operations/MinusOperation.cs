namespace NetMentoring.Decorator.Calculator.Operations
{
    internal class MinusOperation : OperationBase
    {
        public MinusOperation(IOperation operation, double argument) : base(operation, argument)
        {
        }

        public override double Perform(double argument)
        {
            return PerformPrevious() - argument;
        }
    }
}
