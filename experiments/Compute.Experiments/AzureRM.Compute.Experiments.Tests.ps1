$build = Resolve-Path "..\build\"
$out = Join-Path $build "AzureRM.Compute.Experiments\"
Copy-Item .\AzureRM.Compute.Experiments.psd1 $out
Copy-Item .\AzureRM.Compute.Experiments.psm1 $out

$env:PSModulePath = $env:PSModulePath + ";" + $build.ToString()

# Login
$credentials = Get-Content -Path "C:\Users\sergey\Desktop\php-test.json" | ConvertFrom-Json
$clientSecret = ConvertTo-SecureString $credentials.clientSecret -AsPlainText -Force
$pscredentials = New-Object System.Management.Automation.PSCredential($credentials.applicationId, $clientSecret)
Login-AzureRmAccount -ServicePrincipal -Credential $pscredentials -TenantId $credentials.tenantId | Out-Null

$vmComputerPassword = $credentials.vmPassword;
$vmComputerUser = $credentials.vmUser;
$password = ConvertTo-SecureString $vmComputerPassword -AsPlainText -Force;
$vmCredential = New-Object System.Management.Automation.PSCredential ($vmComputerUser, $password);

Describe 'New-AzVm' {
    It 'WhatIf' {
        $result = New-AzVm -Name MyVM -Credential $vmCredential -WhatIf
    }
    It 'Create Windows VM' {
        Remove-AzureRmResourceGroup -Name Something1 -Force

        $result = New-AzVm -Name MyVMA1 -Credential $vmCredential -ResourceGroupName Something1 -Verbose

        $result.Name | Should Be MyVMA1
    }
    It 'Create Linux VM' {
        $context = Get-AzureRmContext
        $result = New-AzVm `
            -Name X2 `
            -Credential $vmCredential `
            -Location westus2 `
            -ResourceGroupName Something1 `
            -AzureRmContext $context `
            -ImageName UbuntuLTS `
            -Verbose
        $result.Name | Should Be X2
    }
    It 'Create Another VM, share VirtualNetwork' {
        $result = New-AzVm `
            -Name X3 `
            -Credential $vmCredential `
            -ResourceGroupName Something1 `
            -VirtualNetworkName X2 `
            -SubnetName X2 `
            -AzureRmContext $context `
            -ImageName UbuntuLTS `
            -Verbose

        $result.Name | Should Be X3
    }
    It 'Create Linux VM AsJob' {
        Remove-AzureRmResourceGroup -Name MyVMA3 -Force

        $job = New-AzVm -Name MyVMA3 -Credential $vmCredential -AsJob -ImageName UbuntuLTS -Verbose
        $result = Receive-Job $job -Wait -Verbose

        $result.Name | Should Be MyVMA3
    }
}
