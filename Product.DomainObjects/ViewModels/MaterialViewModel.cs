using Product.DomainObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Product.DomainObjects.ViewModels
{
   public class MaterialViewModel
    {
        public MaterialModel MaterialModel { get; set; }

        public int MergeMaterialId { get; set; }

        public List<SelectListItem> MergeMaterialList { get; set; }


    }
}
