Param(  
  [Parameter(Mandatory = $true, 
             HelpMessage="Name of the resource group to which the KeyVault belongs to.  A new resource group with this name will be created if one doesn't exist")]
  [ValidateNotNullOrEmpty()]
  [string]$resourceGroupName,

  [Parameter(Mandatory = $true)]
  [ValidateNotNullOrEmpty()]
  [string]$vmName
  )

$VerbosePreference = "Continue";
$ErrorActionPreference = “Stop”;

Write-Host "Stopping VM before clearing encryption settings";
Stop-AzVM -Name $vmName -ResourceGroupName $resourceGroupName -Force;

$vm = Get-AzVm -ResourceGroupName $resourceGroupName -Name $vmName;
$backupEncryptionSettings = $vm.StorageProfile.OsDisk.EncryptionSettings;


## Clear encryption settings from VM model
Write-Host "Clearing Encryption settings from VM";
$vm.StorageProfile.OsDisk.EncryptionSettings.Enabled = $false;
$vm.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey = $null;
$vm.StorageProfile.OsDisk.EncryptionSettings.KeyEncryptionKey = $null;
Update-AzVM -VM $vm -ResourceGroupName $resourceGroupName;

$vm = Get-AzVm -ResourceGroupName $resourceGroupName -Name $vmName;
## Update Encryption settings to add BEK only
Write-Host "Setting Encryption settings to VM without KEK";
$vm.StorageProfile.OsDisk.EncryptionSettings.Enabled = $true;
$vm.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey = $backupEncryptionSettings.DiskEncryptionKey;
Update-AzVM -VM $vm -ResourceGroupName $resourceGroupName;

Write-Host "Starting VM";
$vm | Start-AzVm;