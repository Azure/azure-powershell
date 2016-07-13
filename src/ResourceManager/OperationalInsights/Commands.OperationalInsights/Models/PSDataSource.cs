using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.OperationalInsights.Models;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSDataSourcePropertiesBase { }

    public class PSDataSource
    {
        public string Name { get; set; }

        public string ResourceId { get; set; }

        public string ResourceGroupName { get; set; }

        public string WorkspaceName { get; set; }

        public string Kind { get; set; }

        public PSDataSourcePropertiesBase Properties { get; set; }

        public PSDataSource()
        {
        }

        public PSDataSource(DataSource storageInsight, string resourceGroupName, string workspaceName)
        {
            if (storageInsight == null)
            {
                throw new ArgumentNullException("storageInsight");
            }

            this.ResourceGroupName = resourceGroupName;
            this.WorkspaceName = workspaceName;
            this.Name = storageInsight.Name;
            this.ResourceId = storageInsight.Id;
            this.Kind = storageInsight.Kind;

        }
    }
}
