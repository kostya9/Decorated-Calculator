# Decorated-Calculator

To build the calculator with operations `+`, `-`, `*`, `/`:
```
var calculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .Build();
```

Example operation:
```
var result = calculator.Perform("+", 3) // 3
                .Perform("*", 3) // 9
                .Perform("+", 1) // 10
                .Perform("/", 5) // 2
                .Perform("-", 1) // 1
                .Result;
```

Build the calculator with an extra operation:
```
var calculator = new CalculatorBuilder()
                .AddDefaultOperations()
                .AddOperation("^", (prev, arg) => Math.Pow(prev, arg))
                .Build();
```
