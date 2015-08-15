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
$RecoveryPointName = "587454680194"


function Test-GetAzureRecoveryPoints
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ItemName = $ItemName
	$recoveryPoints = Get-AzureRMBackupRecoveryPoint -Item $azureBackUpItem
	if (!($recoveryPoints -eq $null))
	{
		foreach($recoveryPoint in $recoveryPoints)
		{
			Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
			Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
			Assert-NotNull $recoveryPoint.RecoveryPointName  'RecoveryPointId should not be null'
		}
	}
}

function Test-GetAzureRecoveryPoint
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureRMBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ItemName = $ItemName
	$recoveryPoint = Get-AzureRMBackupRecoveryPoint -Item $azureBackUpItem -RecoveryPointId $RecoveryPointName
	if (!($recoveryPoint -eq $null))
	{
		Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointName  'RecoveryPointId should not be null'
	}
}