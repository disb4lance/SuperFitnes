using Classes.models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    Exercise(Упражнение) :
    //IsnNode: Уникальный идентификатор упражнения.
    //Name: Название упражнения.
    //Type: Тип упражнения(силовое, кардио и т.д.).
    //TrainingId: Внешний ключ, связывающий упражнение с тренировкой, в которой оно используется.
    //Training: Связь с тренировкой, в которой используется упражнение.
    public class Exercise
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        // Внешний ключ для тренировки
        public Guid TrainingId { get; set; }

        // Навигационное свойство для тренировки
        public virtual Train Train{ get; set; }
    }
}
