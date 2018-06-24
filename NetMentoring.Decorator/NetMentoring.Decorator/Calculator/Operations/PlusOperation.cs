namespace NetMentoring.Decorator.Calculator.Operations
{
    internal class PlusOperation : OperationBase
    {
        public PlusOperation(IOperation operation, double argument) : base(operation, argument)
        {
        }

        public override double Perform(double argument)
        {
            return PerformPrevious() + argument;
        }
    }
}
