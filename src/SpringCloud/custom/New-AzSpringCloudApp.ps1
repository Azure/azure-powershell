
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
Create a new App or update an exiting App.
.Description
Create a new App or update an exiting App.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource
.Link
https://docs.microsoft.com/en-us/powershell/module/az.springcloud/new-azspringcloudapp
#>
function New-AzSpringCloudApp {
    [OutputType([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource])]
    [CmdletBinding(DefaultParameterSetName='CreateExpanded', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
    param(
        [Parameter(Mandatory)]
        [Alias('AppName')]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
        [System.String]
        # The name of the App resource.
        ${Name},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
        [System.String]
        # The name of the resource group that contains the resource.
        # You can obtain this value from the Azure Resource Manager API or the portal.
        ${ResourceGroupName},
    
        [Parameter(Mandatory)]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
        [System.String]
        # The name of the Service resource.
        ${ServiceName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
        [System.String]
        # Gets subscription ID which uniquely identify the Microsoft Azure subscription.
        # The subscription ID forms part of the URI for every service call.
        ${SubscriptionId},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.String]
        # Name of the active deployment of the App
        ${ActiveDeploymentName},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.String]
        # Fully qualified dns Name.
        ${Fqdn},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Indicate if only https is allowed.
        ${HttpsOnly},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.String]
        # The GEO location of the application, always the same with its parent resource
        ${Location},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.String]
        # Mount path of the persistent disk
        ${PersistentDiskMountPath},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.Int32]
        # Size of the persistent disk in GB
        ${PersistentDiskSizeInGb},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.Management.Automation.SwitchParameter]
        # Indicates whether the App exposes public endpoint
        ${Public},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.String]
        # Mount path of the temporary disk
        ${TemporaryDiskMountPath},
    
        [Parameter()]
        [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Body')]
        [System.Int32]
        # Size of the temporary disk in GB
        ${TemporaryDiskSizeInGb},
    
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
        if (-not $PSBoundParameters.ContainsKey('Location')) {
            $ResourceGroup = Get-AzResourceGroup -Name $ResourceGroupName
            $PSBoundParameters.Add('Location', $ResourceGroup.Location)
        }
        Az.SpringCloud.internal\New-AzSpringCloudApp @PSBoundParameters
    }
}
    