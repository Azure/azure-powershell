using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSSubResource
    {
        public PSSubResource(string id, string name, string type, string etag)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Etag = etag;
        }

        public PSSubResource() { }

        public string Id { get; set; }
        
        public string Name { get; set; }
        
        public string Type { get; set; }
        
        public string Etag { get; set; }
    }
}
