using Microsoft.Azure.Management.Compute.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Compute.Extension.AzureDiskEncryption
{
    enum AzureDiskEncryptionMode
    {
        SinglePass,
        DualPass,
        None
    }
}
