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
    //Password: Пароль пользователя (лучше всего хранить в зашифрованном виде).
    //FirstName: Имя пользователя.
    //LastName: Фамилия пользователя.
    
    //PhysicalMetrics: Связь с коллекцией физических показателей пользователя.
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid IsnNode { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]

        public string Password {  get; set; }

        //[EmailAddress]
    }
}
