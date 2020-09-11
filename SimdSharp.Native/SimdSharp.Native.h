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

SSN_DECLSPEC float* SSN_CDECL AllocateFloat(int32_t count);
SSN_DECLSPEC void SSN_CDECL ReleaseFloat(float* buffer);
SSN_DECLSPEC void SSN_CDECL GetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count);
SSN_DECLSPEC void SSN_CDECL SetRangeFloat(float* buffer, int32_t offset, float* values, int32_t valuesOffset, int32_t count);
SSN_DECLSPEC void SSN_CDECL SetAllFloat(float* buffer, float value, int32_t count);

SSN_DECLSPEC void SSN_CDECL MinFloat(float* buffer, float* min, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL MaxFloat(float* buffer, float* max, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL ClampFloat(float* buffer, float* low, float* high, float* result, int32_t count);

SSN_DECLSPEC float SSN_CDECL SumFloat(float* buffer, int32_t count);
SSN_DECLSPEC void SSN_CDECL AddFloat(float* a, float* b, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL SubtractFloat(float* a, float* b, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL MultiplyFloat(float* a, float* b, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL DivideFloat(float*, float* b, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL MultiplyAddFloat(float* a, float* b, float* c, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL FloorFloat(float* a, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL CeilFloat(float* a, float* result, int32_t count);
SSN_DECLSPEC void SSN_CDECL Selectloat(float* a, float* b, float* c, float* result, int32_t count);

SSN_DECLSPEC void SSN_CDECL NormalizeFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict rx, float* __restrict ry, float* __restrict rz, int32_t count);
SSN_DECLSPEC void SSN_CDECL LengthFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict r, int32_t count);
SSN_DECLSPEC void SSN_CDECL LengthSquaredFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict r, int32_t count);
SSN_DECLSPEC void SSN_CDECL AbsFloat(float* __restrict a, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL DotFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int32_t count);
SSN_DECLSPEC void SSN_CDECL LerpFloat(float* __restrict a, float* __restrict b, float* __restrict v, float* __restrict r, int32_t count);
SSN_DECLSPEC void SSN_CDECL DistanceFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int32_t count);
SSN_DECLSPEC void SSN_CDECL DistanceSquaredFloat3(float* __restrict ax, float* __restrict ay, float* __restrict az, float* __restrict bx, float* __restrict by, float* __restrict bz, float* __restrict r, int32_t count);

SSN_DECLSPEC void SSN_CDECL VerletFloat3(
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
	int32_t count);

SSN_DECLSPEC void SSN_CDECL CatmullRomFloat(float* __restrict a, float* __restrict b, float* __restrict c, float* __restrict d, float* __restrict amount, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL NegateFloat(float* __restrict a, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL HermiteFloat(float* __restrict a, float* __restrict ta, float* __restrict b, float* __restrict tb, float* __restrict amount, float* __restrict result, int32_t count);

SSN_DECLSPEC void SSN_CDECL HermiteFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict taX, float* __restrict taY, float* __restrict taZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict tbX, float* __restrict tbY, float* __restrict tbZ,
	float* __restrict amount, 
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL SmoothstepFloat(float* __restrict a, float* __restrict b, float* __restrict f, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL SmoothstepFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict f,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL BarycentricFloat(float* __restrict v1, float* __restrict v2, float* __restrict v3, float* __restrict a1, float* __restrict a2, float* __restrict result, int count);

SSN_DECLSPEC void SSN_CDECL BarycentricFloat3(
	float* __restrict v1X, float* __restrict v1Y, float* __restrict v1Z,
	float* __restrict v2X, float* __restrict v2Y, float* __restrict v2Z,
	float* __restrict v3X, float* __restrict v3Y, float* __restrict v3Z,
	float* __restrict a1,
	float* __restrict a2,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL CrossFloat3(
	float* __restrict aX, float* __restrict aY, float* __restrict aZ,
	float* __restrict bX, float* __restrict bY, float* __restrict bZ,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL ReflectFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict normalX, float* __restrict normalY, float* __restrict normalZ,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL TransformFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict matrix,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int count);

SSN_DECLSPEC void SSN_CDECL RefractFloat3(
	float* __restrict vectorX, float* __restrict vectorY, float* __restrict vectorZ,
	float* __restrict normalX, float* __restrict normalY, float* __restrict normalZ,
	float* __restrict etaiOverEtat,
	float* __restrict resultX, float* __restrict resultY, float* __restrict resultZ,
	int32_t count);

SSN_DECLSPEC void SSN_CDECL SqrtFloat(float* __restrict a, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL SrgbToLinearFloat(float* __restrict a, float* __restrict result, int32_t count);
SSN_DECLSPEC void SSN_CDECL LinearToSrgbFloat(float* __restrict a, float* __restrict result, int32_t count);


SSN_EXTERN_C_END

#endif //SimdSharp_Native_h