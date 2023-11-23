if(($null -eq $TestName) -or ($TestName -contains 'Az.LoadTesting'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Az.LoadTesting.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzLoad' {
    It 'Create with MI' {
        $name = $env.loadTestResource1
        $tags = @{"tag1"="value1"}
        $userAssigned = @{$env.identityid1=@{};$env.identityid2=@{}}
        $identityType = "SystemAssigned, UserAssigned"

        $res = New-AzLoad -Name $name -ResourceGroupName $env.resourceGroup -Location $env.location -IdentityType $identityType -IdentityUserAssigned $userAssigned -Tag $tags
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag['tag1'] | Should -Be 'value1'
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 2
        $res.EncryptionIdentityType | Should -BeNullOrEmpty
        $res.EncryptionIdentityResourceId | Should -BeNullOrEmpty
        $res.EncryptionKey | Should -BeNullOrEmpty
    }

    It 'Create with CMK' {
        $name = $env.loadTestResource2
        $identityType = "UserAssigned"
        $cmkKey = $env.cmkkeyid1
        $cmkIdentity = $env.identityid1

        $res = New-AzLoad -Name $name -ResourceGroupName $env.resourceGroup -Location $env.location -EncryptionKey $cmkKey -EncryptionIdentity $cmkIdentity
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag.Keys | Should -HaveCount 0
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 1
        $res.EncryptionIdentityType | Should -Be $identityType
        $res.EncryptionIdentityResourceId | Should -Be $cmkIdentity
        $res.EncryptionKey | Should -Be $cmkKey
    }
}

Describe 'Get-AzLoad' {
    It 'Get CMK disabled resource' {
        $name = $env.loadTestResource1
        $identityType = "SystemAssigned, UserAssigned"

        $res = Get-AzLoad -Name $name -ResourceGroupName $env.resourceGroup
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag['tag1'] | Should -Be 'value1'
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 2
        $res.EncryptionIdentityType | Should -BeNullOrEmpty
        $res.EncryptionIdentityResourceId | Should -BeNullOrEmpty
        $res.EncryptionKey | Should -BeNullOrEmpty
    }

    It 'Get CMK enabled resource' {
        $name = $env.loadTestResource2
        $identityType = "UserAssigned"
        $cmkKey = $env.cmkkeyid1
        $cmkIdentity = $env.identityid1

        $res = Get-AzLoad -Name $name -ResourceGroupName $env.resourceGroup
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag.Keys | Should -HaveCount 0
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 1
        $res.EncryptionIdentityType | Should -Be $identityType
        $res.EncryptionIdentityResourceId | Should -Be $cmkIdentity
        $res.EncryptionKey | Should -Be $cmkKey
    }
}

Describe 'Update-AzLoad (Recorded)' {
    It 'Remove a Managed Identity' {
        $name = $env.loadTestResource1
        $userAssigned = @{$env.identityid1=@{};$env.identityid2=$null}
        $identityType = "UserAssigned"

        $res = Update-AzLoad -Name $name -ResourceGroupName $env.resourceGroup -IdentityType $identityType -IdentityUserAssigned $userAssigned
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag['tag1'] | Should -Be 'value1'
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 1
        $res.EncryptionIdentityType | Should -BeNullOrEmpty
        $res.EncryptionIdentityResourceId | Should -BeNullOrEmpty
        $res.EncryptionKey | Should -BeNullOrEmpty
    }

    It 'Update CMK key' {
        $name = $env.loadTestResource2
        $identityType = "SystemAssigned, UserAssigned"
        $encryptionIdentityType = "UserAssigned"
        $cmkKey = $env.cmkkeyid2
        $cmkIdentity = $env.identityid1

        $res = Update-AzLoad -Name $name -ResourceGroupName $env.resourceGroup -IdentityType $identityType -EncryptionKey $cmkKey
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag.Keys | Should -HaveCount 0
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 1
        $res.EncryptionIdentityType | Should -Be $encryptionIdentityType
        $res.EncryptionIdentityResourceId | Should -Be $cmkIdentity
        $res.EncryptionKey | Should -Be $cmkKey
    }
}

Describe 'Update-AzLoad (LiveOnly)' -Tag 'LiveOnly' {
    It 'Update CMK identity' {
        $name = $env.loadTestResource2
        $identityType = "SystemAssigned, UserAssigned"
        $cmkKey = $env.cmkkeyid2
        $cmkIdentity = "SystemAssigned"

        $res = Get-AzLoad -Name $name -ResourceGroupName $env.resourceGroup
        Install-Module Az.KeyVault -RequiredVersion 2.0.0 -Force
        Import-Module -Name Az.KeyVault
        Set-AzKeyVaultAccessPolicy -VaultName $env.pwshKeyVault -ResourceGroupName $env.resourceGroup -ObjectId $res.IdentityPrincipalId -PermissionsToKeys get,unwrapkey,wrapkey -BypassObjectIdValidation

        $res = Update-AzLoad -Name $name -ResourceGroupName $env.resourceGroup -EncryptionIdentity $cmkIdentity
        $res.Name | Should -Be $name
        $res.ResourceGroupName | Should -Be $env.resourceGroup
        $res.Location | Should -Be $env.location
        $res.Id | Should -Not -BeNullOrEmpty
        $res.DataPlaneUri | Should -Not -BeNullOrEmpty
        $res.Tag | Should -Not -BeNullOrEmpty
        $res.Tag.Keys | Should -HaveCount 0
        $res.IdentityType | Should -Be $identityType
        $res.IdentityUserAssignedIdentity | Should -Not -BeNullOrEmpty
        $res.IdentityUserAssignedIdentity.Keys | Should -HaveCount 1
        $res.EncryptionIdentityType | Should -Be $cmkIdentity
        $res.EncryptionIdentityResourceId | Should -BeNullOrEmpty
        $res.EncryptionKey | Should -Be $cmkKey
    }
}

Describe 'Remove-AzLoad' {
    It 'Delete resource' {

        $name = $env.loadTestResource1
        Remove-AzLoad -Name $name -ResourceGroupName $env.resourceGroup

        $name = $env.loadTestResource2
        Remove-AzLoad -Name $name -ResourceGroupName $env.resourceGroup
    }
}
