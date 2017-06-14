$PLACEHOLDER = "PLACEHOLDER1@";

<#
.SYNOPSIS
End to end DSC test that tests Get-AzureVMDscExtension cmdlet. It does the following:
    1) Publishes a configuration to the default storage account using Publish-AzureVMDscConfiguration cmdlet
    2) Installs the extension by calling Set-AzureVMDscExtension cmdlet on a VM.
    3) Calls Get-AzureVMDscExtensionStatus cmdlet to check the status of the extension installation.
    4) Calls Get-AzureVMDscExtension cmdlet to get extension details post installation.
#>
function Test-GetAzureVMDscExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Publish DSC Configuration
    # Publish doesnt work on some CI build machines (Still running WMF 4)
    #$configPath = '.\Resources\DscExtension\DummyConfig.ps1'
    #$StorageAccountName = "dscextensiontest"

    #$StorageAccountKey = Get-AzureStorageKey -StorageAccountName $StorageAccountName
    #$Ctx = New-AzureStorageContext -StorageAccountName $StorageAccountName -StorageAccountKey $StorageAccountKey.Primary
    #Publish-AzureVMDscConfiguration -ConfigurationPath $configPath -StorageContext $Ctx -Force -Verbose

    # Setup
    $location = Get-DefaultLocation
    $imgName = Get-DefaultImage $location
    $storageName = getAssetName

    try
    {
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        $vmName = "vm1"
        $svcName = Get-CloudServiceName

        # Test
        New-AzureService -ServiceName $svcName -Location $location
        New-AzureQuickVM -Windows -ImageName $imgName -Name $vmName -ServiceName $svcName -AdminUsername "pstestuser" -Password $PLACEHOLDER

        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName

        # Install DSC Extension Handler
        #Get latest dsc extension handler version
        $publisher = "Microsoft.Powershell"
        $extensionName = "DSC"
        $latestExtension = Get-AzureVMAvailableExtension -Publisher $publisher -ExtensionName $extensionName -Verbose
        Assert-NotNull $latestExtension
        Assert-NotNull $latestExtension.Version

        #$vm = Set-AzureVMDSCExtension -VM $vm -ConfigurationArchive 'DummyConfig.ps1.zip' -ConfigurationName 'DummyConfig' -Verbose 
        $vm = Set-AzureVMDSCExtension -VM $vm -ConfigurationArchive '' -Version $latestExtension.Version -Verbose 
        $vm | Update-AzureVM -Verbose
    
        # Call Get-AzureVMDscExtensionStatus to check the status of the installation
        [TimeSpan] $timeout = [TimeSpan]::FromMinutes(60)
        $maxTime = [datetime]::Now + $timeout
        $status = Get-AzureVMDscExtensionStatus -VM $vm 

        while($true)
        {
            if($status -ne $null -and $status.Status -ne $null)
            {
                if(($status.Status -eq "Success") -or ($status.Status -eq "Error"))
                {
                    break;
                }
            }
        
            if([datetime]::Now -gt $maxTime)
            {
                Throw "The DSC Extension did not report any status within the given timeout from VM [$vmName]"
            }

            if ($env:AZURE_TEST_MODE -eq "Record"){
                sleep -Seconds 15
            }
            $status = Get-AzureVMDscExtensionStatus -VM $vm
        }

        # Call Get-AzureVMDscExtension to ensure extension was installed on the VM
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName
        $extension = Get-AzureVMDscExtension -VM $vm -Verbose 
        Assert-NotNull $extension
        Assert-NotNull $extension.ExtensionName
        Assert-NotNull $extension.Publisher
        Assert-NotNull $extension.Version
        
        # Remove Extension
        Remove-AzureVMDscExtension -VM $vm -Verbose 
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}
