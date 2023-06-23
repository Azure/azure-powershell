if(($null -eq $TestName) -or ($TestName -contains 'New-AzDevCenterAdminNetworkConnection'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzDevCenterAdminNetworkConnection.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzDevCenterAdminNetworkConnection' {
    It 'CreateExpanded' {
        $networkConnection = New-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionNew -ResourceGroupName $env.resourceGroup -Location $env.location -DomainJoinType $env.aadJoinType -NetworkingResourceGroupName $env.networkingRgName1 -SubnetId $env.SubnetId
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionNew
        $networkConnection.SubnetId | Should -Be $env.SubnetId
        $networkConnection.NetworkingResourceGroupName | Should -Be $env.networkingRgName1
  
        $hybridNetworkConnection = New-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridNew -ResourceGroupName $env.resourceGroup -Location $env.location -DomainJoinType $env.hybridDomainJoinType -DomainName $env.domainName -DomainPassword $env.domainPassword -DomainUsername $env.domainUsername -NetworkingResourceGroupName $env.networkingRgName2 -SubnetId $env.SubnetId
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridNew
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.NetworkingResourceGroupName | Should -Be $env.networkingRgName2
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername
  
  
        }

    It 'Create' {
        $body = @{"Location" = $env.location; "NetworkingResourceGroupName" = $env.networkingRgName3; "SubnetId" = $env.SubnetId; "DomainJoinType" = $env.aadJoinType}
        $networkConnection = New-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionNew2 -ResourceGroupName $env.resourceGroup -Body $body
        $networkConnection.DomainJoinType | Should -Be $env.aadJoinType
        $networkConnection.Name | Should -Be $env.networkConnectionNew2
        $networkConnection.SubnetId | Should -Be $env.SubnetId
        $networkConnection.NetworkingResourceGroupName | Should -Be $env.networkingRgName3

        $body2 = @{"Location" = $env.location; "NetworkingResourceGroupName" = $env.networkingRgName4; "SubnetId" = $env.SubnetId; "DomainJoinType" = $env.hybridDomainJoinType; "DomainName" = $env.domainName; "DomainPassword" = $env.domainPassword; "DomainUsername" = $env.domainUsername}
        $hybridNetworkConnection = New-AzDevCenterAdminNetworkConnection -Name $env.networkConnectionHybridNew2 -ResourceGroupName $env.resourceGroup -Body $body2
        $hybridNetworkConnection.DomainJoinType | Should -Be $env.hybridDomainJoinType
        $hybridNetworkConnection.Name | Should -Be $env.networkConnectionHybridNew2
        $hybridNetworkConnection.SubnetId | Should -Be $env.SubnetId
        $hybridNetworkConnection.NetworkingResourceGroupName | Should -Be $env.networkingRgName4
        $hybridNetworkConnection.DomainName | Should -Be $env.domainName
        $hybridNetworkConnection.DomainUsername | Should -Be $env.domainUsername
    }

}
