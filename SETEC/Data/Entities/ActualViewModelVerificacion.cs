using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SETEC.Controllers;

namespace SETEC.Data.Entities
{
    public class ActualViewModelVerificacion
    {
       
        public List<SelectListItem> DropdownItems { get; set; }
       
    }
}