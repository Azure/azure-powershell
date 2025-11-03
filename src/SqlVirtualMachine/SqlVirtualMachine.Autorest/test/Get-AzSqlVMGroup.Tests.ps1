if (($null -eq $TestName) -or ($TestName -contains 'Get-AzSqlVMGroup')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzSqlVMGroup.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzSqlVMGroup' {
    It 'List1' {
        $groups = Get-AzSqlVMGroup

        $groups.Count | Should -Be 1
        $groups.Name | Should -Be $env.SqlVMGroupName
        $groups.SqlImageOffer | Should -Be $env.SqlImageOffer
        $groups.SqlImageSku | Should -Be $env.SqlImageSku
        $groups.WsfcDomainProfileClusterBootstrapAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterOperatorAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterSubnetType | Should -Be 'MultiSubnet'
        $groups.WsfcDomainProfileDomainFqdn | Should -Be $env.DomainFqdn
        $groups.WsfcDomainProfileSqlServiceAccount | Should -Be 'azureadmin'
        $groups.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl

    }

    It 'Get' {
        $groups = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName -Name $env.SqlVMGroupName

        $groups.Count | Should -Be 1
        $groups.Name | Should -Be $env.SqlVMGroupName
        $groups.SqlImageOffer | Should -Be $env.SqlImageOffer
        $groups.SqlImageSku | Should -Be $env.SqlImageSku
        $groups.WsfcDomainProfileClusterBootstrapAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterOperatorAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterSubnetType | Should -Be 'MultiSubnet'
        $groups.WsfcDomainProfileDomainFqdn | Should -Be $env.DomainFqdn
        $groups.WsfcDomainProfileSqlServiceAccount | Should -Be 'azureadmin'
        $groups.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl
    }

    It 'List' {
        $groups = Get-AzSqlVMGroup -ResourceGroupName $env.ResourceGroupName

        $groups.Count | Should -Be 1
        $groups.Name | Should -Be $env.SqlVMGroupName
        $groups.SqlImageOffer | Should -Be $env.SqlImageOffer
        $groups.SqlImageSku | Should -Be $env.SqlImageSku
        $groups.WsfcDomainProfileClusterBootstrapAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterOperatorAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterSubnetType | Should -Be 'MultiSubnet'
        $groups.WsfcDomainProfileDomainFqdn | Should -Be $env.DomainFqdn
        $groups.WsfcDomainProfileSqlServiceAccount | Should -Be 'azureadmin'
        $groups.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl
    }

    It 'GetViaIdentity' {
        $group1 = [Microsoft.Azure.PowerShell.Cmdlets.SqlVirtualMachine.Models.SqlVirtualMachineGroup]@{Id = $env.SqlVMGroupId }
        $groups = Get-AzSqlVMGroup  -InputObject $group1

        $groups.Count | Should -Be 1
        $groups.Name | Should -Be $env.SqlVMGroupName
        $groups.SqlImageOffer | Should -Be $env.SqlImageOffer
        $groups.SqlImageSku | Should -Be $env.SqlImageSku
        $groups.WsfcDomainProfileClusterBootstrapAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterOperatorAccount | Should -Be 'azureadmin@corp.azpstestsql.com'
        $groups.WsfcDomainProfileClusterSubnetType | Should -Be 'MultiSubnet'
        $groups.WsfcDomainProfileDomainFqdn | Should -Be $env.DomainFqdn
        $groups.WsfcDomainProfileSqlServiceAccount | Should -Be 'azureadmin'
        $groups.WsfcDomainProfileStorageAccountUrl | Should -Be $env.StorageAccountUrl
    }
}
