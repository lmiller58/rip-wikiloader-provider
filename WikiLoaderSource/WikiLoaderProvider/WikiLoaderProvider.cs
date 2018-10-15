using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml;
using kCura.IntegrationPoints.Contracts.Models;
using WikiLoaderProvider;

namespace Provider
{
    /// <summary>
    /// This code is a sample fully operational Integration Point Provider
    /// for demonstration purposes only
    /// </summary>
    [kCura.IntegrationPoints.Contracts.DataSourceProvider(GlobalConstants.WIKILOADER_GUID)]
    public class WikiLoaderProvider : kCura.IntegrationPoints.Contracts.Provider.IDataSourceProvider
    {
        public IEnumerable<FieldEntry> GetFields(DataSourceProviderConfiguration providerConfiguration)
        {
            string fileLocation = providerConfiguration.Configuration;

            // Because the wikipedia XML doesn't have a column key, I'vehard-coded the field names here.
            var fieldEntries = new List<FieldEntry>()
            {
                new FieldEntry { DisplayName = "Title", FieldIdentifier = "title", IsIdentifier = true },
                new FieldEntry { DisplayName = "URL", FieldIdentifier = "url", IsIdentifier = false },
                new FieldEntry { DisplayName = "Abstract", FieldIdentifier = "abstract", IsIdentifier = false }
            };

            return fieldEntries;
        }

        public IDataReader GetBatchableIds(FieldEntry identifier, DataSourceProviderConfiguration providerConfiguration)
        {
            string fileLocation = providerConfiguration.Configuration;

            DataTable dt = new DataTable();
            dt.Columns.Add(identifier.FieldIdentifier);

            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);
            XmlNodeList nodes = doc.DocumentElement.SelectNodes(string.Format("/feed/doc/{0}", identifier.FieldIdentifier));

            foreach (XmlNode node in nodes)
            {
                var row = dt.NewRow();
                row[identifier.FieldIdentifier] = node.InnerText;
                dt.Rows.Add(row);
            }
            return dt.CreateDataReader();
        }

        public IDataReader GetData(IEnumerable<FieldEntry> fields, IEnumerable<string> entryIds, DataSourceProviderConfiguration providerConfiguration)
        {
            string fileLocation = providerConfiguration.Configuration;
            List<string> fieldList = fields.Select(f => f.FieldIdentifier).ToList();
            string keyFieldName = fields.FirstOrDefault(f => f.IsIdentifier).FieldIdentifier;
            return new XMLDataReader(entryIds, fieldList, keyFieldName, fileLocation);
        }
    }
}