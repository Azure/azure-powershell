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


function Test-GetAzureRecoveryPoint
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceGroupName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
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