using System.ComponentModel.DataAnnotations;

namespace SuperFitnes.Features.DtoModels.PhysicalMetrics
{
    public class EditPhysicalMetrics
    {
        public Guid IsnNode { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public float Weight { get; set; }
        [Required]
        public float BodyMeasurements { get; set; }
        public Guid UserId { get; set; }
    }
}
