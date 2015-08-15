$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$ContainerName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "southeastasia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$ItemName = "iaasvmcontainer;hydrarecordvm;hydrarecordvm"
$RecoveryPointName = "587454680194"
$StorageAccountName = "portalvhds7jzk3jty85qx5"


function Test-RestoreAzureBackUpItem
{
    $azureBackUpRecoveryPoint = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupRecoveryPoint
	$azureBackUpRecoveryPoint.ResourceGroupName = $ResourceGroupName
	$azureBackUpRecoveryPoint.ResourceName = $ResourceName
	$azureBackUpRecoveryPoint.Location = $Location
	$azureBackUpRecoveryPoint.ContainerUniqueName = $ContainerName
	$azureBackUpRecoveryPoint.ItemName = $ItemName
	$azureBackUpRecoveryPoint.RecoveryPointName = $RecoveryPointName
	$jobId = Restore-AzureRMBackupItem -RecoveryPoint $azureBackUpRecoveryPoint -StorageAccountName $StorageAccountName
}
