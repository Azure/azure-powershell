using Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Sql.TransparentDataEncryption.Cmdlet
{
    /// <summary>
    /// Defines the Revalidate-AzSqlInstanceTransparentDataEncryptionProtector cmdlet
    /// </summary>
    [Cmdlet("Invoke", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "SqlInstanceTransparentDataEncryptionProtectorRevalidation", SupportsShouldProcess = true, DefaultParameterSetName = DefaultParameterSet)]
    [OutputType(typeof(AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel))]
    public class InvokeAzureRmSqlManagedInstanceTransparentDataEncryptionProtectorRevalidation : AzureSqlRmManagedInstanceTransparentDataEncryptionProtectorBase
    {
        /// <summary>
        /// Gets or sets whether or not to run this cmdlet in the background as a job
        /// </summary>
        [Parameter(Mandatory = false, HelpMessage = "Run cmdlet in the background")]
        public SwitchParameter AsJob { get; set; }

        /// <summary>
        /// Get the entities from the service
        /// </summary>
        /// <returns>The list of entities</returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> GetEntity()
        {
            return new List<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel>() {
                ModelAdapter.GetAzureRmSqlManagedInstanceTransparentDataEncryptionProtector(this.ResourceGroupName, this.InstanceName)
            };
        }

        /// <summary>
        /// Sends the TDE protector revalidate request to the service
        /// </summary>
        /// <param name="entity">The encryption protector entity to revalidate</param>
        /// <returns></returns>
        protected override IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> PersistChanges(IEnumerable<AzureRmSqlManagedInstanceTransparentDataEncryptionProtectorModel> entity)
        {
            ModelAdapter.RevalidateAzureRmSqlManagedInstanceTransparentDataEncryptionProtector(entity.First().ResourceGroupName, entity.First().ManagedInstanceName);
            return entity;
        }
    }
}
