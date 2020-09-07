using Microsoft.VisualStudio.TestTools.UnitTesting;
using SimdSharp;
using System;

namespace SimdShard.UnitTest {
    [TestClass]
    public class BasicMath {
        [TestMethod]
        public void AllocateAndDeallocate() {
            var vector = Vector.Allocate(1024);
            Vector.Release(ref vector);
        }

        [TestMethod]
        public void SetAndRead() {
            var vector = Vector.Allocate(1024);

            for (var i = 0; i < vector.Count; ++i) {
                float f = i;
                vector.Set(i, f);
            }

            for (var i = 0; i < vector.Count; ++i) {
                float f = i;
                var b = vector.Get(i);
                if (f != b)
                    throw new Exception();
            }

            Vector.Release(ref vector);
        }


        [TestMethod]
        public void Min() {

            var a = Vector.Allocate(1024);
            a.SetAll(2);

            var b = Vector.Allocate(1024);
            b.SetAll(5);

            var r = Vector.Allocate(1024);

            Vector.Min(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r.Get(i) != 2)
                    throw new Exception();
            }
            Vector.Release(ref a);
            Vector.Release(ref b);
            Vector.Release(ref r);
        }

        [TestMethod]
        public void Max() {

            var a = Vector.Allocate(1024);
            a.SetAll(2);

            var b = Vector.Allocate(1024);
            b.SetAll(5);

            var r = Vector.Allocate(1024);

            Vector.Max(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r.Get(i) != 5)
                    throw new Exception();
            }
            Vector.Release(ref a);
            Vector.Release(ref b);
            Vector.Release(ref r);
        }
    }
}