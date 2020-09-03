
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
Operation to update an exiting Deployment.
.Description
Operation to update an exiting Deployment.
.Example
PS C:\> Update-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default -SourceRelativePath resources/4ea5ee68fea05586106890ded5733820bb77d919cda27bc4b8139b7cd33b8889-2020080815-6986fdbd-59f6-42b8-8d1f-a75d403cbcde
Active                               : True
AppName                              : gateway
CreatedTime                          :
DeploymentSettingCpu                 : 1
DeploymentSettingEnvironmentVariable : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettingsEnvironmentVariables
DeploymentSettingInstanceCount       : 1
DeploymentSettingJvmOption           :
DeploymentSettingMemoryInGb          : 1
DeploymentSettingRuntimeVersion      : Java_8
Id                                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/spring-cloud-rg/providers/Microsoft.AppPlatform/Spring/spring-cloud-service/apps/gateway/deployments/default
Instance                             : {gateway-default-7-fb79b6b5d-kvmpz}
Name                                 : default
ProvisioningState                    : Succeeded
SourceArtifactSelector               :
SourceRelativePath                   : resources/4ea5ee68fea05586106890ded5733820bb77d919cda27bc4b8139b7cd33b8889-2020080815-6986fdbd-59f6-42b8-8d1f-a75d403cbcde
SourceType                           : Jar
SourceVersion                        :
Status                               : Running
Type                                 : Microsoft.AppPlatform/Spring/apps/deployments
DeploymentSetting                    : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings
Property                             : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentResourceProperties
Source                               : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.UserSourceInfo
.Example
PS C:\> Get-AzSpringCloudAppDeployment -ResourceGroupName spring-cloud-rg -ServiceName spring-cloud-service -AppName gateway -DeploymentName default | Update-AzSpringCloudAppDeployment -SourceRelativePath resources/4ea5ee68fea05586106890ded5733820bb77d919cda27bc4b8139b7cd33b8889-2020080815-6986fdbd-59f6-42b8-8d1f-a75d403cbcde
Active                               : True
AppName                              : gateway
CreatedTime                          :
DeploymentSettingCpu                 : 1
DeploymentSettingEnvironmentVariable : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettingsEnvironmentVariables
DeploymentSettingInstanceCount       : 1
DeploymentSettingJvmOption           :
DeploymentSettingMemoryInGb          : 1
DeploymentSettingRuntimeVersion      : Java_8
Id                                   : /subscriptions/xxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxx/resourceGroups/spring-cloud-rg/providers/Microsoft.AppPlatform/Spring/spring-cloud-service/apps/gateway/deployments/default
Instance                             : {gateway-default-7-fb79b6b5d-kvmpz}
Name                                 : default
ProvisioningState                    : Succeeded
SourceArtifactSelector               :
SourceRelativePath                   : resources/4ea5ee68fea05586106890ded5733820bb77d919cda27bc4b8139b7cd33b8889-2020080815-6986fdbd-59f6-42b8-8d1f-a75d403cbcde
SourceType                           : Jar
SourceVersion                        :
Status                               : Running
Type                                 : Microsoft.AppPlatform/Spring/apps/deployments
DeploymentSetting                    : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentSettings
Property                             : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.DeploymentResourceProperties
Source                               : Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.UserSourceInfo

.Inputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.ISpringCloudIdentity
.Outputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResource
.Notes
COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.

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
https://docs.microsoft.com/en-us/powershell/module/az.springcloud/update-azspringcloudappdeployment
#>
function Update-AzSpringCloudAppDeployment {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentResource])]
[CmdletBinding(DefaultParameterSetName='UpdateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
param(
    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the App resource.
    ${AppName},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Alias('DeploymentName')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the Deployment resource.
    ${Name},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the resource group that contains the resource.
    # You can obtain this value from the Azure Resource Manager API or the portal.
    ${ResourceGroupName},

    [Parameter(ParameterSetName='UpdateExpanded', Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The name of the Service resource.
    ${ServiceName},

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
    [System.Int32]
    # Required CPU, basic tier should be 1, standard tier should be in range (1, 4)
    ${DeploymentSettingCpu},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.Info(PossibleTypes=([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20190501Preview.IDeploymentSettingsEnvironmentVariables]))]
    [System.Collections.Hashtable]
    # Collection of environment variables
    ${DeploymentSettingEnvironmentVariable},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.Int32]
    # Instance count, basic tier should be in range (1, 25), standard tier should be in range (1, 500)
    ${DeploymentSettingInstanceCount},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # JVM parameter
    ${DeploymentSettingJvmOption},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.Int32]
    # Required Memory size in GB, basic tier should be in range (1, 2), standard tier should be in range (1, 8)
    ${DeploymentSettingMemoryInGb},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion])]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.RuntimeVersion]
    # Runtime version
    ${DeploymentSettingRuntimeVersion},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Selector for the artifact to be used for the deployment for multi-module projects.
    # This should bethe relative path to the target module/project.
    ${SourceArtifactSelector},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Relative path of the storage which stores the source
    ${SourceRelativePath},

    [Parameter()]
    [ArgumentCompleter([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType])]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Support.UserSourceType]
    # Type of the source uploaded
    ${SourceType},

    [Parameter()]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
    [System.String]
    # Version of the source
    ${SourceVersion},

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

begin {
    try {
        $outBuffer = $null
        if ($PSBoundParameters.TryGetValue('OutBuffer', [ref]$outBuffer)) {
            $PSBoundParameters['OutBuffer'] = 1
        }
        $parameterSet = $PSCmdlet.ParameterSetName
        $mapping = @{
            UpdateExpanded = 'Az.SpringCloud.private\Update-AzSpringCloudAppDeployment_UpdateExpanded';
            UpdateViaIdentityExpanded = 'Az.SpringCloud.private\Update-AzSpringCloudAppDeployment_UpdateViaIdentityExpanded';
        }
        if (('UpdateExpanded') -contains $parameterSet -and -not $PSBoundParameters.ContainsKey('SubscriptionId')) {
            $PSBoundParameters['SubscriptionId'] = (Get-AzContext).Subscription.Id
        }
        $wrappedCmd = $ExecutionContext.InvokeCommand.GetCommand(($mapping[$parameterSet]), [System.Management.Automation.CommandTypes]::Cmdlet)
        $scriptCmd = {& $wrappedCmd @PSBoundParameters}
        $steppablePipeline = $scriptCmd.GetSteppablePipeline($MyInvocation.CommandOrigin)
        $steppablePipeline.Begin($PSCmdlet)
    } catch {
        throw
    }
}

process {
    try {
        $steppablePipeline.Process($_)
    } catch {
        throw
    }
}

end {
    try {
        $steppablePipeline.End()
    } catch {
        throw
    }
}
}
