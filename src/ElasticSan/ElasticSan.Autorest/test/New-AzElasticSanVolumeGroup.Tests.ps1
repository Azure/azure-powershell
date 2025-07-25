if(($null -eq $TestName) -or ($TestName -contains 'New-AzElasticSanVolumeGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzElasticSanVolumeGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzElasticSanVolumeGroup' {
    It 'CreateExpanded' {
        $vnetRule1 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId1 -Action "Allow"
        $vnetRule2 = New-AzElasticSanVirtualNetworkRuleObject -VirtualNetworkResourceId $env.vnetResourceId2 -Action "Allow"
        $volGroupName = 'testvolgroup' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName -ProtocolType 'Iscsi' -NetworkAclsVirtualNetworkRule $vnetRule1,$vnetRule2
        $volGroup.Name | Should -Be $volGroupName
        $volGroup.ProtocolType | Should -Be "Iscsi"
        $volGroup.NetworkAclsVirtualNetworkRule.Count | Should -Be 2
        $volGroup.EnforceDataIntegrityCheckForIscsi | Should -Be $true

        $volGroupName2 = 'testvolgroup2' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName2 -ProtocolType 'Iscsi' -IdentityType 'SystemAssigned' -Encryption EncryptionAtRestWithPlatformKey -EnforceDataIntegrityCheckForIscsi $false
        $volGroup.Name | Should -Be $volGroupName2
        $volGroup.Encryption | Should -Be "EncryptionAtRestWithPlatformKey"
        $volGroup.ProtocolType | Should -Be "Iscsi"
        $volGroup.IdentityType | Should -Be "SystemAssigned"
        $volGroup.EnforceDataIntegrityCheckForIscsi | Should -Be $false

        $volGroupName3 = 'testvolgroup3' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName3 -IdentityType 'UserAssigned'-IdentityUserAssignedIdentity $env.Useridentity.Id -Encryption EncryptionAtRestWithCustomerManagedKey -KeyName $env.Keyname -KeyVaultUri $env.KeyvaultUri -EncryptionUserAssignedIdentity $env.Useridentity.Id -ProtocolType Iscsi
        $volGroup.Name | Should -Be $volGroupName3
        $volGroup.Encryption | Should -Be "EncryptionAtRestWithCustomerManagedKey"
        $volGroup.IdentityType | Should -Be "UserAssigned"
        $volGroup.IdentityUserAssignedIdentity | Should -Not -Be $null 
        $volGroup.KeyVaultPropertyKeyName | Should -Be $env.Keyname
        $volGroup.KeyVaultPropertyKeyVaultUri | Should -Be $env.KeyvaultUri
        $volGroup.ProtocolType | Should -Be "iSCSI"

        $volGroupName4 = 'testvolgroup4' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName4 -EnforceDataIntegrityCheckForIscsi $true 
        $volGroup.Name | Should -Be $volGroupName4
        $volGroup.EnforceDataIntegrityCheckForIscsi | Should -Be $true

        $volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName3 -Encryption EncryptionAtRestWithPlatformKey
        $volGroup.IdentityType | Should -Be "UserAssigned"
        $volGroup.Encryption | Should -Be "EncryptionAtRestWithPlatformKey"
        $volGroup.ProtocolType | Should -Be "Iscsi"

        $volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName3 -IdentityType 'SystemAssigned' -EnforceDataIntegrityCheckForIscsi $false
        $volGroup.IdentityType | Should -Be "SystemAssigned"
        $volGroup.EnforceDataIntegrityCheckForIscsi | Should -Be $false

        $volGroup = Update-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName3 -EnforceDataIntegrityCheckForIscsi $true
        $volGroup.EnforceDataIntegrityCheckForIscsi | Should -Be $true
    }
}
