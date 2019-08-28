using Microsoft.Azure.Commands.SqlVirtualMachine.Common;
using System.Collections;
using System.Management.Automation;
using static Microsoft.Azure.Commands.SqlVirtualMachine.Common.ParameterSet;

namespace Microsoft.Azure.Commands.SqlVirtualMachine.SqlVirtualMachine.Cmdlet
{
    public abstract class AzureSqlVMUpsertCmdletBase : AzureSqlVMCmdletBase
    {
        /// <summary>
        /// Offer of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList, 
            HelpMessage = HelpMessages.OfferSqlVM)]
        [OfferCompleter]
        public virtual string Offer { get; set; }

        /// <summary>
        /// Sku of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SkuSqlVM)]
        public virtual Sku? Sku { get; set; }

        /// <summary>
        /// SqlManagementType of the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.SqlManagementTypeSqlVM)]
        public virtual string SqlManagementType { get; set; } = "LightWeight";

        /// <summary>
        /// Tags will be associated to the sql virtual machine
        /// </summary>
        [Parameter(Mandatory = false,
            ParameterSetName = NameParameterList,
            HelpMessage = HelpMessages.TagsSqlVM)]
        public virtual Hashtable Tags { get; set; }
    }
}
