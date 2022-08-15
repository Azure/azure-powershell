
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
Deploy the build file to an existing deployment.
.Description
Deploy the build file to an existing deployment.
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}
.Example
PS C:\> {{ Add code here }}

{{ Add output here }}

.Outputs
Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IAppResource
.Link
https://docs.microsoft.com/powershell/module/az.SpringCloud/deploy-azSpringCloudapp
#>
function Deploy-AzSpringCloudApp {
[OutputType([Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.IAppResource])]
[CmdletBinding(DefaultParameterSetName='DeployAppForStandard', PositionalBinding=$false, SupportsShouldProcess, ConfirmImpact='Medium')]
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


    [Parameter(Mandatory, HelpMessage='The path of the file need to be deploied. The file supports Jar, NetcoreZip and Source.')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The path of the file need to be deploied. The file supports Jar, NetcoreZip and Source.
    ${FilePath},

    [Parameter(Mandatory, ParameterSetName = "DeployAppForEnterprise", HelpMessage='The resource id of builder to build the source code.')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The path of the file need to be deploied. The file supports Jar, NetcoreZip and Source.
    ${BuilderId},

    [Parameter(Mandatory, ParameterSetName = "DeployAppForEnterprise", HelpMessage='The resource id of agent pool.')]
    [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Category('Path')]
    [System.String]
    # The path of the file need to be deploied. The file supports Jar, NetcoreZip and Source.
    ${AgentPoolId},

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
        <# IMPORTANT
            1. deployment.source.type with value Jar/NetCoreZip is not supported when service instance;sku.tier is Enterprise
        #>
        $DeployPSBoundParameters = @{}
        if ($PSBoundParameters.ContainsKey('HttpPipelineAppend')) {
            $DeployPSBoundParameters['HttpPipelineAppend'] = $HttpPipelineAppend
        }
        if ($PSBoundParameters.ContainsKey('HttpPipelinePrepend')) {
            $DeployPSBoundParameters['HttpPipelinePrepend'] = $HttpPipelinePrepend
        }
        $DeployPSBoundParameters['SubscriptionId'] = $SubscriptionId
        
        # Get spring cloud service sku tier
        $service = Get-AzSpringCloud -ResourceGroupName $ResourceGroupName -Name $ServiceName @DeployPSBoundParameters
        # Get active deployment of the spring cloud app
        $activeDeployment = (Get-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name @DeployPSBoundParameters | Where-Object {$_.Active}).Name
        # Uploading package to blob
        $relativePath = UploadFileToSpringCloud -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name -ServiceType $service.SkuTier -FilePath $FilePath -DeployPSBoundParameters $DeployPSBoundParameters
        Write-Host "[3/3] Updating deployment in app $Name (this operation can take a while to complete)" -ForegroundColor Yellow
        if ($service.SkuTier -eq 'Enterprise')
        {
            DeployEnterpriseSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name -DeploymentName $activeDeployment `
            -BuilderId $BuilderId -AgentPoolId $AgentPoolId -RelativePath $relativePath -DeployPSBoundParameters $DeployPSBoundParameters
        }
        DeployStandardSpringCloudApp -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $Name -DeploymentName $activeDeployment -RelativePath $relativePath -DeployPSBoundParameters $DeployPSBoundParameters
    }
}

function UploadFileToSpringCloud {
    param (                
        [string]
        $ResourceGroupName,

        [string]
        $ServiceName,

        [string]
        $AppName,

        [string]
        $ServiceType,

        [string]
        $FilePath,

        [hashtable]
        $DeployPSBoundParameters
    )
    Write-Host '[1/3] Requesting for upload URL' -ForegroundColor Yellow
    if ($ServiceType -eq 'Enterprise')
    {
        $uploadInfo = Az.SpringCloud.internal\Get-AzSpringCloudBuildServiceResourceUploadUrl -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -Name default @DeployPSBoundParameters
    }
    else {
        $uploadInfo = Az.SpringCloud.internal\Get-AzSpringCloudAppResourceUploadUrl -ResourceGroupName $ResourceGroupName -serviceName $ServiceName -Name $AppName @DeployPSBoundParameters
    }
    Write-Host '[2/3] Uploading package to blob' -ForegroundColor Yellow
    $uploadUrl = $uploadInfo.UploadUrl
    $uri = [System.Uri]::New($uploadUrl.Split('?')[0])
    $sasToken = $uploadUrl.Split('?')[-1]
    $storageCredentials = [Microsoft.WindowsAzure.Storage.Auth.StorageCredentials]::New($sasToken)
    $cloudFile = [Microsoft.WindowsAzure.Storage.File.CloudFile]::New($uri, $storageCredentials)
    $uploadTask = $cloudFile.UploadFromFileAsync($filePath)
    try {
        $null = $uploadTask.GetAwaiter().GetResult()
    }
    catch {
        throw $_.Exception
    }
    return $uploadInfo.RelativePath
}

function DeployStandardSpringCloudApp {
    param (
        [string]
        $ResourceGroupName,

        [string]
        $ServiceName,

        [string]
        $AppName,

        [string]
        $DeploymentName,

        [string]
        $RelativePath,

        [hashtable]
        $DeployPSBoundParameters
    )
    $deployment = Get-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AppName -Name $DeploymentName @DeployPSBoundParameters
    if ($deployment.Source.Type -eq 'Jar')
    {
        $source = [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.JarUploadedUserSourceInfo]::New()
        $source.RelativePath = $RelativePath
        $source.Type = $deployment.Source.Type
    }
    if ($deployment.Source.Type -eq 'NetCoreZip')
    {
        $source = [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.NetCoreZipUploadedUserSourceInfo]::New()
        $source.RelativePath = $RelativePath
        $source.Type = $deployment.Source.Type
    }
    if ($deployment.Source.Type -eq 'Source')
    {
        $source = [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.SourceUploadedUserSourceInfo]::New()
        $source.RelativePath = $RelativePath
        $source.Type = $deployment.Source.Type
    }
    Update-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AppName -Name $DeploymentName -Source $source @DeployPSBoundParameters
    Start-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AppName -Name $DeploymentName @DeployPSBoundParameters
}

function DeployEnterpriseSpringCloudApp {
    param (
        [string]
        $ResourceGroupName,

        [string]
        $ServiceName,

        [string]
        $AppName,

        [string]
        $DeploymentName,

        [string]
        $BuilderId,

        [string]
        $AgentPoolId,

        [string]
        $RelativePath,

        [hashtable]
        $DeployPSBoundParameters
    )
    $buildName = 'default' + (Get-Random)
    $null = Az.SpringCloud.internal\New-AzSpringCloudBuildServiceBuild -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -BuildServiceName 'default' -Name $buildName -AgentPoolId $AgentPoolId -BuilderId $BuilderId -RelativePath $RelativePath @DeployPSBoundParameters
    do {
        Start-Sleep 30
        $result = Az.SpringCloud.internal\Get-AzSpringCloudBuildServiceBuildResult -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -BuildServiceName 'default' -BuildName $buildName -Name 1
        if ($result.ProvisioningState -eq 'Failed')
        {
            $resultFailedLog = Az.SpringCloud.internal\Get-AzSpringCloudBuildServiceBuildResultLog -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -BuildServiceName 'default' -BuildName $buildName -Name 1
            throw "Service build failed, Log file url: $resultFailedLog"
        }
    } until ($result.ProvisioningState -eq 'Succeeded')
    $buildResult = [Microsoft.Azure.PowerShell.Cmdlets.SpringCloud.Models.Api20220401.BuildResultUserSourceInfo]::New()
    $buildResult.Type = "BuildResult"
    $buildResult.BuildResultId = $result.Id
    $null  = Update-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AppName -Name $DeploymentName -Source $buildResult @DeployPSBoundParameters
    Start-AzSpringCloudAppDeployment -ResourceGroupName $ResourceGroupName -ServiceName $ServiceName -AppName $AppName -Name $DeploymentName @DeployPSBoundParameters
}