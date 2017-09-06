Import-Module .\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Profile\AzureRM.Profile.psd1
Import-Module .\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Resources\AzureRM.Resources.psd1
Import-Module .\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Network\AzureRM.Network.psd1
Import-Module .\..\..\src\Package\Debug\ResourceManager\AzureResourceManager\AzureRM.Compute\AzureRM.Compute.psd1
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

# $vm = New-AzVm
# $vm = New-AzVm -Credential $vmCredential
$vm = New-AzVm -Credential $vmCredential

$vm

# clean-up
Remove-AzureRmResourceGroup -ResourceId $vm.resourceId