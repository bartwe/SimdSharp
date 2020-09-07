using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

namespace SimdSharp.UnitTest {
    [TestClass]
    public class BasicMath {
        [TestMethod]
        public void AllocateAndDeallocate() {
            var vector = VecFloat.Allocate(1024);
            VecFloat.Release(ref vector);
        }

        [TestMethod]
        public void SetAndRead() {
            var vector = VecFloat.Allocate(1024);

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

            VecFloat.Release(ref vector);
        }


        [TestMethod]
        public void Min() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            b.SetAll(5);

            var r = VecFloat.Allocate(1024);

            VecFloat.Min(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r.Get(i) != 2)
                    throw new Exception();
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }

        [TestMethod]
        public void Max() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            b.SetAll(5);

            var r = VecFloat.Allocate(1024);

            VecFloat.Max(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r.Get(i) != 5)
                    throw new Exception();
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }

        [TestMethod]
        public void Add() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            for (var i = 0; i < b.Count; ++i) {
                b[i] = i;
            }

            var r = VecFloat.Allocate(1024);

            VecFloat.Add(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r[i] != 2 + i)
                    throw new Exception();
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }


        [TestMethod]
        public void Subtract() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            for (var i = 0; i < b.Count; ++i) {
                b[i] = i;
            }

            var r = VecFloat.Allocate(1024);

            VecFloat.Subtract(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r[i] != 2 - i)
                    throw new Exception();
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }

        [TestMethod]
        public void Multiply() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            for (var i = 0; i < b.Count; ++i) {
                b[i] = i;
            }

            var r = VecFloat.Allocate(1024);

            VecFloat.Multiply(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                if (r[i] != 2 * i)
                    throw new Exception();
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }

        [TestMethod]
        public void Divide() {

            var a = VecFloat.Allocate(1024);
            a.SetAll(2);

            var b = VecFloat.Allocate(1024);
            for (var i = 0; i < b.Count; ++i) {
                b[i] = i;
            }

            var r = VecFloat.Allocate(1024);

            VecFloat.Divide(a, b, r);

            for (var i = 0; i < r.Count; ++i) {
                var av = 2.0f;
                var bv = (float)(i);
                var rv = av / bv;
                var d = r[i] - rv;
                if (Math.Abs(d) > 0.000001f)
                    throw new Exception("Index: "+i+" r:"+r[i]+" a:"+a[i]+" b:"+b[i]+" s:"+av+":"+bv+":"+rv+" d:"+d);
            }
            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }
    }
}