
$clientSecret = ConvertTo-SecureString ([Guid]::NewGuid().ToString().Substring(1,10)) -AsPlainText -Force
$pscredentials = New-Object System.Management.Automation.PSCredential("vmadmin", $clientSecret)
New-AzVm -Name myVm1234 -Credential $pscredentials -WhatIf
$vm = New-AzVm -Name myVm1234 -Credential $pscredentials
$vm

#Cleanup
Remove-AzureRmResourceGroup -ResourceId $vm.ResourceGroupId -Force