namespace NetMentoring.Decorator.Calculation
{
    public class CorrectedCalculationService : ICalculationService
    {
        private readonly decimal _correctionValue = 10;
        private readonly ICalculationService _service;

        public CorrectedCalculationService(ICalculationService service)
        {
            _service = service;
        }

        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            return _service.Calculate(firstParameter, secondParameter) + _correctionValue;
        }
    }
}
