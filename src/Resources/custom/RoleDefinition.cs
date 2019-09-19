using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview
{
    public partial class RoleDefinition
    {
        [Microsoft.Azure.PowerShell.Cmdlets.Resources.FormatTable(Index = 2)]
        public string[] Action
        {
            get
            {
                return this.Permission?.SelectMany(p => p.Action).ToArray();
            }
        }

        public string[] DataAction
        {
            get
            {
                return this.Permission?.SelectMany(p => p.DataAction).ToArray();
            }
        }

        public string[] NotAction
        {
            get
            {
                return this.Permission?.SelectMany(p => p.NotAction).ToArray();
            }
        }

        public string[] NotDataAction
        {
            get
            {
                return this.Permission?.SelectMany(p => p.NotDataAction).ToArray();
            }
        }
    }
}