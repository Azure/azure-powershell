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


function Test-GetAzureBackupItemTests
{
	$azureBackUpContainer = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupContainer
	$azureBackUpContainer.ResourceGroupName = $ResourceGroupName
	$azureBackUpContainer.ResourceName = $ResourceName
	$azureBackUpContainer.Location = $Location
	$azureBackUpContainer.ContainerUniqueName = $ContainerName
	$azureBackUpContainer.ContainerType = $ContainerType
	$item = Get-AzureBackupItem -Container $azureBackUpContainer
	if (!($item -eq $null))
	{
		foreach($backupitem in $item)
		{   
			Assert-NotNull $backupitem.ProtectionStatus 'ProtectionStatus should not be null'    
			Assert-NotNull $backupitem.Name 'Name should not be null'            
			Assert-NotNull $backupitem.Type 'Type should not be null'            
			Assert-NotNull $backupitem.ContainerType 'ContainerType should not be null'      
			Assert-NotNull $backupitem.ContainerUniqueName 'ContainerUniqueName should not be null'
			Assert-NotNull $backupitem.ResourceGroupName 'ResourceGroupName should not be null'  
			Assert-NotNull $backupitem.ResourceName 'ResourceName should not be null'      
			Assert-NotNull $backupitem.Location 'Location should not be null' 
		}
	}
}

function Test-EnableAzureBackupProtection
{	
	$policy = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupProtectionPolicy
	$policy.InstanceId = $PolicyId
	$policy.Name = $PolicyName
	$policy.ResourceGroupName = $ResourceGroupName
	$policy.ResourceName = $ResourceName
	$policy.Location = $Location
	$policy.WorkloadType = "VM"
	$policy.RetentionType = "1"
	$policy.ScheduleRunTimes =  "2015-06-13T20:30:00"

	$azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$azureBackUpItem.Name = $POName
	$jobId = Enable-AzureBackupProtection -Item $azureBackUpItem -Policy $policy 
	
}

function Test-DisableAzureBackupProtection
{	
	$azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Cmdlets.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType
	$azureBackUpItem.Name = $POName
	$jobId1 = Disable-AzureBackupProtection -Item $azureBackUpItem
}
