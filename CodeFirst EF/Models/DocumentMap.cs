using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_EF.Models
{
    class DocumentMap : ClassMap<Document>
    {

        public DocumentMap()
        {
            Map(m => m.Title).Name("Title");
            Map(m => m.Text).Name("Text");
        }

    }
}
