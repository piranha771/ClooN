typedef struct
{
    float x;
    float y;
    float z;
} Single3;

typedef struct
{
	float startX;
    float offsetX;
	int lengthX;
    float startY;
    float offsetY;
	int lengthY;
    float startZ;
    float offsetZ;
	int lengthZ;
} ImplicitCube;

__constant float g[] = {
1,1,0, -1,1,0, 1,-1,0, -1,-1,0,
1,0,1, -1,0,1, 1,0,-1, -1,0,-1,
0,1,1, 0,-1,1, 0,1,-1, 0,-1,-1,
1,1,0, 0,-1,1, -1,1,0, 0,-1,-1,
};


float fade(float t) { return t * t * t * (t * (t * 6 - 15) + 10); }

float lerp(float t, float a, float b) { return a + t * (b - a); }

float grad(int hash, float x, float y, float z) {
    int h = hash & 15;  
    float g1 = g[h * 3];
    float g2 = g[h * 3 + 1];
    float g3 = g[h * 3 + 2];
    return x * g1 + y * g2 + z * g3;
}

float perm(__global int *p, int index)
{
    return p[index & 255];
}

float noise(__global int *p, float x, float y, float z)
{
    int X = (int)floor(x) & 255;
    int Y = (int)floor(y) & 255;
    int Z = (int)floor(z) & 255;

    x -= floor(x);
    y -= floor(y);
    z -= floor(z);

    float u = fade(x);
    float v = fade(y);
    float w = fade(z);

    int A = perm(p, X + 0) + Y, AA = perm(p, A) + Z, AB = perm(p, A+1) + Z,
        B = perm(p, X + 1) + Y, BA = perm(p, B) + Z, BB = perm(p, B+1) + Z;

    return lerp(w, lerp(v,  lerp(u, grad(perm(p, AA  ), x  , y  , z   ),
                                    grad(perm(p, BA  ), x-1, y  , z   )),
                            lerp(u, grad(perm(p, AB  ), x  , y-1, z   ),
                                    grad(perm(p, BB  ), x-1, y-1, z   ))),
                    lerp(v, lerp(u, grad(perm(p, AA+1), x  , y  , z-1 ),
                                    grad(perm(p, BA+1), x-1, y  , z-1 )),
                            lerp(u, grad(perm(p, AB+1), x  , y-1, z-1 ),
                                    grad(perm(p, BB+1), x-1, y-1, z-1 ))));
}

float valueNoise(__global int *p, float x, float y, float z, int seed)
{
	
    int X = (int)floor(x) & 255;
    int Y = (int)floor(y) & 255;
    int Z = (int)floor(z) & 255;

    int hash = perm(p, perm(p, X) + Y) + Z;
    return (int)perm(p, hash + seed) % 256 / 255.0f;
}


float voronoiF1(__global int *p, float4 input)
{
    float4 intCoord = floor(input);
   
    float minDist = 5;

    int i = 0;
    for (int z = (int)intCoord.z - 1; z <= intCoord.z + 1; z++)
    {
        for (int y = (int)intCoord.y - 1; y <= intCoord.y + 1; y++)
        {
            for (int x = (int)intCoord.x - 1; x <= intCoord.x + 1; x++)
            {
                float4 pos = (float4)(
                    x + valueNoise(p, x, y, z, 0),
                    y + valueNoise(p, x, y, z, 1),
                    z + valueNoise(p, x, y, z, 2),
                    0);
                float4 d = pos - input;
                float dist = dot(d, d);

                if (dist < minDist)
                    minDist = dist;
                
                i++;
            }
        }
    }

    return clamp(minDist * 2 - 1, -1.0f, 1.0f);
}

float voronoiF2(__global int *p, float4 input)
{
    float4 intCoord = floor(input);
   
    float minDist1 = 5;
    float minDist2 = 5;

    int i = 0;
    for (int z = (int)intCoord.z - 1; z <= intCoord.z + 1; z++)
    {
        for (int y = (int)intCoord.y - 1; y <= intCoord.y + 1; y++)
        {
            for (int x = (int)intCoord.x - 1; x <= intCoord.x + 1; x++)
            {
                float4 pos = (float4)(
                    x + valueNoise(p, x, y, z, 0),
                    y + valueNoise(p, x, y, z, 1),
                    z + valueNoise(p, x, y, z, 2),
                    0);
                float4 d = pos - input;
                float dist = dot(d, d);

                if (dist < minDist1)
                {
                    float temp = minDist1;
                    minDist1 = dist;
                    dist = temp;
                }

                if (dist < minDist2)
                    minDist2 = dist;
                
                i++;
            }
        }
    }

    return clamp(minDist2 * 2 - 1, -1.0f, 1.0f);
}

float voronoiF2F1(__global int *p, float4 input)
{
    float4 intCoord = floor(input);
   
    float minDist1 = 5;
    float minDist2 = 5;

    int i = 0;
    for (int z = (int)intCoord.z - 1; z <= intCoord.z + 1; z++)
    {
        for (int y = (int)intCoord.y - 1; y <= intCoord.y + 1; y++)
        {
            for (int x = (int)intCoord.x - 1; x <= intCoord.x + 1; x++)
            {
                float4 pos = (float4)(
                    x + valueNoise(p, x, y, z, 0),
                    y + valueNoise(p, x, y, z, 1),
                    z + valueNoise(p, x, y, z, 2),
                    0);
                float4 d = pos - input;
                float dist = dot(d, d);

                if (dist < minDist1)
                {
                    float temp = minDist1;
                    minDist1 = dist;
                    dist = temp;
                }

                if (dist < minDist2)
                    minDist2 = dist;
                
                i++;
            }
        }
    }

    return clamp((minDist2 - minDist1) * 2 - 1, -1.0f, 1.0f);
}

float voronoiF3(__global int *p, float4 input)
{
    float4 intCoord = floor(input);
   
    float minDist1 = 5;
    float minDist2 = 5;
    float minDist3 = 5;

    int i = 0;
    for (int z = (int)intCoord.z - 1; z <= intCoord.z + 1; z++)
    {
        for (int y = (int)intCoord.y - 1; y <= intCoord.y + 1; y++)
        {
            for (int x = (int)intCoord.x - 1; x <= intCoord.x + 1; x++)
            {
                float4 pos = (float4)(
                    x + valueNoise(p, x, y, z, 0),
                    y + valueNoise(p, x, y, z, 1),
                    z + valueNoise(p, x, y, z, 2),
                    0);
                float4 d = pos - input;
                float dist = dot(d, d);

                if (dist < minDist1)
                {
                    float temp = minDist1;
                    minDist1 = dist;
                    dist = temp;
                }

                if (dist < minDist2)
                {
                    float temp = minDist2;
                    minDist2 = dist;
                    dist = temp;
                }

                if (dist < minDist3)
                    minDist3 = dist;
                
                i++;
            }
        }
    }

    return clamp(minDist3 * 2 - 1, -1.0f, 1.0f);
}

float voronoiCell(__global int *p, float4 input)
{
    float4 intCoord = floor(input);
   
    float minDist = 5;
    float4 minPos = input;

    int i = 0;
    for (int z = (int)intCoord.z - 1; z <= intCoord.z + 1; z++)
    {
        for (int y = (int)intCoord.y - 1; y <= intCoord.y + 1; y++)
        {
            for (int x = (int)intCoord.x - 1; x <= intCoord.x + 1; x++)
            {
                float4 pos = (float4)(
                    x + valueNoise(p, x, y, z, 0),
                    y + valueNoise(p, x, y, z, 1),
                    z + valueNoise(p, x, y, z, 2),
                    0);
                float4 d = pos - input;
                float dist = dot(d, d);

                if (dist < minDist)
                {
                    minPos = pos;
                    minDist = dist;
                }
                
                i++;
            }
        }
    }

    return valueNoise(p, minPos.x, minPos.y, minPos.z, 0);
}

float fractalBrownianMotion(Single3 in_pos, int octaves, float frequency, float lacunarity, float persistence, __global int* p) {
    float currentWeight = 1.0f;
    float result = 0.0f;
    for (int i = 0; i < octaves; i++) {
        int px = perm(p, i);
        int py = perm(p, px);
        int pz = perm(p, py);

        in_pos.x += px; in_pos.y += py; in_pos.z += pz;

        result += noise(p, in_pos.x * frequency, in_pos.y * frequency, in_pos.z * frequency) * currentWeight;
        currentWeight *= persistence;
        frequency *= lacunarity;
    }
    return result;
}

float ridgedMultifractal(Single3 in_pos, int octaves, float frequency, float lacunarity, float gain, float offset, __global int* p) {
    float currentWeight = 1.0f;
    float totalWeights = 0.0f;
    float value = 0.0f;
    float prev = 1.0f;

    for (int i = 0; i < octaves; i++) {
        int px = perm(p, i);
        int py = perm(p, px);
        int pz = perm(p, py);

        in_pos.x += px; in_pos.y += py; in_pos.z += pz;

        float signal = noise(p, in_pos.x * frequency, in_pos.y * frequency, in_pos.z * frequency);
        signal = offset - fabs(signal);
        signal *= signal;

        value += signal * currentWeight * prev;
        prev *= signal;

        totalWeights += currentWeight;
        currentWeight *= gain;

        frequency *= lacunarity;
    }
    return value / totalWeights * 2 - 1;
}

float turbulence(Single3 in_pos, int octaves, float frequency, float lacunarity, float gain, __global int* p) {
    float currentWeight = 1.0f;
    float value = 0.0f;
    for (int i = 0; i < octaves; i++) {
        float signal = noise(p, in_pos.x * frequency, in_pos.y * frequency, in_pos.z * frequency);
        signal = fabs(signal);
        signal *= currentWeight;

        value += signal;

        currentWeight *= gain;

        frequency *= lacunarity;
    }

    return value;
}
