namespace NetMentoring.Decorator.Calculator.Operations
{
    internal class DivideOperation : OperationBase
    {
        public DivideOperation(IOperation operation, double argument) : base(operation, argument)
        {
        }

        public override double Perform(double argument)
        {
            return PerformPrevious() / argument;
        }
    }
}
