
/*
Ți se dă o listă de tronsoane verticale și orizontale consecutive de dimensiuni fixe.
Scrie o funcție care verifică dacă tronsoanele se intersectează.Dacă se intersectează întoarce primul punct de intersecție.
Notă: având în vedere că tronsoanele sunt de dimensiuni fixe, alege cel mai simplu mod de a le reprezenta, de ex: ca și o succesiune de direcții stânga, dreapta, sus, jos.*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FirstPointofIntersection
{
    [TestClass]
    public class FirstPointofIntersection
    {
        [TestMethod]
        public void IntersectionPoint1()
        {
            Assert.AreEqual(new Point(9, 8), FirstIntersection(new Point(9, 7), new Directions[] {

                Directions.up

               }));
        }
        [TestMethod]
        public void IntersectionPoint2()
        {
            Assert.AreEqual(new Point(21, 5), FirstIntersection(new Point(20, 5), new Directions[] {

                Directions.right

                }));
        }
        [TestMethod]
        public void IntersectionPoint3()
        {
            Assert.AreEqual(new Point(6, 8), FirstIntersection(new Point(4, 8), new Directions[] {
                Directions.right,
                Directions.right

                }));
        }

      

        public enum Directions
        {
            up,
            down,
            right,
            left
        }

        public struct Point
        {
            public int x;
            public int y;

            public Point(int x, int y)
            {
                this.x = x;
                this.y = y;
            }
        }

        static Point FirstIntersection(Point point, Directions[] directions)
        {
            Point[] savedPoints = new Point[directions.Length];

            for (int i = 0; i < directions.Length; i++)
            {
                switch (directions[i])
                {
                    case Directions.up:
                        point.y += 1;
                        break;
                    case Directions.down:
                        point.y -= 1;
                        break;
                    case Directions.right:
                        point.x += 1;
                        break;
                    case Directions.left:
                        point.x -= 1;
                        break;
                }
                savedPoints[i] = point;
                if (CheckPoint(point, savedPoints))
                    return point;
            }
            return point;
        }

        static bool CheckPoint(Point point, Point[] savedPoints)
        {
            int counter = 0;
            foreach (var x in savedPoints)
            {
                if (point.x == x.x && point.y == x.y)
                    counter++;
            }
            return (counter > 1);
        }
    }
}