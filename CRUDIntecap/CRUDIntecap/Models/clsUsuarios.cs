using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDIntecap.Models
{
    public class clsUsuarios
    {

        public int IdUusuario { get; set; }
        [System.ComponentModel.DataAnnotations.Display(Name = "Name")]
        public string Password { get; set; }
    }
}