$ResourceGroupName = "backuprg"
$ResourceName = "backuprn"
$ContainerName = "iaasvmcontainer;dev01testing;dev01testing"
$ContainerType = "IaasVMContainer"
$DataSourceType = "VM"
$DataSourceId = "17593283453810"
$Location = "SouthEast Asia"
$PolicyName = "Policy9";
$PolicyId = "c87bbada-6e1b-4db2-b76c-9062d28959a4";
$POName = "iaasvmcontainer;dev01testing;dev01testing"
$ItemName = "iaasvmcontainer;dev01testing;dev01testing"
$RecoveryPointName = "12520735098347"


function Test-GetAzureRecoveryPoints
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ItemName = $ItemName
	$recoveryPoints = Get-AzureBackupRecoveryPoint -Item $azureBackUpItem
	if (!($recoveryPoints -eq $null))
	{
		foreach($recoveryPoint in $recoveryPoints)
		{
			Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
			Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
			Assert-NotNull $recoveryPoint.RecoveryPointId  'RecoveryPointId should not be null'
		}
	}
}

function Test-GetAzureRecoveryPoint
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ItemName = $ItemName
	$recoveryPoint = Get-AzureBackupRecoveryPoint -Item $azureBackUpItem -RecoveryPointId $RecoveryPointName
	if (!($recoveryPoint -eq $null))
	{
		Assert-NotNull $recoveryPoint.RecoveryPointTime 'RecoveryPointTime should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointType 'RecoveryPointType should not be null'
		Assert-NotNull $recoveryPoint.RecoveryPointId  'RecoveryPointId should not be null'
	}
}