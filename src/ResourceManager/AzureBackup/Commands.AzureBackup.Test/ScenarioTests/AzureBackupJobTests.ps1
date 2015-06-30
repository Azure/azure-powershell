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


function Test-GetAzureBackupJob
{
	$vault = Get-AzureBackupVault -Name $ResourceName;
	$OneMonthBack = Get-Date;
	$OneMonthBack = $OneMonthBack.AddDays(-30);
	$jobs = Get-AzureBackupJob -Vault $vault -From $OneMonthBack
	Assert-NotNull $jobs 'Jobs list should not be null'
	foreach($job in $jobs)
	{
		Assert-NotNull $jobs.InstanceId 'JobID should not be null';
		Assert-NotNull $jobs.StartTime 'StartTime should not be null';
		Assert-NotNull $jobs.WorkloadType 'WorkloadType should not be null';
		Assert-NotNull $jobs.WorkloadName 'WorkloadName should not be null';
		Assert-NotNull $jobs.Status 'Status should not be null';
		Assert-NotNull $jobs.Operation 'Operation should not be null';

		$jobDetails = Get-AzureBackupJobDetails -Job $job
		Assert-NotNull $jobDetails.InstanceId 'JobID should not be null';
		Assert-NotNull $jobDetails.StartTime 'StartTime should not be null';
		Assert-NotNull $jobDetails.WorkloadType 'WorkloadType should not be null';
		Assert-NotNull $jobDetails.WorkloadName 'WorkloadName should not be null';
		Assert-NotNull $jobDetails.Status 'Status should not be null';
		Assert-NotNull $jobDetails.Operation 'Operation should not be null';
		Assert-NotNull $jobDetails.Properties 'Properties in job details cannot be null';
		Assert-NotNull $jobDetails.SubTasks 'SubTasks in job details cannot be null';
	}
}


function Test-StopAzureBackupJob
{
	$OneMonthBack = Get-Date;
	$OneMonthBack = $OneMonthBack.AddDays(-30);

    $azureBackUpItem = New-Object Microsoft.Azure.Commands.AzureBackup.Models.AzureBackupItem
	$azureBackUpItem.ResourceGroupName = $ResourceGroupName
	$azureBackUpItem.ResourceName = $ResourceName
	$azureBackUpItem.Location = $Location
	$azureBackUpItem.ContainerUniqueName = $ContainerName
	$azureBackUpItem.ContainerType = $ContainerType
	$azureBackUpItem.DataSourceId = $DataSourceId
	$azureBackUpItem.Type = $DataSourceType

	$job = Backup-AzureBackupItem -Item $azureBackUpItem

	Stop-AzureBackupJob -Job $job;
	Wait-AzureBackupJob -Job $job;
	$jobDetails = Get-AzureBackupJobDetails -Job $job;
	Assert-AreEqual 'Cancelled' $jobDetails.Status
}
