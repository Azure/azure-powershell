$PLACEHOLDER = "PLACEHOLDER1@";

<#
.SYNOPSIS
End to end Sql IaaS extension test that tests Get-AzureVMSqlServerExtension cmdlet. It does the following:
    1) Creates cloud service and a VM with SQL 2016 Image.
    2) Installs the extension by calling Set-AzureVMSqlServerExtension cmdlet on the VM.
    3) Calls Get-AzureVMSqlServerExtension cmdlet to check the status of the extension installation.
	4) Sets Auto Patching and Auto Backup settings by calling Set-AzureVMDscExtension cmdlet on the VM.
    5) Calls Get-AzureVMSqlServerExtension cmdlet to get extension details and verify it with values updated with Set-AzureVMSqlServerExtension.
#>
function Test-GetAzureVMSqlIaaSExtension
{
    Set-StrictMode -Version latest; $ErrorActionPreference = 'Stop'

    # Setup
    $location = Get-DefaultLocation
    $storageName = getAssetName

    try
    {
        New-AzureStorageAccount -StorageAccountName $storageName -Location $location
        Set-CurrentStorageAccountName $storageName

        $vmName = "pshelltestvm1"
        $svcName = Get-CloudServiceName

		# Get latest SQL 2016 VM Image
		$family = "SQL Server 2016 RTM Enterprise on Windows Server 2012 R2"
		$image = Get-AzureVMImage | where { $_.ImageFamily -eq $family } | sort PublishedDate -Descending | select -ExpandProperty ImageName -First 1

        # Create new cloud service
        New-AzureService -ServiceName $svcName -Location $location

		# Create the VM config
		$vmsize = "A5"
		$vm1 = New-AzureVMConfig -Name $vmname -InstanceSize $vmsize -ImageName $image

		# Create the SQL VM
		$user = "localadmin";
        $password = $PLACEHOLDER;
		$vm1 | Add-AzureProvisioningConfig -Windows -AdminUsername $user -Password $password
		New-AzureVM –ServiceName $svcname -VMs $vm1
		
		#Do actual changes and work here
        
        # 1) Installs the SqlIaaS extension by calling Set-AzureVMSqlServerExtension cmdlet on a VM.
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName 
		$vm | Set-AzureVMSqlServerExtension | Update-AzureVM
    
		# 2) Calls Get-AzureRmVMSqlServerExtension cmdlet to verify the status of the extension installation.
        $extension = $vm | Get-AzureVMSqlServerExtension
		Assert-NotNull $extension
        Assert-NotNull $extension.ExtensionName
        Assert-NotNull $extension.Publisher
        Assert-NotNull $extension.Version

		# Repeat until the extension is ready.
        [TimeSpan] $timeout = [TimeSpan]::FromMinutes(30)
        $maxTime = [datetime]::Now + $timeout

        while($true)
        {
            if($extension -ne $null -and $extension.ExtensionStatus -ne $null)
            {
                if(($extension.ExtensionStatus -eq "Ready"))
                {
                    break;
                }
            }
        
            if([datetime]::Now -gt $maxTime)
            {
                Throw "The Sql Server Extension did not report any status within the given timeout from VM [$vmName]"
            }

            if ($env:AZURE_TEST_MODE -eq "Record"){
                sleep -Seconds 15
            }

			$extension = $vm | Get-AzureVMSqlServerExtension
        }

        # 3) Update Auto Patching and Auto Backup settings
		$storageContext = (Get-AzureStorageAccount -StorageAccountName $storageName).Context
		$aps = New-AzureVMSqlServerAutoPatchingConfig -Enable -DayOfWeek "Thursday" -MaintenanceWindowStartingHour 20 `
			-MaintenanceWindowDuration 120 -PatchCategory "Important"
		$abs = New-AzureVMSqlServerAutoBackupConfig -Enable -RetentionPeriodInDays 20 -StorageContext $storageContext -BackupScheduleType Manual `
			-BackupSystemDbs -FullBackupStartHour 10 -FullBackupWindowInHours 5 -FullBackupFrequency Daily -LogBackupFrequencyInMinutes 30
		Get-AzureVM -ServiceName $svcName -Name $vmName | Set-AzureVMSqlServerExtension -AutoPatchingSettings $aps -AutoBackupSettings $abs | Update-AzureVM
        
		# Wait few minutes for the settings to be applied and to cover the lag for guest agent to pick up updated status.
        if ($env:AZURE_TEST_MODE -eq "Record"){
            sleep -Seconds 300
        }
		
		# 4) Get the extension and verify the values.
        $extension = Get-AzureVM -ServiceName $svcName -Name $vmName | Get-AzureVMSqlServerExtension
		
		Assert-AreEqual $extension.AutoPatchingSettings.DayOfWeek "Thursday"
        Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowStartingHour 20
        Assert-AreEqual $extension.AutoPatchingSettings.MaintenanceWindowDuration 120
        Assert-AreEqual $extension.AutoPatchingSettings.PatchCategory "Important"

		Assert-AreEqual $extension.AutoBackupSettings.RetentionPeriod 20
        Assert-AreEqual $extension.AutoBackupSettings.Enable $true
        Assert-AreEqual $extension.AutoBackupSettings.BackupScheduleType "Manual"
        Assert-AreEqual $extension.AutoBackupSettings.FullBackupFrequency "Daily"
        Assert-AreEqual $extension.AutoBackupSettings.BackupSystemDbs $true
        Assert-AreEqual $extension.AutoBackupSettings.FullBackupStartTime 10
        Assert-AreEqual $extension.AutoBackupSettings.FullBackupWindowHours 5
        Assert-AreEqual $extension.AutoBackupSettings.LogBackupFrequency 30

        # Uninstall Extension
        $vm = Get-AzureVM -ServiceName $svcName -Name $vmName | Set-AzureVMSqlServerExtension -Uninstall | Update-AzureVM
    }
    finally
    {
        # Cleanup
        Remove-AzureStorageAccount -StorageAccountName $storageName -ErrorAction SilentlyContinue
        Cleanup-CloudService $svcName
    }
}