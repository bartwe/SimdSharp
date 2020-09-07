// SimdSharp.Native.cpp : Defines the exported functions for the DLL.
//

#include "pch.h"
#include "framework.h"
#include "SimdSharp.Native.h"
#include "malloc.h"
#include <algorithm>


float* SSN_CDECL AllocateFloat(int32_t blocks) {
	return (float*)_aligned_malloc(blocks * SSN_VECTOR_SIZE * sizeof(float), SSN_ALIGNMENT);
}

void SSN_CDECL ReleaseFloat(float* buffer) {
	_aligned_free(buffer);
}

void SSN_CDECL GetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count) {
	memcpy(&values[valuesOffset], &buffer[offset], count * sizeof(float));
}

void SSN_CDECL SetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count) {
	memcpy(&buffer[offset], &values[valuesOffset], count * sizeof(float));
}

void SSN_CDECL SetAllFloat(float* buffer, float value, int32_t blocks) {
	for (int b = 0; b < blocks; ++b) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i)
			buffer[i] = value;
		buffer = &buffer[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL MinFloat(float* buffer, float* min, float* result, int32_t blocks) {
	for (int b = 0; b < blocks; ++b) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			auto a = buffer[i];
			auto b = min[i];
			if (a > b)
				a = b;
			result[i] = a;
		}
		buffer = &buffer[SSN_VECTOR_SIZE];
		min = &min[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL MaxFloat(float* buffer, float* max, float* result, int32_t blocks) {
	for (int b = 0; b < blocks; ++b) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			auto a = buffer[i];
			auto b = max[i];
			if (a < b)
				a = b;
			result[i] = a;
		}
		buffer = &buffer[SSN_VECTOR_SIZE];
		max = &max[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL ClampFloat(float* buffer, float* low, float* high, float* result, int32_t blocks) {
	for (int b = 0; b < blocks; ++b) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			auto a = buffer[i];
			auto c = high[i];
			if (a > c)
				a = c;
			auto b = low[i];
			if (a < b)
				a = b;
			result[i] = a;
		}
		buffer = &buffer[SSN_VECTOR_SIZE];
		low = &low[SSN_VECTOR_SIZE];
		high = &high[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}


float SSN_CDECL SumFloat(float* buffer, int blocks) {
	float result = 0.0f;
	for (int b = 0; b < blocks; ++b) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result += buffer[i];
		}
		buffer = &buffer[SSN_VECTOR_SIZE];
	}
	return result;
}

void SSN_CDECL AddFloat(float* a, float* b, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] + b[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL SubtractFloat(float* a, float* b, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] - b[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL MultiplyFloat(float* a, float* b, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] * b[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL DivideFloat(float* a, float* b, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] / b[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL MultiplyAddFloat(float* a, float* b, float* c, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] * b[i] + c[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		c = &c[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL FloorFloat(float* a, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = std::floor(a[i]);
		}
		a = &a[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL CeilFloat(float* a, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = std::ceil(a[i]);
		}
		a = &a[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

void SSN_CDECL SelectFloat(float* a, float* b, float* c, float* result, int blocks) {
	for (int bi = 0; bi < blocks; ++bi) {
		for (int i = 0; i < SSN_VECTOR_SIZE; ++i) {
			result[i] = a[i] ?  b[i] : c[i];
		}
		a = &a[SSN_VECTOR_SIZE];
		b = &b[SSN_VECTOR_SIZE];
		c = &c[SSN_VECTOR_SIZE];
		result = &result[SSN_VECTOR_SIZE];
	}
}

