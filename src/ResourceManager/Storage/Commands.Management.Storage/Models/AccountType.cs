using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.Storage.Models
{
    public enum AccountType
    {
        StandardLRS = 0,
        StandardZRS = 1,
        StandardGRS = 2,
        StandardRAGRS = 3,
        PremiumLRS = 4
    }
}
