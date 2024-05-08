using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes.models
{
    //    User(Пользователь) :
    //UserId: Уникальный идентификатор пользователя.
    //Username: Логин пользователя.
    //Password: Пароль пользователя (лучше всего хранить в зашифрованном виде).
    //FirstName: Имя пользователя.
    //LastName: Фамилия пользователя.
    //Email: Электронная почта пользователя.
    //Role: Роль пользователя в системе (например, спортсмен или тренер).
    //TrainingPrograms: Связь с коллекцией тренировочных программ, принадлежащих пользователю.
    //PhysicalMetrics: Связь с коллекцией физических показателей пользователя.
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Навигационное свойство для тренировочных программ пользователя
        public virtual ICollection<TrainingProgram> TrainingPrograms { get; set; }

        // Навигационное свойство для физических показателей пользователя
        public virtual ICollection<PhysicalMetrics> PhysicalMetrics { get; set; }
    }
}
