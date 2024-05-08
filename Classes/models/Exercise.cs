using Classes.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    Exercise(Упражнение) :
    //ExerciseId: Уникальный идентификатор упражнения.
    //Name: Название упражнения.
    //Description: Описание упражнения (техника выполнения и т.д.).
    //Type: Тип упражнения(силовое, кардио и т.д.).
    //TrainingId: Внешний ключ, связывающий упражнение с тренировкой, в которой оно используется.
    //Training: Связь с тренировкой, в которой используется упражнение.
    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }

        // Внешний ключ для тренировки
        public int TrainingId { get; set; }

        // Навигационное свойство для тренировки
        public virtual Training Training { get; set; }
    }
}
