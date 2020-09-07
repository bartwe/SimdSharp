using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace SimdSharp.SpeedTest {
    class Test2 {
        static void Main(string[] args) {
            Stopwatch watch = new Stopwatch();
            int allocSize = 10000000;
            Random rnd = new Random();

            float[] setA = new float[allocSize];
            float[] setB = new float[allocSize];

            var a = VecFloat.Allocate(allocSize);
            var b = VecFloat.Allocate(allocSize);

            for (int i = 0; i < allocSize; i++) {
                setA[i] = rnd.Next(0, 10);
                setB[i] = rnd.Next(0, 10);
            }

            a.SetRange(0, setA, 0, allocSize);
            b.SetRange(0, setB, 0, allocSize);

            //a.SetAll(2);


            // b.SetAll(5);

            var r = VecFloat.Allocate(allocSize);
            watch.Start();
            VecFloat.Add(a, b, r);
            watch.Stop();

            VecFloat.Release(ref a);
            VecFloat.Release(ref b);
            VecFloat.Release(ref r);


            Console.WriteLine("SimdSharp: " + watch.ElapsedMilliseconds);



            //watch.Restart();


            float[] qa = new float[allocSize];
            float[] qb = new float[allocSize];
            float[] qr = new float[allocSize];

            for (int i = 0; i < allocSize; i++) {
                qa[i] = rnd.Next(0, 10);
                qb[i] = rnd.Next(0, 10);
            }

            watch.Reset();
            watch.Start();
            for (int i = 0; i < allocSize; i++) {
                qr[i] = qa[i] + qb[i];
            }
            watch.Stop();

            Console.WriteLine("Loop: " + watch.ElapsedMilliseconds);


            //not a fair test, its only using half its contents, wasting 50% cache and its not sped up in .net framework with intrinsics anyways
            Vector2[] va = new Vector2[allocSize];
            Vector2[] vb = new Vector2[allocSize];
            Vector2[] vr = new Vector2[allocSize];

            for (int i = 0; i < allocSize; i++) {
                va[i] = new Vector2(rnd.Next(0, 10), rnd.Next(0, 10));
                vb[i] = new Vector2(rnd.Next(0, 10), rnd.Next(0, 10));
            }

            watch.Reset();
            watch.Start();
            for (int i = 0; i < allocSize; i++) {
                vr[i].X = va[i].X + vb[i].X;
            }

            watch.Stop();

            Console.WriteLine("Numerics: " + watch.ElapsedMilliseconds);

            Console.ReadLine();
        }

    }
}
