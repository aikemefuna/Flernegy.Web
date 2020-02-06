using Flenergy.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Flenergy.Web.ViewModels
{
    public class EstateVM
    {
        public ICollection<Estate> Estates { get; set; }
        public Estate Estate { get; set; }
    }
}
