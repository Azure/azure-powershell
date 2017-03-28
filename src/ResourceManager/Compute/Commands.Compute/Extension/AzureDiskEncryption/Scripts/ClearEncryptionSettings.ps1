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


Write-Verbose "ClearEncryptionSettings: resourceGroupName - $resourceGroupName , vmName - $vmName";

# Get the VM object
$vm = Get-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName;

Write-Verbose "VM object encryption settings before clearing encryption settings: $vm.StorageProfile.OsDisk.EncryptionSettings";

# Clear encryption settings and disable encryption on VM object
$vm.StorageProfile.OsDisk.EncryptionSettings.Enabled = $false;
$vm.StorageProfile.OsDisk.EncryptionSettings.DiskEncryptionKey = $null;
$vm.StorageProfile.OsDisk.EncryptionSettings.KeyEncryptionKey = $null;

Write-Verbose "Cleared encryptionSettings: $vm.StorageProfile.OsDisk.EncryptionSettings";

#Stop VM, Update VM model to clear encryption settings and then start VM
Stop-AzureRmVM -Name $vmName -ResourceGroupName $resourceGroupName -Force -Verbose;

Write-Verbose "Successfully stopped VM";

Update-AzureRmVM -VM $vm -ResourceGroupName $resourceGroupName -Verbose;

Write-Verbose "Successfully updated VM";

Start-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName -Verbose;

Write-Verbose "Successfully started VM";

$vm = Get-AzureRmVm -ResourceGroupName $resourceGroupName -Name $vmName;

Write-Verbose "VM object encryption settings after clearing encryption settings: $vm.StorageProfile.OsDisk.EncryptionSettings";
