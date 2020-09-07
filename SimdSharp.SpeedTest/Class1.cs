using System;
using System.Diagnostics;

namespace SimdSharp.SpeedTest {
    public class Class1 {
        static void Main(string[] args) {
            var watch = new Stopwatch();

            var allocSize = 100000;
            PreLoad(allocSize);

            watch.Reset();
            watch.Start();
            float simsum = 0;
            for (var i = 0; i < 1000; ++i)
                simsum += Simd(allocSize);
            watch.Stop();

            Console.WriteLine("SimSum: " + simsum);

            Console.WriteLine("SimdSharp: " + watch.ElapsedMilliseconds);


            watch.Reset();
            watch.Start();
            float loopsum = 0;
            for (var i = 0; i < 1000; ++i)
                loopsum+=Native(allocSize);
            watch.Stop();

            Console.WriteLine("LoopSum: " + loopsum);

            Console.WriteLine("Loop: " + watch.ElapsedMilliseconds);

            Console.ReadLine();
        }

        private static float Native(int allocSize) {
            var qa = new float[allocSize];
            var qb = new float[allocSize];
            var qr = new float[allocSize];

            for (var i = 0; i < allocSize; i++) {
                qa[i] = 2;
                qb[i] = 5;
            }


            for (var i = 0; i < allocSize; i++) {
                qr[i] = qa[i] + qb[i];
            }

            var result = 0f;

            for (var i = 0; i < allocSize; i++) {
                result += qr[i];
            }
            return result;
        }

        private static float Simd(int allocSize) {
            var a = VecFloat.Allocate(allocSize);
            a.SetAll(2);

            var b = VecFloat.Allocate(allocSize);
            b.SetAll(5);

            var r = VecFloat.Allocate(allocSize);

            VecFloat.Add(a, b, r);

            var result = VecFloat.Sum(r);

            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
            return result;
        }

        static void PreLoad(int allocSize) {
            var a = VecFloat.Allocate(allocSize);
            a.SetAll(2);

            var b = VecFloat.Allocate(allocSize);
            b.SetAll(5);

            var r = VecFloat.Allocate(allocSize);

            VecFloat.Add(a, b, r);

            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);
        }
    }
}
