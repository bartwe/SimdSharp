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


