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


function Test-BackUpAzureBackUpItem
{
    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$jobId = Backup-AzureBackupItem -Item $azureBackUpItem
}
