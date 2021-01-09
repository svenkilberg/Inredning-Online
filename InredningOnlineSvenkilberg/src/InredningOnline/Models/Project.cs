using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{ 
    public class Project
    {
        public int ProjectId { get; set; }

        [Required(ErrorMessage = "Ange namn på projektet")]
        [Display(Name = "Projekjtnamn")]
        public string ProjectName { get; set; }
        public string ProjectOwner { get; set; } // The username that created the project. Used for filtering in the view.

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public double ProjectTotalPrice { get; set; }
            
    }
}
