using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple.Models;
using Microsoft.WindowsAzure.Commands.CloudService.Development;

namespace Microsoft.WindowsAzure.Commands.StorSimple
{
    public partial class PSStorSimpleClient
    {
        public GetResourceEncryptionKeyResponse GetResourceEncryptionKey()
        {
            return this.GetStorSimpleClient().ResourceEncryptionKeys.Get(GetCustomRequestHeaders());
        }
    }
}
