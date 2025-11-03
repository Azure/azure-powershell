if (($null -eq $TestName) -or ($TestName -contains 'Remove-AzSqlVMGroup')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzSqlVMGroup.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzSqlVMGroup' {
    It 'Delete' {
        $Offer = $env.SqlImageOffer
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "removeGroup1"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        { Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName } | Should -Throw -ExpectedMessage "[ResourceNotFound] : The Resource 'Microsoft.SqlVirtualMachine/SqlVirtualMachineGroups/removeGroup1' under resource group 'sqlvmtest-gp' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix"
    }

    It 'DeleteViaIdentity' {
        $Offer = $env.SqlImageOffer
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "removeGroup2"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType
        Remove-AzSqlVMGroup -InputObject $group

        { Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName } | Should -Throw -ExpectedMessage "[ResourceNotFound] : The Resource 'Microsoft.SqlVirtualMachine/SqlVirtualMachineGroups/removeGroup2' under resource group 'sqlvmtest-gp' was not found. For more details please go to https://aka.ms/ARMResourceNotFoundFix"
    }
}
