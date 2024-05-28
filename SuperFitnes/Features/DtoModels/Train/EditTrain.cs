namespace SuperFitnes.Features.DtoModels.Train
{
    public class EditTrain
    {
        public Guid IsnNode { get; set; }
        public DateTime DateTime { get; set; }

        // Внешний ключ для пользователя
        public Guid UserId { get; set; }
    }
}
