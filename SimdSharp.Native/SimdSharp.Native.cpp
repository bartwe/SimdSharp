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

