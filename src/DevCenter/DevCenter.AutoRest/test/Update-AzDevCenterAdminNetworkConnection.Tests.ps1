if (($null -eq $TestName) -or ($TestName -contains 'Update-AzDevCenterAdminNetworkConnection')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDevCenterAdminNetworkConnection.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDevCenterAdminNetworkConnection' {
    It 'UpdateExpanded' {
        $networkConnection = Update-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionUpdate -ResourceGroupName $env.resourceGroup -SubnetId $env.SubnetId -DomainPassword $null
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionUpdate
        $networkConnection.SubnetId | Should -Be $env.SubnetId

        $hybridNetworkConnection = Update-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridUpdate -ResourceGroupName $env.resourceGroup -DomainName $env.domainName -DomainUsername $env.domainUsername -SubnetId $env.SubnetId
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridUpdate
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername    
    }

    It 'UpdateViaIdentityExpanded' {
        $networkConnectionInput = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionUpdate

        $networkConnection = Update-AzDevCenterAdminNetworkConnection -InputObject $networkConnectionInput -SubnetId $env.SubnetId -DomainPassword $null
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionUpdate
        $networkConnection.SubnetId | Should -Be $env.SubnetId

        $hybridNetworkConnectionInput = Get-AzDevCenterAdminNetworkConnection -ResourceGroupName $env.resourceGroup -Name $env.networkConnectionHybridUpdate

        $hybridNetworkConnection = Update-AzDevCenterAdminNetworkConnection -InputObject $hybridNetworkConnectionInput -DomainName $env.domainName -DomainUsername $env.domainUsername -SubnetId $env.SubnetId
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridUpdate
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername
    }
}
