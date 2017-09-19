# Import-Module AzureRM.Profile -MinimumVersion 3.3.2
# Import-Module AzureRM.Resources -MinimumVersion 4.3.2
# Import-Module AzureRM.Network -MinimumVersion 4.3.2
# Import-Module AzureRM.Compute -MinimumVersion 3.3.2
Import-Module .\..\..\experiments\Compute.Experiments\AzureRM.Compute.Experiments.psd1

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

$job = New-AzVm -Name MyVMA -Credential $vmCredential -AsJob

$vm = Receive-Job $job

$vm

exit

# $vm = New-AzVm
# $vm = New-AzVm -Credential $vmCredential
$vm = New-AzVm -Name MyVMA -Credential $vmCredential
# $vm = New-AzVm -Name MyVMA

$vm

# clean-up
Remove-AzureRmResourceGroup -ResourceId $vm.ResourceGroupId