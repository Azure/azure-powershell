using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.WindowsAzure.Commands.Common.Storage
{
    public interface IStorageContextProvider
    {
        AzureStorageContext Context
        {
            get;
        }
    }
}
