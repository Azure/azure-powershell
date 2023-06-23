if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDevCenterAdminNetworkConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDevCenterAdminNetworkConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDevCenterAdminNetworkConnection' {
    It 'UpdateExpanded' {
        $networkConnection = Get-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionSet -ResourceGroupName $env.resourceGroup
        $networkConnectionResourceGroup = $networkConnection.NetworkingResourceGroupName
        $networkConnection = Set-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionSet -ResourceGroupName $env.resourceGroup -Location $env.location -DomainJoinType $env.aadJoinType -SubnetId $env.SubnetId -NetworkingResourceGroupName $networkConnectionResourceGroup
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionSet
        $networkConnection.SubnetId | Should -Be $env.SubnetId
        $networkConnection.NetworkingResourceGroupName | Should -Be $networkConnectionResourceGroup

        $hybridNetworkConnection = Get-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridSet -ResourceGroupName $env.resourceGroup
        $hybridNetworkConnectionResourceGroup = $hybridNetworkConnection.NetworkingResourceGroupName
        $hybridNetworkConnection = Set-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridSet -ResourceGroupName $env.resourceGroup -Location $env.location -NetworkingResourceGroupName $hybridNetworkConnectionResourceGroup -DomainJoinType $env.hybridDomainJoinType -DomainName $env.domainName -DomainPassword $env.domainPassword -DomainUsername $env.domainUsername -SubnetId $env.SubnetId
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridSet
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername    
        $hybridNetworkConnection.NetworkingResourceGroupName | Should -Be $hybridNetworkConnectionResourceGroup

    }

    It 'Update' {
        $networkConnection = Get-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionSet -ResourceGroupName $env.resourceGroup
        $networkConnectionResourceGroup = $networkConnection.NetworkingResourceGroupName
        $body = @{"Location" = $env.location; "SubnetId" = $env.SubnetId; "DomainJoinType" = $env.aadJoinType; "NetworkingResourceGroupName" = $networkConnectionResourceGroup}
        $networkConnection = Set-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionSet -ResourceGroupName $env.resourceGroup -Body $body
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionSet
        $networkConnection.SubnetId | Should -Be $env.SubnetId
        $networkConnection.NetworkingResourceGroupName | Should -Be $networkConnectionResourceGroup

        $hybridNetworkConnection = Get-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridSet -ResourceGroupName $env.resourceGroup
        $hybridNetworkConnectionResourceGroup = $hybridNetworkConnection.NetworkingResourceGroupName
        $body2 = @{"Location" = $env.location; "SubnetId" = $env.SubnetId; "NetworkingResourceGroupName" = $hybridNetworkConnectionResourceGroup; "DomainJoinType" = $env.hybridDomainJoinType; "DomainName" = $env.domainName; "DomainPassword" = $env.domainPassword; "DomainUsername" = $env.domainUsername}
        $hybridNetworkConnection = Set-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridSet -ResourceGroupName $env.resourceGroup -Body $body2
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridSet
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername 
        $hybridNetworkConnection.NetworkingResourceGroupName | Should -Be $hybridNetworkConnectionResourceGroup

    }
}
