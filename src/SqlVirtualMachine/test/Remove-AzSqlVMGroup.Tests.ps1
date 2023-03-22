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
        $Offer = "SQL2022-WS2022"
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "removeGroup1"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType

        Remove-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName

        { Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName } | Should -Throw -ExpectedMessage "The requested resource of type 'Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups' with name 'removeGroup1' was not found."
    }

    It 'DeleteViaIdentity' {
        $Offer = "SQL2022-WS2022"
        $Sku = "Developer"
        $DomainFqdn = 'azpstestsqlvm.com'
        $ClusterSubnetType = 'SingleSubnet'

        $SqlVMGroupName = "removeGroup2"

        $group = New-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName -Location $env.Location -Offer $Offer -Sku $Sku -DomainFqdn  $DomainFqdn -ClusterSubnetType $ClusterSubnetType
        Remove-AzSqlVMGroup -InputObject $group

        { Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $SqlVMGroupName } | Should -Throw -ExpectedMessage "The requested resource of type 'Microsoft.SqlVirtualMachine/sqlVirtualMachineGroups' with name 'removeGroup2' was not found."
    }
}
