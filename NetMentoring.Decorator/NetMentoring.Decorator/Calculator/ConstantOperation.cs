namespace NetMentoring.Decorator.Calculator
{
    internal class ConstantOperation : IOperation
    {
        public double Perform(double argument)
        {
            return argument;
        }
    }
}
