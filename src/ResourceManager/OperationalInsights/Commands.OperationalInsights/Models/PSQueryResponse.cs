using Microsoft.Azure.OperationalInsights.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.OperationalInsights.Models
{
    public class PSQueryResponse
    {
        // Private constructor so no one else can make one
        private PSQueryResponse() {}

        internal static PSQueryResponse Create(QueryResults response)
        {
            var psResponse = new PSQueryResponse()
            {
                Results = GetResultEnumerable(response.Results),
                Render = response.Render,
                Statistics = response.Statistics,
            };

            return psResponse;
        }

        public IEnumerable<PSObject> Results { get; protected set; }
        public IDictionary<string, string> Render { get; protected set; }
        public IDictionary<string, object> Statistics { get; protected set; }

        private static IEnumerable<PSObject> GetResultEnumerable(IEnumerable<IDictionary<string, string>> rows)
        {
            foreach (var row in rows)
            {
                var psObject = new PSObject();
                foreach (var cell in row)
                {
                    psObject.Properties.Add(new PSNoteProperty(cell.Key, cell.Value));
                }
                yield return psObject;
            }
        }
    }
}
