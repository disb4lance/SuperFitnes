using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    Training(Тренировка) :
    //IsnNode: Уникальный идентификатор тренировки.
    //DateTime: Дата и время проведения тренировки.
    //Exercises: Связь с коллекцией упражнений, входящих в тренировку.
    public class Train
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }
        public DateTime DateTime { get; set; }

        // Внешний ключ для пользователя
        public Guid UserId { get; set; }

    }
}
