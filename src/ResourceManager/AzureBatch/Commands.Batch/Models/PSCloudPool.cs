using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Batch.Models
{
    public partial class PSCloudPool
    {
        public IList<PSResizeError> ResizeErrors => this.resizeError == null ? null : new List<PSResizeError> {this.resizeError};
    }
}
