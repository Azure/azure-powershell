using Azure.Analytics.Synapse.Artifacts.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Azure.Commands.Synapse.Models
{
    public class PSBigDataPoolReference
    {
        public PSBigDataPoolReference(BigDataPoolReference bigDataPoolReference)
        {
            this.Type = bigDataPoolReference?.Type;
            this.ReferenceName = bigDataPoolReference?.ReferenceName;
        }

        public string Type { get; set; }

        public string ReferenceName { get; set; }

        public BigDataPoolReference ToSdkObject()
        {
            if (this.ReferenceName == null)
            {
                return null;
            }
            else
            {
                return new BigDataPoolReference(this.ReferenceName)
                {
                    Type = this.Type
                };
            }
        }
    }
}
