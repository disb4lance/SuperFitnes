using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    TrainingProgram(Тренировочная программа) :
    //TrainingProgramId: Уникальный идентификатор тренировочной программы.
    //Name: Название тренировочной программы.
    //Description: Описание программы.
    //Duration: Продолжительность программы в днях, неделях или месяцах.
    //Goals: Цели, которые пользователь хочет достичь с помощью этой программы.
    //UserId: Внешний ключ, связывающий программу с пользователем, создавшим её.
    //User: Связь с пользователем, создавшим программу.
    //Trainings: Связь с коллекцией тренировок, входящих в программу.
    public class TrainingProgram
    {
        public int TrainingProgramId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Duration { get; set; }
        public string Goals { get; set; }

        // Внешний ключ для пользователя, которому принадлежит программа
        public int UserId { get; set; }

        // Навигационное свойство для пользователя
        public virtual User User { get; set; }

        // Навигационное свойство для тренировок
        public virtual ICollection<Training> Trainings { get; set; }
    }
}
