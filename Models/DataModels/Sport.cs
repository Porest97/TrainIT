using System.ComponentModel.DataAnnotations;

namespace TrainIT.Models.DataModels
{
    public class Sport
    {
        public int Id { get; set; }

        [Display(Name ="Sport")]
        public string SportName { get; set; }
    }
}