
 /*O alarmă poate fi setată să se declanșeze la o anumită oră în una sau în mai multe zile din săptămână.
De exemplu, se poate configura ca alarma să se declanșeze la ora 6 de luni până vineri și să se declanșeze la ora 8 sâmbătă și duminică.
Scrie o funcție care decide pe baza acestor setări dacă trebuie declanșată alarma într-o anumită zi la o anumită oră.*/

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Alarm
{
    [TestClass]
    public class AlarmTests
    {
        [TestMethod]
        public void AlarmTest()
        {
            var alarms = new Alarm[] {
                new Alarm(DaysOfTheWeak.Monday | DaysOfTheWeak.Tuesday | DaysOfTheWeak.Wednesday | DaysOfTheWeak.Thursday | DaysOfTheWeak.Friday, 6),
                new Alarm(DaysOfTheWeak.Saturday | DaysOfTheWeak.Sunday, 8) };
            Assert.AreEqual(true, CheckAlarmStatus(alarms, DaysOfTheWeak.Monday | DaysOfTheWeak.Tuesday | DaysOfTheWeak.Wednesday | DaysOfTheWeak.Thursday | DaysOfTheWeak.Friday, 6));
            Assert.AreEqual(true, CheckAlarmStatus(alarms, DaysOfTheWeak.Saturday | DaysOfTheWeak.Sunday, 8));
            Assert.AreEqual(false, CheckAlarmStatus(alarms, DaysOfTheWeak.Monday | DaysOfTheWeak.Tuesday | DaysOfTheWeak.Wednesday | DaysOfTheWeak.Thursday | DaysOfTheWeak.Friday, 7));
            Assert.AreEqual(false, CheckAlarmStatus(alarms,DaysOfTheWeak.Saturday | DaysOfTheWeak.Sunday, 7));

        }
        [Flags]
        public enum DaysOfTheWeak
        {
            Monday = 1,
            Tuesday = 2,
            Wednesday = 4,
            Thursday = 8,
            Friday = 16,
            Saturday = 32,
            Sunday = 64
        }

        struct Alarm
        {
            public DaysOfTheWeak day;
            public int hour;
           

            public Alarm(DaysOfTheWeak day, int hour)
            {
                this.day = day;
                this.hour = hour;
                
            }
        }
       

        static bool CheckAlarmStatus(Alarm[] alarms, DaysOfTheWeak day, int hour)
        {
            bool status = false;
            for (int i = 0; i < alarms.Length; i++)
            {
                if ((alarms[i].day & day) != 0 && (alarms[i].hour == hour) )
                    return true;
            }
            return status;
        }
    }
}