using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// The supported types for an Encryption Protector
    /// </summary>
    public enum EncryptionProtectorType
    {
        AzureKeyVault,
        ServiceManaged
    };
}
