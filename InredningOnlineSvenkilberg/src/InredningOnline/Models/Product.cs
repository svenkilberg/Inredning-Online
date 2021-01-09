using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InredningOnline
{
    public class Product
    {
        // This is the doamin model for the products.
        // The products are connected to projects by project id.
        // Every project that belongs to a specific projekt have the same project id.

        public int ProductId { get; set; }

        [Required(ErrorMessage = "Ange namn på produkten")]
        [Display(Name = "Produktnamn")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Ange antal")]        
        [Display(Name = "Antal")]
        [Range(1, int.MaxValue)]
        public int ProductNuberOfUnits { get; set; }

        [Required(ErrorMessage = "Ange enhet")]
        [Display(Name = "Enhet")]
        public string ProductUnit { get; set; }

        [Required(ErrorMessage = "Ange styckpris")]
        [Display(Name = "Styckpris")]        
        [Range(0, double.MaxValue)]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ProductUnitPrice { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double ProductTotalPrice { get; set; }

        [Required(ErrorMessage = "Ange leverantör")]
        [Display(Name = "Leverantör")]
        public string ProductSupplierName { get; set; }

        [Display(Name = "Länk för mer information")]
        public string ProductInfoLink { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
