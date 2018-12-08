using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ZoologicoSite.Models
{
    public class ContinentesPaisesModel
    {
        public List<T_Pais> ListaPaises { get; set; }
        public List<SelectListItem> ListaContinentes { get; set; }
        public string nombreContinente { get; set; }
    }
}