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

        public static void DistanceSquared(VecFloat3 a, VecFloat3 b, VecFloat result) {
#if DEBUG
            if ((a.X._count != result._count)||(b.X._count != result._count))
                throw new ArgumentOutOfRangeException();
#endif
            NativeMethods.DistanceSquaredFloat3(a.X._buffer, a.Y._buffer, a.Z._buffer, b.X._buffer, b.Y._buffer, b.Z._buffer, result._buffer, a.X._count);
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

        public static void CatmullRom(VecFloat3 a, VecFloat3 b, VecFloat3 c, VecFloat3 d, VecFloat amount, VecFloat3 result) {
            VecFloat.CatmullRom(a.X, b.X, c.X, d.X, amount, result.X);
            VecFloat.CatmullRom(a.Y, b.Y, c.Y, d.Y, amount, result.Y);
            VecFloat.CatmullRom(a.Z, b.Z, c.Z, d.Z, amount, result.Z);
        }

        public static void Negate(VecFloat3 a, VecFloat3 result) {
            VecFloat.Negate(a.X, result.X);
            VecFloat.Negate(a.Y, result.Y);
            VecFloat.Negate(a.Z, result.Z);
        }

        public static void Hermite(VecFloat3 a, VecFloat3 ta, VecFloat3 b, VecFloat3 tb, VecFloat amount, VecFloat3 result) {
            NativeMethods.HermiteFloat3(
                a.X._buffer, a.Y._buffer, a.Z._buffer,
                ta.X._buffer, ta.Y._buffer, ta.Z._buffer,
                b.X._buffer, b.Y._buffer, b.Z._buffer,
                tb.X._buffer, tb.Y._buffer, tb.Z._buffer,
                amount._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void SmoothStep(VecFloat3 a, VecFloat3 b, VecFloat amount, VecFloat3 result) {
            NativeMethods.SmoothstepFloat3(
                a.X._buffer, a.Y._buffer, a.Z._buffer,
                b.X._buffer, b.Y._buffer, b.Z._buffer,
                amount._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void BarycentricFloat3(VecFloat3 v1, VecFloat3 v2, VecFloat3 v3, VecFloat a1, VecFloat a2, VecFloat3 result) {
            NativeMethods.BarycentricFloat3(
                v1.X._buffer, v1.Y._buffer, v1.Z._buffer,
                v2.X._buffer, v2.Y._buffer, v2.Z._buffer,
                v3.X._buffer, v3.Y._buffer, v3.Z._buffer,
                a1._buffer,
                a2._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void Cross(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            NativeMethods.CrossFloat3(
                a.X._buffer, a.Y._buffer, a.Z._buffer,
                b.X._buffer, b.Y._buffer, b.Z._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void Reflect(VecFloat3 vector, VecFloat3 normal, VecFloat3 result) {
            NativeMethods.ReflectFloat3(
                vector.X._buffer, vector.Y._buffer, vector.Z._buffer,
                normal.X._buffer, normal.Y._buffer, normal.Z._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void Reflect(VecFloat3 vector, VecFloat matrix, VecFloat3 result) {
            if (matrix.Count != 16)
                throw new ArgumentOutOfRangeException("matrix");
            NativeMethods.TransformFloat3(
                vector.X._buffer, vector.Y._buffer, vector.Z._buffer,
                matrix._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void Refract(VecFloat3 vector, VecFloat3 normal, VecFloat etaiOverEtat, VecFloat3 result) {
            NativeMethods.RefractFloat3(
                vector.X._buffer, vector.Y._buffer, vector.Z._buffer,
                normal.X._buffer, normal.Y._buffer, normal.Z._buffer,
                etaiOverEtat._buffer,
                result.X._buffer, result.Y._buffer, result.Z._buffer,
                result.Count);
        }

        public static void LinearToSrgb(VecFloat3 a, VecFloat3 result) {
            VecFloat.LinearToSrgb(a.X, result.X);
            VecFloat.LinearToSrgb(a.Y, result.Y);
            VecFloat.LinearToSrgb(a.Z, result.Z);
        }

        public static void SrgbToLinear(VecFloat3 a, VecFloat3 result) {
            VecFloat.SrgbToLinear(a.X, result.X);
            VecFloat.SrgbToLinear(a.Y, result.Y);
            VecFloat.SrgbToLinear(a.Z, result.Z);
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
            [DllImport("SimdSharpNative.dll", EntryPoint = "DistanceSquaredFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void DistanceSquaredFloat3(IntPtr ax, IntPtr ay, IntPtr az, IntPtr bx, IntPtr by, IntPtr bz, IntPtr r, int count);
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

            [DllImport("SimdSharpNative.dll", EntryPoint = "HermiteFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void HermiteFloat3(
                IntPtr aX, IntPtr aY, IntPtr aZ,
                IntPtr taX, IntPtr taY, IntPtr taZ,
                IntPtr bX, IntPtr bY, IntPtr bZ,
                IntPtr tbX, IntPtr tbY, IntPtr tbZ,
                IntPtr amount,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "SmoothstepFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void SmoothstepFloat3(
                IntPtr aX, IntPtr aY, IntPtr aZ,
                IntPtr bX, IntPtr bY, IntPtr bZ,
                IntPtr amount,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "BarycentricFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void BarycentricFloat3(
                IntPtr v1X, IntPtr v1Y, IntPtr v1Z,
                IntPtr v2X, IntPtr v2Y, IntPtr v2Z,
                IntPtr v3X, IntPtr v3Y, IntPtr v3Z,
                IntPtr a1,
                IntPtr a2,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "CrossFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void CrossFloat3(
                IntPtr aX, IntPtr aY, IntPtr aZ,
                IntPtr bX, IntPtr bY, IntPtr bZ,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "ReflectFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void ReflectFloat3(
                IntPtr vectorX, IntPtr vectorY, IntPtr vectorZ,
                IntPtr normalX, IntPtr normalY, IntPtr normalZ,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "TransformFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void TransformFloat3(
                IntPtr vectorX, IntPtr vectorY, IntPtr vectorZ,
                IntPtr matrix,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);

            [DllImport("SimdSharpNative.dll", EntryPoint = "RefractFloat3", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
            public static extern unsafe void RefractFloat3(
                IntPtr vectorX, IntPtr vectorY, IntPtr vectorZ,
                IntPtr normalX, IntPtr normalY, IntPtr normalZ,
                IntPtr etaiOverEtat,
                IntPtr resultX, IntPtr resultY, IntPtr resultZ,
                int count);
        }
    }
}