/*Ciclometrul
Un ciclometru e un mecanism simplu care numără rotațiile unei roți de bicicletă.
În urma unei curse ai datele înregistrate de ciclometrele bicicliștilor participanți.
Ciclometrul fiecărui participant a înregistrat numărul de rotații făcute în fiecare secundă.
Dacă cunoști pentru fiecare bicicletă diametrul roților:
Calculează distanța totală parcursă de toți bicicliștii
Găsește secunda și numele biciclistului care a atins viteza maximă
Găsește biciclistul care a avut cea mai bună viteză medie*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cyclometer
{
    [TestClass]
    public class CyclistsTest
    {
        [TestMethod]
        public void TotalDistanceTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Ion", new int[] { 1, 2, 2, 3 }, 30),
                          new Cyclist("Gheorghe", new int[] { 1, 2, 3, 4 }, 24),
                          new Cyclist("Vasile", new int[] { 1, 2, 2, 4 }, 23)
                          };
            Assert.AreEqual(2158.3, TotalDistance(cyclists) , 1e-1);
        }
        [TestMethod]
        public void NameAndSecondTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Ion", new int[] { 1, 2, 2, 3 }, 30),
                          new Cyclist("Gheorghe", new int[] { 1, 2, 3, 4 }, 24),
                          new Cyclist("Vasile", new int[] { 1, 2, 2, 4 }, 23)
                          };
            int second = 4;
            Assert.AreEqual("Gheorghe", SecondAndName(cyclists, out second));
        }
        [TestMethod]
        public void BestAverageTest()
        {
            var cyclists = new Cyclist[] { new Cyclist ("Ion", new int[] { 1, 2, 2, 3 }, 30),
                          new Cyclist("Gheorghe", new int[] { 1, 2, 3, 4 }, 24),
                          new Cyclist("Vasile", new int[] { 1, 2, 2, 4 }, 23)
                          };
            Assert.AreEqual("Ion", CyclistWithBestAverageSpeed(cyclists));
        }
        struct Cyclist
        {
            public string name;
            public int[] records;
            public int wheelDiameter;

            public Cyclist(string name, int[] records, int wheelDiameter)
            {
                this.name = name;
                this.records = records;
                this.wheelDiameter = wheelDiameter;
            }
        }

        static double DistancePerSecond(int wheelDiameter, int records)
        {
            return Math.PI * wheelDiameter * records;

        }

        static double TotalDistanceForACyclist(Cyclist cyclist)
        {
            double distance = 0;
            for (int i = 0; i < cyclist.records.Length; i++)
                distance += DistancePerSecond(cyclist.wheelDiameter, cyclist.records[i]);
            return distance;
        }
        static double TotalDistance(Cyclist[] cyclists)
        {
            double totalDistance = 0;
            for (int i = 0; i < cyclists.Length; i++)
                totalDistance += TotalDistanceForACyclist(cyclists[i]);
            return totalDistance;

        }

        static int SecondOfMaxSpeed(Cyclist cyclist)
        {
            int second = 0;
            for (int i = 0; i < cyclist.records.Length; i++)
                if (cyclist.records[i] > second)
                    second = i + 1;
            return second;
        }

        static string SecondAndName(Cyclist[] cyclists, out int second)
        {
            double maxSpeed = 0;
            second = 0;
            int sec;
            double speed;
            string name = null;
            for (int i = 0; i < cyclists.Length; i++)
            {
                sec = SecondOfMaxSpeed(cyclists[i]) - 1;
                speed = DistancePerSecond(cyclists[i].wheelDiameter, cyclists[i].records[sec]);
                if (speed > maxSpeed)
                {
                    maxSpeed = speed;
                    second = sec;
                    name = cyclists[i].name;
                }
            }
            return name;
        }

        static string CyclistWithBestAverageSpeed(Cyclist[] cyclists)
        {
            string bestCyclist = null;
            double bestAverageDistance = 0;
            for (int i = 0; i < cyclists.Length; i++)
            {
                int time = cyclists[i].records.Length;
                double currentAverageDistance = TotalDistanceForACyclist(cyclists[i]) / time;
                if (currentAverageDistance > bestAverageDistance)
                {
                    bestAverageDistance = currentAverageDistance;
                    bestCyclist = cyclists[i].name;
                }
            }
            return bestCyclist;
        }

    }
}
