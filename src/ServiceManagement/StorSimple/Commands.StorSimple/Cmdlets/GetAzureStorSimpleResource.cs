using System;
using System.Management.Automation;
using System.Collections.Generic;
using System.Linq;
using Microsoft.WindowsAzure.Commands.StorSimple.Properties;

namespace Microsoft.WindowsAzure.Commands.StorSimple.Cmdlets
{
    /// <summary>
    /// this commandlet returns all resources available in your subscription
    /// </summary>
    [Cmdlet(VerbsCommon.Get, "AzureStorSimpleResource"), OutputType(typeof(IEnumerable<ResourceCredentials>), typeof(ResourceCredentials))]
    public class GetAzureStorSimpleResource : StorSimpleCmdletBase
    {
        [Alias("Name")]
        [Parameter(Position = 0, Mandatory = false, ParameterSetName = StorSimpleCmdletParameterSet.IdentifyByName, HelpMessage = StorSimpleCmdletHelpMessage.HelpMessageResourceName)]
        [ValidateNotNullOrEmpty]
        public string ResourceName { get; set; }

        protected override void BeginProcessing()
        {
            //to prevent resource checking in StorSimpleCmdletbase.BeginProcessing()
            return;
        }

        public override void ExecuteCmdlet()
        {
            try
            {              
                var serviceList = StorSimpleClient.GetAllResources().Cast<ResourceCredentials>().ToList();
                if(serviceList == null 
                    || serviceList.Count() == 0)
                {
                    WriteVerbose(Resources.NoResourceFoundInSubscriptionMessage);
                    WriteObject(null);
                    return;
                }

                if(ParameterSetName == StorSimpleCmdletParameterSet.IdentifyByName)
                {
                    serviceList = serviceList.Where(x => x.ResourceName.Equals(ResourceName, System.StringComparison.InvariantCultureIgnoreCase)).Cast<ResourceCredentials>().ToList();
                    if (serviceList.Count() == 0)
                    {
                        WriteVerbose(String.Format(Resources.NoResourceFoundWithGivenNameInSubscriptionMessage, ResourceName));
                        WriteObject(null);
                        return;
                    }
                }
                this.WriteObject(serviceList, true);
                WriteVerbose(String.Format(Resources.ResourceGet_StatusMessage, serviceList.Count(),(serviceList.Count() > 1 ? "s" : String.Empty)));
            }
            catch (Exception exception)
            {
                this.HandleException(exception);
            }
        }
    }
}
