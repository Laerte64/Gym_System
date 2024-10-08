using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data
{
    [Table("tb_manager")]
    internal class ManagerData: UserData
    {
        public List<TimeSlotData> WorkDays { get; set; }
    }
}