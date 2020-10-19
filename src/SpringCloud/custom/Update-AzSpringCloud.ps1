
# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the "License");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an "AS IS" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Operation to update an exiting Service.
.Description
Operation to update an exiting Service.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IServiceResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

GITPROPERTYREPOSITORY <IGitPatternRepository[]>: Repositories of git.
  Name <String>: Name of the repository
  Uri <String>: URI of the repository
  [HostKey <String>]: Public sshKey of git repository.
  [HostKeyAlgorithm <String>]: SshKey algorithm of git repository.
  [Label <String>]: Label of the repository
  [Password <String>]: Password of git repository basic auth.
  [Pattern <String[]>]: Collection of pattern of the repository
  [PrivateKey <String>]: Private sshKey algorithm of git repository.
  [SearchPath <String[]>]: Searching path of the repository
  [StrictHostKeyChecking <Boolean?>]: Strict host key checking or not.
  [Username <String>]: Username of git repository basic auth.

INPUTOBJECT <ISpringCloudIdentity>: Identity Parameter
  [AppName <String>]: The name of the App resource.
  [BindingName <String>]: The name of the Binding resource.
  [CertificateName <String>]: The name of the certificate resource.
  [DeploymentName <String>]: The name of the Deployment resource.
  [DomainName <String>]: The name of the custom domain resource.
  [Id <String>]: Resource identity path
  [Location <String>]: the region
  [ResourceGroupName <String>]: The name of the resource group that contains the resource. You can obtain this value from the Azure Resource Manager API or the portal.
  [ServiceName <String>]: The name of the Service resource.
  [SubscriptionId <String>]: Gets subscription ID which uniquely identify the Microsoft Azure subscription. The subscription ID forms part of the URI for every service call.
.Link
https://docs.microsoft.com/en-us/powershell/module/az.springcloud/update-azspringcloud
#>
function Update-AzSpringCloud {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IServiceResource])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('ServiceName')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the Service resource.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Gets subscription ID which uniquely identify the Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${SubscriptionId},

    [Parameter(ParameterSetName='UpdateViaIdentityExpanded', Mandatory, ValueFromPipeline)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity]
    # Identity Parameter
    # To construct, see NOTES section for INPUTOBJECT properties and create a hash table.
    ${InputObject},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # URI of the repository
    ${GitPropertyUri},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # The GEO location of the resource.
    ${Location},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Name of the Sku
    ${SkuName},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Tier of the Sku
    ${SkuTier},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.ITrackedResourceTags]))]
    [System.Collections.Hashtable]
    # Tags of the service which is a list of key value pairs that describe the resource.
    ${Tag},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Target application insight instrumentation key
    ${TraceAppInsightInstrumentationKey},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.Management.Automation.SwitchParameter]
    # Indicates whether enable the tracing functionality
    ${TraceEnabled},

    [Parameter()]
    [Alias('AzureRMContext', 'AzureCredential')]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Azure')]
    [System.Management.Automation.PSObject]
    # The credentials, account, tenant, and subscription used for communication with Azure.
    ${DefaultProfile},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command as a job
    ${AsJob},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Wait for .NET debugger to attach
    ${Break},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be appended to the front of the pipeline
    ${HttpPipelineAppend},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.SendAsyncStep[]]
    # SendAsync Pipeline Steps to be prepended to the front of the pipeline
    ${HttpPipelinePrepend},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Run the command asynchronously
    ${NoWait},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Uri]
    # The URI for the proxy server to use
    ${Proxy},

    [Parameter(DontShow)]
    [ValidateNotNull()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Management.Automation.PSCredential]
    # Credentials for a proxy server to use for the remote call
    ${ProxyCredential},

    [Parameter(DontShow)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Runtime')]
    [System.Management.Automation.SwitchParameter]
    # Use the default credentials for the proxy
    ${ProxyUseDefaultCredentials}
)

    process {
        Az.SpringCloud.internal\Update-AzSpringCloudService @PSBoundParameters
    }
}
