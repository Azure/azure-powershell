if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzElasticSanVolumeGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzElasticSanVolumeGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzElasticSanVolumeGroup' {
    It 'Delete' {
        $volGroupName = 'testvolgroup5' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName 
        Remove-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName
        $volGroupList = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1
        $volGroupList.Name | Should -Not -Contain $volGroupName
        
        # Following is to test elasticsan volume group softdelete and restore flow
        $volGroupName = 'testvolgroup6' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName -DeleteRetentionPolicyRetentionPeriodDay 7 -DeleteRetentionPolicyState Enabled
        $volGroup.Name | Should -Be $volGroupName
        $volGroup.DeleteRetentionPolicyRetentionPeriodDay | Should -Be 7
        $volGroup.DeleteRetentionPolicyState | Should -Be "Enabled"

        $volName = "testvol123" + $env.RandomString
        $volume = New-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $volGroupName -Name $volName -SizeGib 100
        $volume.Name | Should -Be $volName
        $volume.SizeGiB | Should -Be 100
        
        Remove-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName
        
        # listing without '-AccessSoftDeletedResource' should not see the deleted volume group
        $volGroupList = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1
        $volGroupList.Name | Should -Not -Contain $volGroupName

        # listing with '-AccessSoftDeletedResource' should be able to see the deleted volume group
        $volGroupList = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -AccessSoftDeletedResource true
        $volGroupList.Name | Should -Contain $volGroupName

        # Recreating the volume group with exact the same options, the volume(s) in the group should still exist
        New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName -DeleteRetentionPolicyRetentionPeriodDay 7 -DeleteRetentionPolicyState Enabled        
        $volumeList = Get-AzElasticSanVolume -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -VolumeGroupName $volGroupName -AccessSoftDeletedResource true
        ($volumeList| ? {$_.Name -like "$($volName)*"} ).count | Should -Not -Be 0

        $volGroupName = 'testvolgroup7' + $env.RandomString
        $volGroup = New-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName -IdentityType 'UserAssigned'-IdentityUserAssignedIdentity $env.Useridentity.Id -Encryption EncryptionAtRestWithCustomerManagedKey -KeyName $env.Keyname -KeyVaultUri $env.KeyvaultUri -EncryptionUserAssignedIdentity $env.Useridentity.Id -ProtocolType Iscsi -DeleteRetentionPolicyRetentionPeriodDay 7 -DeleteRetentionPolicyState Enabled
        $volGroup.Name | Should -Be $volGroupName
        $volGroup.DeleteRetentionPolicyRetentionPeriodDay | Should -Be 7
        $volGroup.DeleteRetentionPolicyState | Should -Be "Enabled"
        
        Remove-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -Name $volGroupName
        
        $volGroupList = Get-AzElasticSanVolumeGroup -ResourceGroupName $env.ResourceGroupName -ElasticSanName $env.ElasticSanName1 -AccessSoftDeletedResource true
        $volGroupList.Name | Should -Contain $volGroupName
    }
}
