using Microsoft.Azure.Management.SiteRecovery.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Threading.Tasks;

namespace Microsoft.Azure.Commands.SiteRecovery
{
    /// <summary>
    /// Retrieves Azure Site Recovery storage classification.
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureRmSiteRecoveryStorageClassificationMapping", DefaultParameterSetName = ASRParameterSets.Default)]
    [OutputType(typeof(IEnumerable<ASRStorageClassificationMapping>))]
    public class GetAzureSiteRecoveryStorageClassificationMapping : SiteRecoveryCmdletBase
    {
        #region Parameters
        /// <summary>
        /// Gets or sets name of classification.
        /// </summary>
        [Parameter(ParameterSetName = ASRParameterSets.ByName, Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }
        #endregion

        /// <summary>
        /// ProcessRecord of the command.
        /// </summary>
        public override void ExecuteSiteRecoveryCmdlet()
        {
            base.ExecuteSiteRecoveryCmdlet();

            List<StorageClassificationMapping> mappings = new List<StorageClassificationMapping>();
            Task mappingTask =
                RecoveryServicesClient.EnumerateStorageClassificationMappingsAsync((entities) =>
                {
                    mappings.AddRange(entities);
                });

            Task.WaitAll(mappingTask);

            switch (this.ParameterSetName)
            {
                case ASRParameterSets.ByName:
                    mappings = mappings.Where(item =>
                        item.Name.Equals(
                            this.Name,
                            StringComparison.InvariantCultureIgnoreCase))
                        .ToList();
                    break;
            }

            var psObject = mappings.ConvertAll(item =>
            {
                return new ASRStorageClassificationMapping()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PrimaryClassificationId = item.GetPrimaryStorageClassificationId(),
                    RecoveryClassificationId = item.Properties.TargetStorageClassificationId
                };
            });

            base.WriteObject(psObject, true);
        }
    }
}
