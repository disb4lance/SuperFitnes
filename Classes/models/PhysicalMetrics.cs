using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    PhysicalMetrics(Физические показатели) :
    //PhysicalMetricsId: Уникальный идентификатор записи физических показателей.
    //Date: Дата записи физических показателей.
    //Weight: Вес пользователя на момент записи.
    //BodyMeasurements: Обхваты тела (например, грудь, талия, бедра).
    //Pulse: Пульс пользователя на момент записи.
    //UserId: Внешний ключ, связывающий запись с соответствующим пользователем.
    //User: Связь с пользователем, к которому относятся физические показатели.
    public class PhysicalMetrics
    {
        public int PhysicalMetricsId { get; set; }
        public DateTime Date { get; set; }
        public float Weight { get; set; }
        public float BodyMeasurements { get; set; }
        public int Pulse { get; set; }

        // Внешний ключ для пользователя
        public int UserId { get; set; }

        // Навигационное свойство для пользователя
        public virtual User User { get; set; }
    }
}
