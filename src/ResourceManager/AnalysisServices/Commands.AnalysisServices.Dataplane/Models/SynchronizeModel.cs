using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Microsoft.Azure.Commands.AnalysisServices.Dataplane
{
    [DataContract]
    public class SynchronizeModel
    {
        [DataMember(IsRequired = true, Name = "databases")]
        public IEnumerable<string> Databases { get; set; }
    }
}

