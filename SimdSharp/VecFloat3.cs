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

        public static void Max(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Max(a.X, b.X, result.X);
            VecFloat.Max(a.Y, b.Y, result.Y);
            VecFloat.Max(a.Z, b.Z, result.Z);
        }

        public static void Clamp(VecFloat3 values, VecFloat3 min, VecFloat3 max, VecFloat3 result) {
            VecFloat.Clamp(values.X, min.X, max.X, result.X);
            VecFloat.Clamp(values.Y, min.Y, max.Y, result.Y);
            VecFloat.Clamp(values.Z, min.Z, max.Z, result.Z);
        }

        public static void Add(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Add(a.X, b.X, result.X);
            VecFloat.Add(a.Y, b.Y, result.Y);
            VecFloat.Add(a.Z, b.Z, result.Z);
        }

        public static void Subtract(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Subtract(a.X, b.X, result.X);
            VecFloat.Subtract(a.Y, b.Y, result.Y);
            VecFloat.Subtract(a.Z, b.Z, result.Z);
        }

        public static void Multiply(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Multiply(a.X, b.X, result.X);
            VecFloat.Multiply(a.Y, b.Y, result.Y);
            VecFloat.Multiply(a.Z, b.Z, result.Z);
        }

        public static void Divide(VecFloat3 a, VecFloat3 b, VecFloat3 result) {
            VecFloat.Divide(a.X, b.X, result.X);
            VecFloat.Divide(a.Y, b.Y, result.Y);
            VecFloat.Divide(a.Z, b.Z, result.Z);
        }

        public static void MultiplyAdd(VecFloat3 a, VecFloat3 b, VecFloat3 c, VecFloat3 result) {
            VecFloat.MultiplyAdd(a.X, b.X, c.X, result.X);
            VecFloat.MultiplyAdd(a.Y, b.Y, c.Y,result.Y);
            VecFloat.MultiplyAdd(a.Z, b.Z, c.Z,result.Z);
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
    }
}