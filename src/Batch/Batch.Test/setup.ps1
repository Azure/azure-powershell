$context = Get-AzBatchAccountKey "hoppeeastasia2"
$startTask = New-Object Microsoft.Azure.Commands.Batch.Models.PSStartTask
$startTask.CommandLine = "cmd /c echo hello"
$configuration = New-Object Microsoft.Azure.Commands.Batch.Models.PSCloudServiceConfiguration -ArgumentList @("4", "*")
New-AzBatchPool -Id "testPool" -VirtualMachineSize "standard_d1_v2" -CloudServiceConfiguration $configuration -TargetDedicated 3 -StartTask $startTask -BatchContext $context

$imageRef = New-Object Microsoft.Azure.Commands.Batch.Models.PSImageReference -ArgumentList @("0001-com-ubuntu-server-jammy","canonical","22_04-LTS")
$virtualMachineConfig = New-Object Microsoft.Azure.Commands.Batch.Models.PSVirtualMachineConfiguration -ArgumentList @($imageRef, "batch.node.ubuntu 22.04")
New-AzBatchPool -Id "testIaasPool" -VirtualMachineSize "Standard_A1_v2" -TargetDedicated 1 -VirtualMachineConfiguration $virtualMachineConfig -BatchContext $context