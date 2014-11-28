ClooN
=====

An easy to use OpenCL noise library based on Cloo.
It's actually a rewrite of Luminoise by YellPika

Compatibility
-------------
Based on .NET 3.5 it's able to beeing used in .NET 3.5+ and Mono (including Unity3D).
There will be also a Unity3D vector compatible version in the future.

Usage / Example
-----

Creating a simple 256x256 fractal:
```cs
Single3[] input = new Single3[noiseSize * noiseSize];
for (int y = 0; y < noiseSize; y++)
{
    for (int x = 0; x < noiseSize; x++)
    {
        input[x + noiseSize * y] = new Single3((float)x/noiseSize*2-1, (float)y/noiseSize*2-1, 0.0f);
    }
}

var module = Noise.FractalBrownianMotion(8, 4f, 2f, 0.5f) * 0.5f +0.5f;
var program = new NoiseProgram(module);
program.Compile();
float[] values = program.GetValues(input, seed);
```

You can get as complex as you want
```cs
var module = 
	Noise.Voronoi(6.2f, NoiseSystem.VoronoiType.Cell) + 
	Noise.Max(Noise.RidgedMultifractal(4, 5, 2.0f, 0.5f, 1.0f), 
						Noise.FractalBrownianMotion(5, 4.5f, 1.9f, 0.5f)) 
						* 0.5f;
```

