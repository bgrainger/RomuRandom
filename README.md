# RomuRandom

RomuRandom is a .NET implementation of the [Romu](http://romu-random.org/) family of
random number generators.

[![Build Status](https://github.com/bgrainger/RomuRandom/workflows/Tests/badge.svg)](https://github.com/bgrainger/RomuRandom/actions)
[![NuGet](https://img.shields.io/nuget/vpre/RomuRandom)](https://www.nuget.org/packages/RomuRandom)

## Usage

Use `RomuRandom` as a drop-in replacement for [`System.Random`](https://docs.microsoft.com/en-us/dotnet/api/system.random):

```csharp
System.Random random = new RomuRandom(); // seeded with current time
var randomNumber = random.Next();
var dieRoll = random.Next(6); // from 0-5
var randomInRange = random.Next(100, 200); // from 100-199

var bytes = new byte[100];
random.NextBytes(bytes); // fill array with random bytes
```

### Advanced

The `RomuDuo`, `RomuTrio`, and `RomuQuad` classes can be
instantiated directly (for higher performance, or more control
over the seed values).

Note that they only return a random `ulong` value in the range
`[0, UInt64.MaxValue]`. This needs to be converted carefully
if you want to get a random number in a smaller range without bias.

## License

Licensed under the [Apache License, Version 2.0](https://www.apache.org/licenses/LICENSE-2.0).
