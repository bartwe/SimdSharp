// SimdSharp.Native.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "SimdSharp.Native.h"
#include "malloc.h"
#include <algorithm>


float* SSN_CDECL AllocateFloat(int32_t _count) {
	return (float*)malloc(_count * sizeof(float));
}

void SSN_CDECL ReleaseFloat(float* __restrict buffer) {
	free(buffer);
}

void SSN_CDECL GetRangeFloat(float* __restrict buffer, int32_t offset, float* __restrict values, int32_t valuesOffset, int32_t count) {
	memcpy(&values[valuesOffset], &buffer[offset], count * sizeof(float));
}

void SSN_CDECL SetRangeFloat(float* __restrict buffer, int32_t offset, float* __restrict values, int32_t valuesOffset, int32_t count) {
	memcpy(&buffer[offset], &values[valuesOffset], count * sizeof(float));
}

void SSN_CDECL SetAllFloat(float* __restrict buffer, float value, int32_t count) {
	for (int32_t i = 0; i < count; ++i)
		buffer[i] = value;
}

void SSN_CDECL MinFloat(float* __restrict buffer, float* __restrict min, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto a = buffer[i];
		auto b = min[i];
		if (a > b)
			a = b;
		result[i] = a;
	}
}

void SSN_CDECL MaxFloat(float* __restrict buffer, float* __restrict max, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto a = buffer[i];
		auto b = max[i];
		if (a < b)
			a = b;
		result[i] = a;
	}
}

void SSN_CDECL ClampFloat(float* __restrict buffer, float* __restrict low, float* __restrict high, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto a = buffer[i];
		auto c = high[i];
		if (a > c)
			a = c;
		auto b = low[i];
		if (a < b)
			a = b;
		result[i] = a;
	}
}


float SSN_CDECL SumFloat(float* __restrict buffer, int32_t count) {
	float result = 0.0f;
	for (int32_t i = 0; i < count; ++i) {
		result += buffer[i];
	}
	return result;
}

void SSN_CDECL AddFloat(float* __restrict a, float* __restrict b, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] + b[i];
	}
}

void SSN_CDECL SubtractFloat(float* __restrict a, float* __restrict b, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] - b[i];
	}
}

void SSN_CDECL MultiplyFloat(float* __restrict a, float* __restrict b, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] * b[i];
	}
}

void SSN_CDECL DivideFloat(float* __restrict a, float* __restrict b, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] / b[i];
	}
}

void SSN_CDECL MultiplyAddFloat(float* __restrict a, float* __restrict b, float* __restrict c, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] * b[i] + c[i];
	}
}

void SSN_CDECL FloorFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = std::floor(a[i]);
	}
}

void SSN_CDECL CeilFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = std::ceil(a[i]);
	}
}

void SSN_CDECL SelectFloat(float* __restrict a, float* __restrict b, float* __restrict c, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = a[i] ? b[i] : c[i];
	}
}

void SSN_CDECL NormalizeFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict rx, float* __restrict ry, float* __restrict rz, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto x = ax[i];
		auto y = ay[i];
		auto z = az[i];

		auto length = sqrtf(x * x + y * y + z * z);
		if (length > 0) {
			x /= length;
			y /= length;
			z /= length;
		}
		rx[i] = x;
		ry[i] = x;
		rz[i] = x;
	}
}

void SSN_CDECL LengthFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict r, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto x = ax[i];
		auto y = ay[i];
		auto z = az[i];

		r[i] = sqrtf(x * x + y * y + z * z);
	}
}

void SSN_CDECL LengthSquaredFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict r, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto x = ax[i];
		auto y = ay[i];
		auto z = az[i];

		r[i] = sqrtf(x * x + y * y + z * z);
	}
}

void SSN_CDECL AbsFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = std::abs(a[i]);
	}
}

void SSN_CDECL DotFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int count) {
	for (int32_t i = 0; i < count; ++i) {
		r[i] = ax[i] * bx[i] + ay[i] * by[i] + az[i] * bz[i];
	}
}

void SSN_CDECL LerpFloat(float* __restrict a, float* __restrict b, float* __restrict v, float* __restrict r, int count) {
	for (int32_t i = 0; i < count; ++i) {
		auto av = a[i];
		r[i] = (b[i] - av) * v[i] + av;
	}
}

void SSN_CDECL DistanceFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto x = ax[i] - bx[i];
		auto y = ay[i] - by[i];
		auto z = az[i] - bz[i];

		r[i] = sqrtf(x * x + y * y + z * z);
	}
}

void SSN_CDECL DistanceSquaredFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto x = ax[i] - bx[i];
		auto y = ay[i] - by[i];
		auto z = az[i] - bz[i];

		r[i] = x * x + y * y + z * z;
	}
}

void SSN_CDECL VerletFloat3(
	float* __restrict positionInX, float* __restrict positionInY, float* __restrict positionInZ,
	float* __restrict velocityInX, float* __restrict velocityInY, float* __restrict velocityInZ,
	float* __restrict accelerationInX, float* __restrict accelerationInY, float* __restrict accelerationInZ,
	float* __restrict gravityX, float* __restrict gravityY, float* __restrict gravityZ,
	float* __restrict drag,
	float* __restrict mass,
	float deltaTime,
	float* __restrict positionOutX, float* __restrict positionOutY, float* __restrict positionOutZ,
	float* __restrict velocityOutX, float* __restrict velocityOutY, float* __restrict velocityOutZ,
	float* __restrict accelerationOutX, float* __restrict accelerationOutY, float* __restrict accelerationOutZ,
	int32_t count) {
	auto deltaTimeHalf = deltaTime * 0.5f;
	auto deltaTimeHalfSquared = deltaTime * deltaTimeHalf;
	for (int32_t i = 0; i < count; ++i) {
		positionOutX[i] = positionInX[i] + velocityInX[i] * deltaTime + accelerationInX[i] * deltaTimeHalfSquared;
		auto accelerationX = gravityX[i] - ((0.5f * drag[i] * velocityInX[i] * std::abs(velocityInX[i])) / mass[i]);
		velocityOutX[i] = velocityInX[i] + (accelerationInX[i] + accelerationX) * deltaTimeHalf;
		accelerationOutX[i] = accelerationX;

		positionOutY[i] = positionInY[i] + velocityInY[i] * deltaTime + accelerationInY[i] * deltaTimeHalfSquared;
		auto accelerationY = gravityY[i] - ((0.5f * drag[i] * velocityInY[i] * std::abs(velocityInY[i])) / mass[i]);
		velocityOutY[i] = velocityInY[i] + (accelerationInY[i] + accelerationY) * deltaTimeHalf;
		accelerationOutY[i] = accelerationY;

		positionOutZ[i] = positionInZ[i] + velocityInZ[i] * deltaTime + accelerationInZ[i] * deltaTimeHalfSquared;
		auto accelerationZ = gravityZ[i] - ((0.5f * drag[i] * velocityInZ[i] * std::abs(velocityInZ[i])) / mass[i]);
		velocityOutZ[i] = velocityInZ[i] + (accelerationInZ[i] + accelerationZ) * deltaTimeHalf;
		accelerationOutZ[i] = accelerationZ;
	}
}

SSN_DECLSPEC void SSN_CDECL CatmullRomFloat(float* __restrict a, float* __restrict b, float* __restrict c, float* __restrict d, float* __restrict amount, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto amountV = amount[i];
		auto amountSquared = amountV * amountV;
		auto amountCubed = amountSquared * amountV;
		auto value1 = a[i];
		auto value2 = b[i];
		auto value3 = c[i];
		auto value4 = d[i];
		result[i] = 0.5f * (((2.0f * value2 + (value3 - value1) * amountV) + ((2.0f * value1 - 5.0f * value2 + 4.0f * value3 - value4) * amountSquared) + (3.0f * value2 - value1 - 3.0f * value3 + value4) * amountCubed));
	}
}

void SSN_CDECL NegateFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = -a[i];
	}
}

void SSN_CDECL HermiteFloat(float* __restrict a, float* __restrict ta, float* __restrict b, float* __restrict tb, float* __restrict amount, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		float s = amount[i];
		float s2 = s * s;
		float s3 = s2 * s;

		float h1 = 2 * s3 - 3 * s2 + 1;
		float h2 = -2 * s3 + 3 * s2;
		float h3 = s3 - 2 * s2 + s;
		float h4 = s3 - s2;

		result[i] = h1 * a[i] + h2 * b[i] + h3 * ta[i] + h4 * tb[i];
	}
}

void SSN_CDECL HermiteFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict taX, float* __restrict taY, float* __restrict taZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict tbX, float* __restrict tbY, float* __restrict tbZ,
	float* __restrict amount,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		float s = amount[i];
		float s2 = s * s;
		float s3 = s2 * s;

		float h1 = 2 * s3 - 3 * s2 + 1;
		float h2 = -2 * s3 + 3 * s2;
		float h3 = s3 - 2 * s2 + s;
		float h4 = s3 - s2;

		resultX[i] = h1 * aX[i] + h2 * bX[i] + h3 * taX[i] + h4 * tbX[i];
		resultY[i] = h1 * aY[i] + h2 * bY[i] + h3 * taY[i] + h4 * tbY[i];
		resultZ[i] = h1 * aZ[i] + h2 * bZ[i] + h3 * taZ[i] + h4 * tbZ[i];
	}
}

void SSN_CDECL SmoothstepFloat(float* __restrict a, float* __restrict b, float* __restrict f, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto amount = f[i];
		auto scale = (amount * amount * (3 - 2 * amount));
		auto va = a[i];
		result[i] = va + (b[i] - va) * scale;
	}
}

void SSN_CDECL SmoothstepFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict f,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto amount = f[i];
		auto scale = (amount * amount * (3 - 2 * amount));
		auto vaX = aX[i];
		auto vaY = aY[i];
		auto vaZ = aZ[i];
		resultX[i] = vaX + (bX[i] - vaX) * scale;
		resultY[i] = vaY + (bY[i] - vaY) * scale;
		resultZ[i] = vaZ + (bZ[i] - vaZ) * scale;
	}
}

void SSN_CDECL BarycentricFloat(float* __restrict v1, float* __restrict v2, float* __restrict v3, float* __restrict a1, float* __restrict a2, float* __restrict result, int count) {
	for (int32_t i = 0; i < count; ++i) {
		auto v1v = v1[i];
		result[i] = v1v + (v2[i] - v1v) * a1[i] + (v3[i] - v1v) * a2[i];
	}
}

void SSN_CDECL BarycentricFloat3(
	float* __restrict v1X, float* __restrict v1Y, float* __restrict v1Z,
	float* __restrict v2X, float* __restrict v2Y, float* __restrict v2Z,
	float* __restrict v3X, float* __restrict v3Y, float* __restrict v3Z,
	float* __restrict a1,
	float* __restrict a2,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto a1v = a1[i];
		auto a2v = a2[i];

		auto v1Xv = v1X[i];
		resultX[i] = v1Xv + (v2X[i] - v1Xv) * a1v + (v3X[i] - v1Xv) * a2v;
		auto v1Yv = v1Y[i];
		resultY[i] = v1Yv + (v2Y[i] - v1Yv) * a1v + (v3Y[i] - v1Yv) * a2v;
		auto v1Zv = v1Z[i];
		resultZ[i] = v1Zv + (v2Z[i] - v1Zv) * a1v + (v3Z[i] - v1Zv) * a2v;
	}
}

void SSN_CDECL CrossFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		resultX[i] = aY[i] * bZ[i] - aZ[i] * bY[i];
		resultY[i] = aZ[i] * bX[i] - aX[i] * bZ[i];
		resultZ[i] = aX[i] * bY[i] - aY[i] * bX[i];
	}
}

void SSN_CDECL ReflectFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict normalX, float* __restrict normalY, float* __restrict normalZ,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		float d2 = sqrtf(normalX[i] * vectorX[i] + normalY[i] * vectorY[i] + normalZ[i] * vectorZ[i]);
		d2 = d2 + d2;
		resultX[i] = d2 * normalX[i] - vectorX[i];
		resultY[i] = d2 * normalY[i] - vectorY[i];
		resultZ[i] = d2 * normalZ[i] - vectorZ[i];
	}
}

void SSN_CDECL TransformFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict matrix,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int count) {
	for (int32_t i = 0; i < count; ++i) {
		resultX[i] = vectorX[i] * matrix[0] + vectorY[i] * matrix[4] + vectorZ[i] * matrix[8] + matrix[12];
		resultY[i] = vectorX[i] * matrix[1] + vectorY[i] * matrix[5] + vectorZ[i] * matrix[9] + matrix[13];
		resultZ[i] = vectorX[i] * matrix[2] + vectorY[i] * matrix[6] + vectorZ[i] * matrix[10] + matrix[14];
	}
}

void SSN_CDECL RefractFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict normalX, float* __restrict normalY, float* __restrict normalZ,
	float* __restrict etaiOverEtat,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto cosTheta = -vectorX[i] * normalX[i] - vectorY[i] * normalY[i] - vectorZ[i] * normalZ[i];
		auto etaiOverEtatV = etaiOverEtat[i];
		auto rOutParallelX = etaiOverEtatV * (vectorX[i] + (cosTheta * normalX[i]));
		auto rOutParallelY = etaiOverEtatV * (vectorY[i] + (cosTheta * normalY[i]));
		auto rOutParallelZ = etaiOverEtatV * (vectorZ[i] + (cosTheta * normalZ[i]));

		auto t = sqrtf(1.0f - (rOutParallelX * rOutParallelX + rOutParallelY * rOutParallelY + rOutParallelZ * rOutParallelZ));

		resultX[i] = rOutParallelX - t * normalX[i];
		resultY[i] = rOutParallelY - t * normalY[i];
		resultZ[i] = rOutParallelZ - t * normalZ[i];
	}
}

void SSN_CDECL SqrtFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		result[i] = sqrtf(a[i]);
	}
}

const float gamma = 2.4f;
const float inverseGamma = 0.41666666f;

void SSN_CDECL SrgbToLinearFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto v = a[i];
		if (v <= 0.04045f)
			result[i] = v / 12.92f;
		else
			result[i] = powf((v + 0.055f) / 1.055f, 2.4f);
	}
}

void SSN_CDECL LinearToSrgbFloat(float* __restrict a, float* __restrict result, int32_t count) {
	for (int32_t i = 0; i < count; ++i) {
		auto linear = a[i];
		if (linear < 0.0f)
			result[i] = 0.0f;
		else if (linear >= 1.0f)
			result[i] = 1.0f;
		else if (linear <= 0.00313066844250063)
			result[i] = linear * 12.92f;
		else
			result[i] = powf(linear, inverseGamma) * 1.055f - 0.055f;
	}
}

