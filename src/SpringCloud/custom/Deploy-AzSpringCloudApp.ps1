
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
Deploy the built jar to service.
.Description
Deploy the built jar to service.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20200701.IAppResource
.Link
https://docs.microsoft.com/en-us/powershell/module/az.SpringCloud/deploy-azSpringCloudapp
#>
function Deploy-AzSpringCloudApp {
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


    [Parameter(Mandatory)]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The path of the jar need to be deploied.
    ${JarPath},

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
        $DeployPSBoundParameters = @{}
        if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
            $DeployPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
        }
        if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
            $DeployPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
        }
        $DeployPSBoundParameters['SubscriptionId'] = $SubscriptionId

        Write-Host '[1/3] Requesting for upload URL' -ForegroundColor Yellow
        $UploadInfo = Az.SpringCloud.internal\Get-AzSpringCloudAppResourceUploadUrl -ResourceGroupName $ResourceGroupName -serviceName $ServiceName -AppName $Name @DeployPSBoundParameters
        $UploadUrl = $UploadInfo.UploadUrl
        $Uri = [System.Uri]::New($UploadUrl.Split('?')[0])
        $SasToken = $UploadUrl.Split('?')[-1]
        $StorageCredentials = [Microsoft.WindowsAzure.Storage.Auth.StorageCredentials]::New($SasToken)
        $CloudFile = [Microsoft.WindowsAzure.Storage.File.CloudFile]::New($Uri, $StorageCredentials)
        
        Write-Host '[2/3] Uploading package to blob' -ForegroundColor Yellow
        $UploadTask = $CloudFile.UploadFromFileAsync($JarPath)
        try {
            $null = $UploadTask.GetAwaiter().GetResult()
        }
        catch {
            Write-Error $_.Exception
            return
        }
        Write-Host "[3/3] Updating deployment in app $Name (this operation can take a while to complete)" -ForegroundColor Yellow
        $App = Get-AzSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name @DeployPSBoundParameters
        Update-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name -DeploymentName $App.ActiveDeploymentName -SourceRelativePath $UploadInfo.RelativePath @DeployPSBoundParameters
        Start-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name -DeploymentName $App.ActiveDeploymentName @DeployPSBoundParameters
    }
}
