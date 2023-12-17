using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entites.DataTransferObject
{
    public class AuthorForCreateDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
