Param(
	[parameter(Mandatory=$true)]
	[string] $subscriptionName,
	[parameter(Mandatory=$true)]
	[string] $automationAccountName,
	[parameter(Mandatory=$true)]
	[string] $aaResourseGroupName,
	[parameter(Mandatory=$true)]
	[string] $storageAccountName,
	[parameter(Mandatory=$true)]
	[string] $saResourseGroupName,
	[parameter(Mandatory=$true)]
	[string] $containerName,
	[parameter(Mandatory=$true)]
	[string] $reportFolderPrefix
)
loginWithConnection -connectionName "AzureRunAsConnection"
# from AddVhdTests.ps1 - no tests found
# from AEMExtensionTests.ps1 - no tests found
# from AvailabilitySetTests.ps1 - no tests found
# from AvailabilityZoneTests.ps1 - no tests found
# from ChefExtensionTests.ps1 - no tests found
# from ComputeCloudExceptionTests.ps1 - no tests found
# from ContainerServiceTests.ps1 - no tests found
# from DiagnosticsExtensionTests.ps1 - no tests found
# from DiskRPTests.ps1 - no tests found
# from DscExtensionTests.ps1 - no tests found
# from ImageTests.ps1 - no tests found
# from ResourceSkuTests.ps1 - no tests found
# from SqlIaaSExtensionTests.ps1 - no tests found
# from VirtualMachineBootDiagnosticsTests.ps1
$VirtualMachineBootDiagnosticsTests = @(
	 'Test-LinuxVirtualMachineBootDiagnostics'
	,'Test-VirtualMachineBootDiagnostics'
)
# from VirtualMachineExtensionTests.ps1 - no tests found
# from VirtualMachineNetworkInterfaceTests.ps1 - no tests found
# from VirtualMachineProfileTests.ps1 - no tests found
# from VirtualMachineRunCommandTests.ps1
$VirtualMachineRunCommandTests = @(
	 'Test-VirtualMachineGetRunCommand'
)
# from VirtualMachineScaleSetExtensionTests.ps1 - no tests found
# from VirtualMachineScaleSetTests.ps1 - no tests found
# from VirtualMachineTests.ps1
$VirtualMachineTests = @(
	 'Test-LinuxVirtualMachine'
	,'Test-VirtualMachinePlan2'
	,'Test-VirtualMachineWithVMAgentAutoUpdate'
)
# from VMDynamicTests.ps1 - no tests found
$testList =
	$VirtualMachineBootDiagnosticsTests +
	$VirtualMachineRunCommandTests +
	$VirtualMachineTests
TestRunner $testList
$jobId = $PsPrivateMetaData.JobId.Guid
SaveResultsInStorageAccount -jobId $jobId -subscriptionName $subscriptionName -automationAccountName $automationAccountName -aaResourseGroupName $aaResourseGroupName -storageAccountName $storageAccountName -saResourseGroupName $saResourseGroupName -containerName $containerName -reportFolderPrefix $reportFolderPrefix
    
