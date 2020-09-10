using System;
using System.Runtime.InteropServices;

namespace SimdSharp {
    public struct VecFloat3 {
        public VecFloat X;
        public VecFloat Y;
        public VecFloat Z;

        public int Count => X.Count;

        public static VecFloat3 Allocate(int count) {
            VecFloat3 result;
            result.X = VecFloat.Allocate(count);
            result.Y = VecFloat.Allocate(count);
            result.Z = VecFloat.Allocate(count);
            return result;
        }

        public static void Release(ref VecFloat3 vector) {
            VecFloat.Release(ref vector.X);
            VecFloat.Release(ref vector.Y);
            VecFloat.Release(ref vector.Z);
        }

        public static void Min(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Min(a.X, b.X, result.X);
            VecFloat.Min(a.Y, b.Y, result.Y);
            VecFloat.Min(a.Z, b.Z, result.Z);
        }

        public static void Min(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Min(a.X, b, result.X);
            VecFloat.Min(a.Y, b, result.Y);
            VecFloat.Min(a.Z, b, result.Z);
        }

        public static void Max(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Max(a.X, b.X, result.X);
            VecFloat.Max(a.Y, b.Y, result.Y);
            VecFloat.Max(a.Z, b.Z, result.Z);
        }

        public static void Max(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Max(a.X, b, result.X);
            VecFloat.Max(a.Y, b, result.Y);
            VecFloat.Max(a.Z, b, result.Z);
        }

        public static void Clamp(VecFloat3 values, VecFloat3 min, VecFloat3 max, VecFloat3 result) {
            VecFloat.Clamp(values.X, min.X, max.X, result.X);
            VecFloat.Clamp(values.Y, min.Y, max.Y, result.Y);
            VecFloat.Clamp(values.Z, min.Z, max.Z, result.Z);
        }

        public static void Clamp(VecFloat3 values, VecFloat min, VecFloat max, VecFloat3 result) {
            VecFloat.Clamp(values.X, min, max, result.X);
            VecFloat.Clamp(values.Y, min, max, result.Y);
            VecFloat.Clamp(values.Z, min, max, result.Z);
        }

        public static void Add(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Add(a.X, b.X, result.X);
            VecFloat.Add(a.Y, b.Y, result.Y);
            VecFloat.Add(a.Z, b.Z, result.Z);
        }

        public static void Add(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Add(a.X, b, result.X);
            VecFloat.Add(a.Y, b, result.Y);
            VecFloat.Add(a.Z, b, result.Z);
        }

        public static void Subtract(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Subtract(a.X, b.X, result.X);
            VecFloat.Subtract(a.Y, b.Y, result.Y);
            VecFloat.Subtract(a.Z, b.Z, result.Z);
        }

        public static void Subtract(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Subtract(a.X, b, result.X);
            VecFloat.Subtract(a.Y, b, result.Y);
            VecFloat.Subtract(a.Z, b, result.Z);
        }

        public static void Multiply(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Multiply(a.X, b.X, result.X);
            VecFloat.Multiply(a.Y, b.Y, result.Y);
            VecFloat.Multiply(a.Z, b.Z, result.Z);
        }

        public static void Multiply(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Multiply(a.X, b, result.X);
            VecFloat.Multiply(a.Y, b, result.Y);
            VecFloat.Multiply(a.Z, b, result.Z);
        }

        public static void Divide(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Divide(a.X, b.X, result.X);
            VecFloat.Divide(a.Y, b.Y, result.Y);
            VecFloat.Divide(a.Z, b.Z, result.Z);
        }

        public static void Divide(VecFloat3 a, VecFloat b, VecFloat3 result) {
            VecFloat.Divide(a.X, b, result.X);
            VecFloat.Divide(a.Y, b, result.Y);
            VecFloat.Divide(a.Z, b, result.Z);
        }

        public static void MultiplyAdd(VecFloat3 a, VecFloat3 b, VecFloat3 c, VecFloat3 result) {
            VecFloat.MultiplyAdd(a.X, b.X, c.X, result.X);
            VecFloat.MultiplyAdd(a.Y, b.Y, c.Y, result.Y);
            VecFloat.MultiplyAdd(a.Z, b.Z, c.Z, result.Z);
        }

        public static void MultiplyAdd(VecFloat3 a, VecFloat b, VecFloat c, VecFloat3 result) {
            VecFloat.MultiplyAdd(a.X, b, c, result.X);
            VecFloat.MultiplyAdd(a.Y, b, c, result.Y);
            VecFloat.MultiplyAdd(a.Z, b, c, result.Z);
        }

        public static void Floor(VecFloat3 a, VecFloat3 result) {
            VecFloat.Floor(a.X, result.X);
            VecFloat.Floor(a.Y, result.Y);
            VecFloat.Floor(a.Z, result.Z);
        }

        public static void Ceil(VecFloat3 a, VecFloat3 result) {
            VecFloat.Floor(a.X, result.X);
            VecFloat.Floor(a.Y, result.Y);
            VecFloat.Floor(a.Z, result.Z);
        }

        // result[i] = a[i] ? b[i] : c[i]
        public static void Select(VecFloat a, VecFloat3 b, VecFloat3 c, VecFloat3 result) {
            VecFloat.Select(a, b.X, c.X, result.X);
            VecFloat.Select(a, b.Y, c.Y, result.Y);
            VecFloat.Select(a, b.Z, c.Z, result.Z);
        }

        public static void Normalize(VecFloat3 a, VecFloat3 result) {
#if DEBUG
            if (a.X._count != result.X._count)
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.NormalizeFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, result.X._buffer, result.Y._buffer, result.Z._buffer, a.X._count);
        }


        public static void Length(VecFloat3 a, VecFloat result) {
#if DEBUG
            if (a.X._count != result._count)
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.LengthFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, result._buffer, a.X._count);
        }


        public static void LengthSquared(VecFloat3 a, VecFloat result) {
#if DEBUG
            if (a.X._count != result._count)
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.LengthSquaredFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, result._buffer, a.X._count);
        }

        public static void Dot(VecFloat3 a, VecFloat3 b, VecFloat result) {
#if DEBUG
            if ((a.X._count != result._count)||(b.X._count != result._count))
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.DotFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, b.X._buffer, b.Y._buffer, b.Z._buffer, result._buffer, a.X._count);
        }

        public static void Lerp(VecFloat3 a, VecFloat3 b, VecFloat f, VecFloat3 result) {
#if DEBUG
            if ((a.X._count != result.X._count)||(b.X._count != result.X._count)||(f._count != result.X._count))
                throw new ArgumentOutOfRangeException();
#endif
            VecFloat.Lerp(a.X, b.X, f, result.X);
            VecFloat.Lerp(a.Y, b.Y, f, result.Y);
            VecFloat.Lerp(a.Z, b.Z, f, result.Z);
        }

        public static void Lerp(VecFloat3 a, VecFloat3 b, VecFloat3 f, VecFloat3 result) {
#if DEBUG
            if ((a.X._count != result.X._count)||(b.X._count != result.X._count)||(f.X._count != result.X._count))
                throw new ArgumentOutOfRangeException();
#endif
            VecFloat.Lerp(a.X, b.X, f.X, result.X);
            VecFloat.Lerp(a.Y, b.Y, f.Y, result.Y);
            VecFloat.Lerp(a.Z, b.Z, f.Z, result.Z);
        }

        public static void Distance(VecFloat3 a, VecFloat3 b, VecFloat result) {
#if DEBUG
            if ((a.X._count != result._count)||(b.X._count != result._count))
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.DistanceFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, b.X._buffer, b.Y._buffer, b.Z._buffer, result._buffer, a.X._count);
        }

        public static void Abs(VecFloat3 a, VecFloat3 result) {
            VecFloat.Abs(a.X, result.X);
            VecFloat.Abs(a.Y, result.Y);
            VecFloat.Abs(a.Z, result.Z);
        }

        public static void Verlet(VecFloat3 positionIn, VecFloat3 velocityIn, VecFloat3 accelerationIn, VecFloat3 forceIn, VecFloat drag, VecFloat mass, float deltaTime, VecFloat3 positionOut, VecFloat3 velocityOut, VecFloat3 accelerationOut) {
            NativeMethods.VerletFloat3(
                 positionIn.X._buffer, positionIn.Y._buffer, positionIn.Z._buffer,
                 velocityIn.X._buffer, velocityIn.Y._buffer, velocityIn.Z._buffer,
                 accelerationIn.X._buffer, accelerationIn.Y._buffer, accelerationIn.Z._buffer,
                 forceIn.X._buffer, forceIn.Y._buffer, forceIn.Z._buffer,
                 drag._buffer,
                 mass._buffer,
                 deltaTime,
                 positionOut.X._buffer, positionOut.Y._buffer, positionOut.Z._buffer,
                 velocityOut.X._buffer, velocityOut.Y._buffer, velocityOut.Z._buffer,
                 accelerationOut.X._buffer, accelerationOut.Y._buffer, accelerationOut.Z._buffer,
                positionIn.Count);
        }

        class NativeMethods {
            [DllImport("SimdSharpNative.dll", EntryPoint = "NormalizeFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void NormalizeFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr rx, IntPtr ry, IntPtr rz, int count);
            [DllImport("SimdSharpNative.dll", EntryPoint = "LengthFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void LengthFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr r, int count);
            [DllImport("SimdSharpNative.dll", EntryPoint = "LengthSquaredFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void LengthSquaredFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr r, int count);
            [DllImport("SimdSharpNative.dll", EntryPoint = "DotFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void DotFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr bx, IntPtr by, IntPtr bz, IntPtr r, int count);
            [DllImport("SimdSharpNative.dll", EntryPoint = "DistanceFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void DistanceFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr bx, IntPtr by, IntPtr bz, IntPtr r, int count);
            [DllImport("SimdSharpNative.dll", EntryPoint = "VerletFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void VerletFloat3(
                IntPtr positionInX, IntPtr positionInY, IntPtr positionInZ,
                IntPtr velocityInX, IntPtr velocityInY, IntPtr velocityInZ,
                IntPtr accelerationInX, IntPtr accelerationInY, IntPtr accelerationInZ,
                IntPtr gravityX, IntPtr gravityY, IntPtr gravityZ,
                IntPtr drag,
                IntPtr mass,
                float deltaTime,
                IntPtr positionOutX, IntPtr positionOutY, IntPtr positionOutZ,
                IntPtr velocityOutX, IntPtr velocityOutY, IntPtr velocityOutZ,
                IntPtr accelerationOutX, IntPtr accelerationOutY, IntPtr accelerationOutZ,
                int count);
        }
    }
}