if (($null -eq $TestName) -or ($TestName -contains 'Get-AzDevCenterAdminAttachedNetwork')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
    $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDevCenterAdminAttachedNetwork.Recording.json'
    $currentPath = $PSScriptRoot
    while (-not $mockingPath) {
        $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
        $currentPath = Split-Path -Path $currentPath -Parent
    }
    . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDevCenterAdminAttachedNetwork' {
    It 'List' {
        $listOfAttachedNetworks = Get-AzDevCenterAdminAttachedNetwork -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
        
        $listOfAttachedNetworks.Count | Should -BeGreaterOrEqual 2
    }

    It 'Get1' {
        $attachedNetwork = Get-AzDevCenterAdminAttachedNetwork -ConnectionName $env.attachedNetworkName -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        
        $attachedNetwork.Name | Should -Be $env.attachedNetworkName
        $attachedNetwork.NetworkConnectionId | Should -Be $env.networkConnectionId
        $attachedNetwork.DomainJoinType | Should -Be "AzureADJoin"
    }

    It 'Get' {
        $attachedNetwork = Get-AzDevCenterAdminAttachedNetwork -ConnectionName $env.attachedNetworkName -ProjectName $env.projectName -ResourceGroupName $env.resourceGroup
    
        $attachedNetwork.Name | Should -Be $env.attachedNetworkName
        $attachedNetwork.NetworkConnectionId | Should -Be $env.networkConnectionId
        $attachedNetwork.DomainJoinType | Should -Be "AzureADJoin"
    }

    It 'List1' {
        $listOfAttachedNetworks = Get-AzDevCenterAdminAttachedNetwork -ResourceGroupName $env.resourceGroup -DevCenterName $env.devCenterName
        
        $listOfAttachedNetworks.Count | Should -BeGreaterOrEqual 2
    }
}
