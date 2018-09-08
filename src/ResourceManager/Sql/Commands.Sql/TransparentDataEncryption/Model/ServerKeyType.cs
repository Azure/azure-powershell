using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model
{
    /// <summary>
    /// Enum representing the allowed managed instance Key types
    /// </summary>
    public enum ServerKeyType
    {
        AzureKeyVault,
        ServiceManaged
    }
}
