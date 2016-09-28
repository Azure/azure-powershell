<#
.SYNOPSIS
Basic end to end diagnostics extension.
#>
function Test-AzureServiceDiagnosticsExtensionBasic
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $location = Get-DefaultLocation
    $svcName = Get-CloudServiceName
    $storageName = getAssetName
    $svcName = "onesdk5266"
    $storageName = "onesdk383"

    try
    {
        # Initialize
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        $testMode = Get-ComputeTestMode;
        if ($testMode.ToLower() -ne 'playback')
        {
            $cscpkg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cspkg";
        }
        else
        {
            $cscpkg = "https://${storageName}.blob.azure.windows.net/blob/OneWebOneWorker.cspkg";
        }
        $cscfg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cscfg"
        New-AzureService -ServiceName $svcName -Location $location
        New-AzureDeployment -ServiceName $svcName -Slot Production -Package $cscpkg -Configuration $cscfg

        $extension = Get-AzureServiceDiagnosticsExtension -ServiceName $svcName
        Assert-Null $extension "The default deployment shouldn't have diagnostics extension enabled"

        $configFilePath = "$TestOutputRoot\Resources\DiagnosticsExtension\Files\CloudServiceConfig.xml"
        Set-AzureServiceDiagnosticsExtension -ServiceName $svcName -StorageAccountName $storageName -DiagnosticsConfigurationPath $configFilePath
        $extension = Get-AzureServiceDiagnosticsExtension -ServiceName $svcName
        Assert-NotNull $extension "Diagnostics extension should be enabled"

        Remove-AzureServiceDiagnosticsExtension -ServiceName $svcName
        $extension = Get-AzureServiceDiagnosticsExtension -ServiceName $svcName
        Assert-Null $extension "The diagnostics extension should have been removed"
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}

<#
.SYNOPSIS
Test Set command can accept diagnostics configuration array and update multiple roles with differen configuration.
This test also include some other usage of the command:
    1) Can accept both .xml config and .wadcfgx as config file
    2) The Get command can accept -Role parameter and filter the result accordingly
#>
function Test-AzureServiceDiagnosticsExtensionConfigurationArray
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $location = Get-DefaultLocation
    $svcName = Get-CloudServiceName
    $storageName = getAssetName
    $svcName = "onesdk5266"
    $storageName = "onesdk383"

    try
    {
        # Initialize
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        $testMode = Get-ComputeTestMode;
        if ($testMode.ToLower() -ne 'playback')
        {
            $cscpkg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cspkg";
        }
        else
        {
            $cscpkg = "https://${storageName}.blob.azure.windows.net/blob/OneWebOneWorker.cspkg";
        }
        $cscfg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cscfg"
        New-AzureService -ServiceName $svcName -Location $location
        New-AzureDeployment -ServiceName $svcName -Slot Production -Package $cscpkg -Configuration $cscfg

        $xmlConfig = "$TestOutputRoot\Resources\DiagnosticsExtension\Files\CloudServiceConfig.xml"
        $workerRoleConfig = New-AzureServiceDiagnosticsExtensionConfig -Role "WorkerRole1" -StorageAccountName $storageName -DiagnosticsConfigurationPath $xmlConfig

        $wadcfgxConfig = "$TestOutputRoot\Resources\DiagnosticsExtension\Files\diagnostics.wadcfgx"
        $webRoleConfig = New-AzureServiceDiagnosticsExtensionConfig -Role "WebRole1" -StorageAccountName $storageName -DiagnosticsConfigurationPath $wadcfgxConfig

        Set-AzureServiceDiagnosticsExtension -ServiceName $svcName -DiagnosticsConfiguration @($workerRoleConfig, $webRoleConfig)
        $extensions = Get-AzureServiceDiagnosticsExtension -ServiceName $svcName
        Assert-AreEqual $extensions.length 2 "There should be two diagnostics extensions enabled"

        $extension = Get-AzureServiceDiagnosticsExtension -ServiceName $svcName -Role "WorkerRole1"
        Assert-AreEqual $extension.Role.RoleName "WorkerRole1" "Get command should filter the result given Role parameter"
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}

<#
.SYNOPSIS
Test Set command can accept diagnostics configuration array and update multiple roles with differen configuration.
This test also include some other usage of the command:
    1) Can accept both .xml config and .wadcfgx as config file
    2) The Get command can accept -Role parameter and filter the result accordingly
#>
function Test-AzureServiceDiagnosticsExtensionWrongServiceName
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $location = Get-DefaultLocation
    $svcName = Get-CloudServiceName
    $storageName = getAssetName
    $svcName = "onesdk5266"
    $storageName = "onesdk383"

    try
    {
        # Initialize
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        $testMode = Get-ComputeTestMode;
        if ($testMode.ToLower() -ne 'playback')
        {
            $cscpkg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cspkg";
        }
        else
        {
            $cscpkg = "https://${storageName}.blob.azure.windows.net/blob/OneWebOneWorker.cspkg";
        }
        $cscfg = "$TestOutputRoot\Resources\ServiceManagement\Files\OneWebOneWorker.cscfg"
        New-AzureService -ServiceName $svcName -Location $location
        New-AzureDeployment -ServiceName $svcName -Slot Production -Package $cscpkg -Configuration $cscfg

        $xmlConfig = "$TestOutputRoot\Resources\DiagnosticsExtension\Files\CloudServiceConfig.xml"
        $workerRoleConfig = New-AzureServiceDiagnosticsExtensionConfig -Role "WorkerRole1" -StorageAccountName $storageName -DiagnosticsConfigurationPath $xmlConfig

        $wadcfgxConfig = "$TestOutputRoot\Resources\DiagnosticsExtension\Files\diagnostics.wadcfgx"
        $webRoleConfig = New-AzureServiceDiagnosticsExtensionConfig -Role "WebRole1" -StorageAccountName $storageName -DiagnosticsConfigurationPath $wadcfgxConfig

        Assert-ThrowsContains `
            { Set-AzureServiceDiagnosticsExtension -ServiceName "ab" -DiagnosticsConfiguration @($workerRoleConfig, $webRoleConfig) } `
            "Cannot find cloud service";
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}
