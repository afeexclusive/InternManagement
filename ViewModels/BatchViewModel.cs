using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static EmployeeManagment.models.Selector;

namespace EmployeeManagment.ViewModels
{
    public class BatchViewModel
    {

        public int AcadaProgramId { get; set; }

        [Display(Name ="Choose Batch")]
        public Batch Name { get; set; }
        public string Supervisor { get; set; }

        [Display(Name = "Batch Year")]
        public BatchYear Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
    }
}
