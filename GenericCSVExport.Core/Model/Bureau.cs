using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericCSVExport.Core.Model
{
    public class Bureau
    {
        public Bureau(int idBureau, string name, int idDepartment)
        {
            IdBureau = idBureau;
            Name = name;
            IdDepartment = idDepartment;
        }


        public int IdBureau { get; }

        public string Name { get; }

        public int IdDepartment { get; }
    }
}
