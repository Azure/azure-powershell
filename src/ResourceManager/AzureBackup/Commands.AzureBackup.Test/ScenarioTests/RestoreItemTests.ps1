$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$ContainerName = "iaasvmcontainer;dev01testing;dev01testing"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "southeastasia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;dev01testing;dev01testing"
$ItemName = "iaasvmcontainer;dev01testing;dev01testing"
$RecoveryPointName = "12520735098347"
$StorageAccountName = "portalvhds7jzk3jty85qx5"


function Test-RestoreAzureBackUpItem
{
    $azureBackUpRecoveryPoint = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureBackupRecoveryPoint
	$azureBackUpRecoveryPoint.ResourceGroupName = $ResourceGroupName
	$azureBackUpRecoveryPoint.ResourceName = $ResourceName
	$azureBackUpRecoveryPoint.Location = $Location
	$azureBackUpRecoveryPoint.ContainerUniqueName = $ContainerName
	$azureBackUpRecoveryPoint.ItemName = $ItemName
	$azureBackUpRecoveryPoint.RecoveryPointName = $RecoveryPointName
	$jobId = Restore-AzureBackupItem -RecoveryPoint $azureBackUpRecoveryPoint -StorageAccountName $StorageAccountName
}
