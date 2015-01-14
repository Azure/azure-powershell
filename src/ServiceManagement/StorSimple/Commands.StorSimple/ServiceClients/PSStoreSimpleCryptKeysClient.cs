using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Management.StorSimple;
using Microsoft.WindowsAzure.Management.StorSimple.Models;

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
