namespace NetMentoring.Decorator.Calculator
{
    public abstract class OperationBase : IOperation
    {
        private readonly IOperation _previousOperation;
        private readonly double _previousArgument;

        public OperationBase(IOperation previousOperation, double previousArgument)
        {
            _previousOperation = previousOperation;
            _previousArgument = previousArgument;
        }

        protected double PerformPrevious()
        {
            return _previousOperation.Perform(_previousArgument);
        }

        public abstract double Perform(double argument);
    }
}
