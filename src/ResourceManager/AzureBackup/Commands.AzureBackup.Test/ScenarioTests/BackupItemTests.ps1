$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$ContainerName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "SouthEast Asia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ItemName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"


function Test-BackUpAzureBackUpItem
{
    $AzureRMBackupItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$AzureRMBackupItem.ResourceGroupName = $ResourceGroupName
	$AzureRMBackupItem.ResourceName = $ResourceName
	$AzureRMBackupItem.Location = $Location
	$AzureRMBackupItem.ContainerUniqueName = $ContainerName
	$AzureRMBackupItem.ItemName = $ItemName
	$jobId = Backup-AzureRMBackupItem -Item $AzureRMBackupItem
}
