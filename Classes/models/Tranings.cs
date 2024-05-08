using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    Training(Тренировка) :
    //TrainingId: Уникальный идентификатор тренировки.
    //DateTime: Дата и время проведения тренировки.
    //Description: Описание тренировки.
    //TrainingProgramId: Внешний ключ, связывающий тренировку с тренировочной программой.
    //TrainingProgram: Связь с тренировочной программой, к которой относится тренировка.
    //Exercises: Связь с коллекцией упражнений, входящих в тренировку.
    public class Training
    {
        public int TrainingId { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }

        // Внешний ключ для тренировочной программы
        public int TrainingProgramId { get; set; }

        // Навигационное свойство для тренировочной программы
        public virtual TrainingProgram TrainingProgram { get; set; }

        // Навигационное свойство для упражнений в тренировке
        public virtual ICollection<Exercise> Exercises { get; set; }
    }
}
