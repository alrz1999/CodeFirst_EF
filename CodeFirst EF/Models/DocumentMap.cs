using CsvHelper.Configuration;

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
