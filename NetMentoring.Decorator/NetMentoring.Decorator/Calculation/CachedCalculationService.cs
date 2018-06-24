using System.Collections.Generic;

namespace NetMentoring.Decorator.Calculation
{
    public class CachedCalculationService : ICalculationService
    {
        private readonly IDictionary<(decimal, decimal), decimal> _cache;
        private readonly ICalculationService _service;

        public CachedCalculationService(ICalculationService service)
        {
            _cache = new Dictionary<(decimal, decimal), decimal>();
            _service = service;
        }

        public decimal Calculate(decimal firstParameter, decimal secondParameter)
        {
            if (_cache.TryGetValue((firstParameter, secondParameter), out var result))
                return result;

            result = _service.Calculate(firstParameter, secondParameter);
            _cache[(firstParameter, secondParameter)] = result;
            return result;
        }
    }
}
