using System;
using System.Runtime.InteropServices;

namespace SimdSharp {
    public struct VecFloat {
        const int BlockSize = 64;

        int _slots;
        int _blocks;
        IntPtr _buffer;

        public int Count => _slots;

        public static VecFloat Allocate(int slots) {
#if DEBUG
            if (slots < 0)
                throw new ArgumentOutOfRangeException("slots");
#endif
            var blocks = (slots + BlockSize - 1) / BlockSize;
            VecFloat vecFloat;
            vecFloat._slots = slots;
            vecFloat._blocks = blocks;
            vecFloat._buffer = NativeMethods.AllocateFloat(blocks);
            return vecFloat;
        }

        public static void Release(ref VecFloat vecFloat) {
#if DEBUG
            if (vecFloat._buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is already released", "vecFloat");
#endif
            NativeMethods.ReleaseFloat(vecFloat._buffer);
            vecFloat._slots = 0;
            vecFloat._blocks = 0;
            vecFloat._buffer = IntPtr.Zero;
        }

        public unsafe float this[int index] {
            get {
#if DEBUG
                if ((index < 0) || (index >= _slots))
                    throw new ArgumentOutOfRangeException("index");
                if (_buffer == IntPtr.Zero)
                    throw new ArgumentException("Vector is not allocated", "vector");
#endif
                var ptr = (float*)_buffer;
                return ptr[index];
            }
            set {
#if DEBUG
                if ((index < 0) || (index >= _slots))
                    throw new ArgumentOutOfRangeException("index");
                if (_buffer == IntPtr.Zero)
                    throw new ArgumentException("Vector is not allocated", "vector");
#endif
                var ptr = (float*)_buffer;
                ptr[index] = value;
            }
        }

        public unsafe void Set(int index, float value) {
#if DEBUG
            if ((index < 0) || (index >= _slots))
                throw new ArgumentOutOfRangeException("index");
            if (_buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is not allocated", "vector");
#endif
            var ptr = (float*)_buffer;
            ptr[index] = value;
        }

        public unsafe float Get(int index) {
#if DEBUG
            if ((index < 0) || (index >= _slots))
                throw new ArgumentOutOfRangeException("index");
            if (_buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is not allocated", "vector");
#endif
            var ptr = (float*)_buffer;
            return ptr[index];
        }

        public unsafe void SetRange(int offset, float[] values, int valuesOffset, int count) {
#if DEBUG
            if ((offset < 0) || (offset >= _slots))
                throw new ArgumentOutOfRangeException("offset");
            if ((valuesOffset < 0) || (valuesOffset >= _slots))
                throw new ArgumentOutOfRangeException("valuesOffset");
            if ((count < 0) || ((offset + count) >= _slots) || ((valuesOffset + count) >= _slots))
                throw new ArgumentOutOfRangeException("count");
            if (_buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is not allocated", "vector");
#endif
            fixed (float* ptr = values)
                NativeMethods.SetRangeFloat(_buffer, offset, ptr, valuesOffset, count);
        }

        public unsafe void GetRange(int offset, float[] values, int valuesOffset, int count) {
#if DEBUG
            if ((offset < 0) || (offset >= _slots))
                throw new ArgumentOutOfRangeException("offset");
            if ((valuesOffset < 0) || (valuesOffset >= _slots))
                throw new ArgumentOutOfRangeException("valuesOffset");
            if ((count < 0) || ((offset + count) >= _slots) || ((valuesOffset + count) >= _slots))
                throw new ArgumentOutOfRangeException("count");
            if (_buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is not allocated", "vector");
#endif
            fixed (float* ptr = values)
                NativeMethods.GetRangeFloat(_buffer, offset, ptr, valuesOffset, count);
        }

        public unsafe void SetAll(float value) {
#if DEBUG
            if (_buffer == IntPtr.Zero)
                throw new ArgumentException("Vector is not allocated", "vector");
#endif
            NativeMethods.SetAllFloat(_buffer, value, _blocks);
        }

        public static void Min(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.MinFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void Max(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.MaxFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void Clamp(VecFloat values, VecFloat min, VecFloat max, VecFloat result) {
#if DEBUG
            if ((values._slots != min._slots) || (values._slots != max._slots) || (values._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == values._buffer) || (result._buffer == min._buffer) || (result._buffer == max._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.ClampFloat(values._buffer, min._buffer, max._buffer, result._buffer, result._blocks);
        }

        public static float Sum(VecFloat vecFloat) {
            return NativeMethods.SumFloat(vecFloat._buffer, vecFloat._blocks);
        }

        public static void Add(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.AddFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void Subtract(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.SubtractFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void Multiply(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.MultiplyFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void Divide(VecFloat a, VecFloat b, VecFloat result) {
#if DEBUG
            if ((a._slots != b._slots) || (a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.DivideFloat(a._buffer, b._buffer, result._buffer, result._blocks);
        }

        public static void MultiplyAdd(VecFloat a, VecFloat b, VecFloat c, VecFloat result) {
#if DEBUG
            if ((a._slots != result._slots) || (b._slots != result._slots) || (c._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer) || (result._buffer == c._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.MultiplyAddFloat(a._buffer, b._buffer, c._buffer, result._buffer, result._blocks);
        }

        public static void Floor(VecFloat a, VecFloat result) {
#if DEBUG
            if ((a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.FloorFloat(a._buffer, result._buffer, result._blocks);
        }

        public static void Ceil(VecFloat a, VecFloat result) {
#if DEBUG
            if ((a._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.CeilFloat(a._buffer, result._buffer, result._blocks);
        }

        // result[i] = a[i] ? b[i] : c[i]
        public static void Select(VecFloat a, VecFloat b, VecFloat c, VecFloat result) {
#if DEBUG
            if ((a._slots != result._slots) || (b._slots != result._slots) || (c._slots != result._slots))
                throw new ArgumentOutOfRangeException();
            if ((result._buffer == a._buffer) || (result._buffer == b._buffer) || (result._buffer == c._buffer))
                throw new ArgumentException("Result vector may not also be input vector", "result");
#endif
            NativeMethods.SelectFloat(a._buffer, b._buffer, c._buffer, result._buffer, result._blocks);
        }
    }

    internal class NativeMethods {
        [DllImport("SimdSharpNative.dll", EntryPoint = "AllocateFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern IntPtr AllocateFloat(int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "ReleaseFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern void ReleaseFloat(IntPtr buffer);

        [DllImport("SimdSharpNative.dll", EntryPoint = "GetRangeFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void GetRangeFloat(IntPtr buffer, int offset, float* values, int valuesOffset, int count);

        [DllImport("SimdSharpNative.dll", EntryPoint = "SetRangeFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void SetRangeFloat(IntPtr buffer, int offset, float* values, int valuesOffset, int count);

        [DllImport("SimdSharpNative.dll", EntryPoint = "SetAllFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void SetAllFloat(IntPtr buffer, float value, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "MinFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void MinFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "MaxFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void MaxFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "ClampFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void ClampFloat(IntPtr buffer, IntPtr low, IntPtr high, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "SumFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe float SumFloat(IntPtr buffer, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "AddFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void AddFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "SubtractFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void SubtractFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "MultiplyFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void MultiplyFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "DivideFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void DivideFloat(IntPtr a, IntPtr b, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "MultiplyAddFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void MultiplyAddFloat(IntPtr a, IntPtr b, IntPtr c, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "FloorFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void FloorFloat(IntPtr a, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "CeilFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void CeilFloat(IntPtr a, IntPtr result, int blocks);

        [DllImport("SimdSharpNative.dll", EntryPoint = "SelectFloat", CallingConvention = CallingConvention.Cdecl, SetLastError = false)]
        public static extern unsafe void SelectFloat(IntPtr a, IntPtr b, IntPtr c, IntPtr result, int blocks);
    }
}
