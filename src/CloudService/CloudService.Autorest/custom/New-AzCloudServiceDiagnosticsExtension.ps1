# ----------------------------------------------------------------------------------
#
# Copyright Microsoft Corporation
# Licensed under the Apache License, Version 2.0 (the \"License\");
# you may not use this file except in compliance with the License.
# You may obtain a copy of the License at
# http://www.apache.org/licenses/LICENSE-2.0
# Unless required by applicable law or agreed to in writing, software
# distributed under the License is distributed on an \"AS IS\" BASIS,
# WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
# See the License for the specific language governing permissions and
# limitations under the License.
# ----------------------------------------------------------------------------------

<#
.Synopsis
Create a in-memory object for Diagnostics Extension
.Description
Create a in-memory object for Diagnostics Extension
#>

function New-AzCloudServiceDiagnosticsExtension {
  [OutputType('Microsoft.Azure.PowerShell.Cmdlets.CloudService.Models.Api20220904.Extension')]
  param(
    [Parameter(HelpMessage="Name of Diagnostics Extension.", Mandatory)]
    [string] $Name,

    [Parameter(HelpMessage="Subscription.")]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Category('Path')]
    [Microsoft.Azure.PowerShell.Cmdlets.CloudService.Runtime.DefaultInfo(Script='(Get-AzContext).Subscription.Id')]
    [System.String]
    # Subscription credentials which uniquely identify Microsoft Azure subscription.
    # The subscription ID forms part of the URI for every service call.
    ${Subscription},

    [Parameter(HelpMessage="Resource Group name of Cloud Service.", Mandatory)]
    [string] $ResourceGroupName,

    [Parameter(HelpMessage="Name of Cloud Service.", Mandatory)]
    [string] $CloudServiceName,

    [Parameter(HelpMessage="Specifies the configuration for Azure Diagnostics. You can download the schema by using the following command: (Get-AzureServiceAvailableExtension -ExtensionName 'PaaSDiagnostics' -ProviderNamespace 'Microsoft.Azure.Diagnostics').PublicConfigurationSchema | Out-File -Encoding utf8 -FilePath 'WadConfig.xsd'", Mandatory)]
    [string] $DiagnosticsConfigurationPath,

    [Parameter(HelpMessage="Name of the Storage Account.", Mandatory)]
    [string] $StorageAccountName,

    [Parameter(HelpMessage="Storage Account Key.", Mandatory)]
    [string] $StorageAccountKey,

    [Parameter(HelpMessage="Specifies the version of the extension.")]
    [string] $TypeHandlerVersion,

    [Parameter(HelpMessage="Roles applied to.")]
    [string[]] $RolesAppliedTo,

    [Parameter(HelpMessage="Auto upgrade minor version.")]
    [Boolean] $AutoUpgradeMinorVersion
  )

  process {
    $publisher = "Microsoft.Azure.Diagnostics"
    $extensionType = "PaaSDiagnostics"

    if (!(Test-Path $DiagnosticsConfigurationPath -PathType Leaf))
    {
        throw ("DiagnosticsConfigurationPath does not exits: " + $DiagnosticsConfigurationPath)
    }

    [xml]$diagnosticsConfigurationXml = Get-Content $DiagnosticsConfigurationPath

    $storageAccount = $diagnosticsConfigurationXml.PublicConfig.ChildNodes | Where-Object { $_.Name -eq 'StorageAccount' }
    if ($storageAccount)
    {
        Write-Host "Using StorageAccount information defined in diagnostics configuration file."
    }
    else
    {
        $storageAccount = $diagnosticsConfigurationXml.CreateElement('StorageAccount', $diagnosticsConfigurationXml.PublicConfig.NamespaceURI)
        $storageAccount.InnerText = $StorageAccountName
        $storageAccount = $diagnosticsConfigurationXml.PublicConfig.AppendChild($storageAccount)
    }

    $metrics = $diagnosticsConfigurationXml.PublicConfig.WadCfg.DiagnosticMonitorConfiguration.ChildNodes | Where-Object { $_.Name -eq 'Metrics' }
    if ($metrics)
    {
        Write-Host "Using Metrics information defined in diagnostics configuration file."
    }
    else
    {
        $metrics = $diagnosticsConfigurationXml.CreateElement('Metrics', $diagnosticsConfigurationXml.PublicConfig.NamespaceURI)
        $resourceId = "/subscriptions/$Subscription/resourceGroups/$ResourceGroupName/providers/Microsoft.Compute/cloudservices/$CloudServiceName"
        $metrics.SetAttribute('resourceId', $resourceId)
        $metrics = $diagnosticsConfigurationXml.PublicConfig.WadCfg.DiagnosticMonitorConfiguration.AppendChild($metrics)
    }

    $setting = $diagnosticsConfigurationXml.PublicConfig.OuterXml

    $privateConfig = $diagnosticsConfigurationXml.ChildNodes | Where-Object { $_.Name -eq 'PrivateConfig' }
    if ($privateConfig)
    {
        $protectedSetting = $privateConfig.OuterXml
        Write-Host "Using PrivateConfig information defined in diagnostics configuration file."
    }
    else
    {
        $storageEndpoint = "https://core.windows.net"
        $protectedSetting = '<?xml version="1.0" encoding="UTF-8"?><PrivateConfig xmlns="http://schemas.microsoft.com/ServiceHosting/2010/10/DiagnosticsConfiguration"><StorageAccount endpoint="' + $storageEndpoint + '" key="' + $StorageAccountKey + '" name="' + $storageAccountName + '"/></PrivateConfig>'
    }

    return New-AzCloudServiceExtensionObject -Name $Name -Publisher $publisher -Type $extensionType -TypeHandlerVersion $TypeHandlerVersion -Setting $setting -ProtectedSetting $protectedSetting -RolesAppliedTo $RolesAppliedTo -AutoUpgradeMinorVersion $AutoUpgradeMinorVersion
  }
}
