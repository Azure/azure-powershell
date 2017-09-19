# $build = "..\build\"
# $out = $build + "AzureRM.Compute.Experiments\"
# Copy-Item .\AzureRM.Compute.Experiments.psd1 $out
# Copy-Item .\AzureRM.Compute.Experiments.psm1 $out

$env:PSModulePath = $env:PSModulePath + ";" + $build

# Login
$credentials = Get-Content -Path "C:\Users\sergey\Desktop\php-test.json" | ConvertFrom-Json
$clientSecret = ConvertTo-SecureString $credentials.clientSecret -AsPlainText -Force
$pscredentials = New-Object System.Management.Automation.PSCredential($credentials.applicationId, $clientSecret)
Login-AzureRmAccount -ServicePrincipal -Credential $pscredentials -TenantId $credentials.tenantId | Out-Null

$vmComputerPassword = $credentials.vmPassword;
$vmComputerUser = $credentials.vmUser;
$password = ConvertTo-SecureString $vmComputerPassword -AsPlainText -Force;
$vmCredential = New-Object System.Management.Automation.PSCredential ($vmComputerUser, $password);

New-AzVm -Name MyVM -Credential $vmCredential -WhatIf

# $job = New-AzVm -Name MyVMA -Credential $vmCredential -AsJob
# Receive-Job $job

# exit

# $vm = New-AzVm
# $vm = New-AzVm -Credential $vmCredential
# $vm = New-AzVm -Name MyVMA -Credential $vmCredential
# $vm = New-AzVm -Name MyVMA

$vm

Write-Host "<async>"

$job = New-AzVm -Name MyVMA2 -Credential $vmCredential -AsJob
$vm = Receive-Job $job

$vm

Write-Host "</async>"

# clean-up
Remove-AzureRmResourceGroup -ResourceId $vm.ResourceGroupId