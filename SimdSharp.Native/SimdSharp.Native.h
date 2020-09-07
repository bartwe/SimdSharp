#pragma once
#ifndef SimdSharp_Native_h
#define SimdSharp_Native_h
#include <cstdint>

#ifndef SSN_DIRECT_IMPORT
#define SSN_EXTERN_C extern "C" {
#define SSN_EXTERN_C_END }
#ifndef SSN_LINUX
#define SSN_DECLSPEC __declspec(dllexport)
#define SSN_CDECL __cdecl
#else
#define SSN_DECLSPEC 
#define SSN_CDECL 
#endif
#else
#define SSN_EXTERN_C
#define SSN_EXTERN_C_END 
#define SSN_DECLSPEC
#define SSN_CDECL
#endif

#define SSN_VECTOR_SIZE 1024
#define SSN_ALIGNMENT 64

SSN_EXTERN_C

SSN_DECLSPEC float* SSN_CDECL AllocateFloat(int32_t blocks);
SSN_DECLSPEC void SSN_CDECL ReleaseFloat(float* buffer);
SSN_DECLSPEC void SSN_CDECL GetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count);
SSN_DECLSPEC void SSN_CDECL SetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count);
SSN_DECLSPEC void SSN_CDECL SetAllFloat(float* buffer, float value, int32_t blocks);

SSN_DECLSPEC void SSN_CDECL MinFloat(float* buffer, float* min, float* result, int32_t blocks);
SSN_DECLSPEC void SSN_CDECL MaxFloat(float* buffer, float* max, float* result, int32_t blocks);
SSN_DECLSPEC void SSN_CDECL ClampFloat(float* buffer, float* low, float* high, float* result, int32_t blocks);

SSN_DECLSPEC float SSN_CDECL SumFloat(float* buffer, int blocks);
SSN_DECLSPEC void SSN_CDECL AddFloat(float* a, float* b, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL SubtractFloat(float* a, float* b, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL MultiplyFloat(float* a, float* b, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL DivideFloat(float*, float* b, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL MultiplyAddFloat(float* a, float* b, float* c, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL FloorFloat(float* a, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL CeilFloat(float* a, float* result, int blocks);
SSN_DECLSPEC void SSN_CDECL Selectloat(float* a, float* b, float* c, float* result, int blocks);

SSN_EXTERN_C_END

#endif //SimdSharp_Native_h