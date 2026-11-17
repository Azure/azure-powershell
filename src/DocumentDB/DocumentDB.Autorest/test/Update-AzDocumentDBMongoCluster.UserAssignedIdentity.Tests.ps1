if(($null -eq $TestName) -or
   ($TestName -contains 'Update-AzDocumentDBMongoCluster.UserAssignedIdentity') -or
   ($TestName -contains 'Update-AzDocumentDBMongoCluster identity collection construction') -or
   ($TestName -contains 'Update-AzDocumentDBMongoCluster identity') -or
   ($TestName -contains 'updates identities through the cluster object model'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzDocumentDBMongoCluster.UserAssignedIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzDocumentDBMongoCluster identity collection construction' {
    BeforeAll {
        $identityId = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/test-rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/test-identity'
    }

    It 'constructs the first identity collection when the property is <state>' -TestCases @(
        @{ state = 'absent'; clusterObject = [PSCustomObject]@{} }
        @{ state = 'null'; clusterObject = [PSCustomObject]@{ IdentityUserAssignedIdentity = $null } }
    ) {
        param($clusterObject)

        $identityIds = @()
        $identityProperty = $clusterObject.PSObject.Properties['IdentityUserAssignedIdentity']
        if (($null -ne $identityProperty) -and ($null -ne $identityProperty.Value)) {
            $identityIds += @($identityProperty.Value.Keys)
        }
        if ($identityId -notin $identityIds) {
            $identityIds += $identityId
        }

        @($identityIds).Count | Should -Be 1
        $identityIds | Should -Contain $identityId
    }

    It 'does not add a duplicate identity' {
        $userAssignedIdentities = @{}
        $userAssignedIdentities[$identityId] = @{}
        $clusterObject = [PSCustomObject]@{ IdentityUserAssignedIdentity = $userAssignedIdentities }
        $identityIds = @()
        $identityProperty = $clusterObject.PSObject.Properties['IdentityUserAssignedIdentity']
        if (($null -ne $identityProperty) -and ($null -ne $identityProperty.Value)) {
            $identityIds += @($identityProperty.Value.Keys)
        }
        if ($identityId -notin $identityIds) {
            $identityIds += $identityId
        }

        @($identityIds).Count | Should -Be 1
        $identityIds | Should -Contain $identityId
    }

    It 'constructs an empty collection when removing the last identity' {
        $userAssignedIdentities = @{}
        $userAssignedIdentities[$identityId] = @{}
        $clusterObject = [PSCustomObject]@{ IdentityUserAssignedIdentity = $userAssignedIdentities }
        $identityIds = @($clusterObject.IdentityUserAssignedIdentity.Keys | Where-Object { $_ -ne $identityId })

        @($identityIds).Count | Should -Be 0
    }
}

Describe 'Update-AzDocumentDBMongoCluster identity' {
    BeforeAll {
        $rg = $env.identityRg
        $cluster = $env.identityCluster
        $loc = $env.location
        $script:mi1Id = $env.sharedMi1Id
        $script:mi2Id = $env.sharedMi2Id
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc -UserAssignedIdentity $script:mi1Id | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'updates identities through the cluster object model' {
        $clusterObject = Get-AzDocumentDBMongoCluster -Name $cluster -ResourceGroupName $rg
        $clusterObject.IdentityType | Should -Be 'UserAssigned'
        @($clusterObject.IdentityUserAssignedIdentity.Keys).Count | Should -Be 1

        $identityIds = @()
        $identityProperty = $clusterObject.PSObject.Properties['IdentityUserAssignedIdentity']
        if (($null -ne $identityProperty) -and ($null -ne $identityProperty.Value)) {
            $identityIds += @($identityProperty.Value.Keys)
        }
        if ($script:mi2Id -notin $identityIds) {
            $identityIds += $script:mi2Id
        }
        $updated = $clusterObject | Update-AzDocumentDBMongoCluster -UserAssignedIdentity $identityIds
        Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster | Out-Null

        @($updated.IdentityUserAssignedIdentity.Keys).Count | Should -Be 2
        @($updated.IdentityUserAssignedIdentity.Keys) | Should -Contain $script:mi1Id
        @($updated.IdentityUserAssignedIdentity.Keys) | Should -Contain $script:mi2Id

        $identityIds = @($updated.IdentityUserAssignedIdentity.Keys | Where-Object { $_ -ne $script:mi2Id })
        $updated = $updated | Update-AzDocumentDBMongoCluster -UserAssignedIdentity $identityIds

        @($updated.IdentityUserAssignedIdentity.Keys).Count | Should -Be 1
        @($updated.IdentityUserAssignedIdentity.Keys) | Should -Contain $script:mi1Id
    }
}
