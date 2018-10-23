Param(  
  [Parameter(Mandatory = $true, 
             HelpMessage="Name of the resource group to which the VM belongs to")]
  [ValidateNotNullOrEmpty()]
  [string]$resourceGroupName,

  [Parameter(Mandatory = $true,
             HelpMessage="Name of the VM")]
  [ValidateNotNullOrEmpty()]
  [string]$vmName
  )

$VerbosePreference = "Continue";
$ErrorActionPreference = "Stop";


#Stop VM, Update VM model to clear encryption settings and then start VM
Write-Verbose "Stopping VM resourceGroupName - $resourceGroupName , vmName - $vmName";
Stop-AzureRmVM -Name $vmName -ResourceGroupName $resourceGroupName -Force -Verbose;
Write-Verbose "Successfully stopped VM";

# Get the VM object
$vm = Get-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName;
$backupEncryptionSettings = $vm.StorageProfile.OsDisk.EncryptionSettings;

# Clear encryption settings and disable encryption on VM object
Write-Verbose "ClearEncryptionSettings: resourceGroupName - $resourceGroupName , vmName - $vmName";
Write-Verbose "VM object encryption settings before clearing encryption settings: $vm.StorageProfile.OsDisk.EncryptionSettings";
$vm.StorageProfile.OsDisk.EncryptionSettings.Enabled = $false;
$vm.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey = $null;
$vm.StorageProfile.OsDisk.EncryptionSettings.KeyEncryptionKey = $null;
Write-Verbose "Cleared encryptionSettings: $vm.StorageProfile.OsDisk.EncryptionSettings";

# Update VM with cleared encryption settings
Update-AzureRmVM -VM $vm -ResourceGroupName $resourceGroupName -Verbose;
Write-Verbose "Successfully updated VM";

# Start the VM
Start-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName -Verbose;
Write-Verbose "Successfully started VM";

$vm = Get-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName;
Write-Verbose "VM object encryption settings after clearing encryption settings: $vm.StorageProfile.OsDisk.EncryptionSettings";
