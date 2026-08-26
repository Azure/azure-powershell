if(($null -eq $TestName) -or ($TestName -contains 'Add-AzDocumentDBMongoClusterIdentity'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Add-AzDocumentDBMongoClusterIdentity.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Add-AzDocumentDBMongoClusterIdentity' {
    BeforeAll {
        $rg = $env.identityRg
        $cluster = $env.identityCluster
        $loc = $env.location
        # Pre-provisioned shared user-assigned identities, referenced by id so this
        # scenario only calls Az.DocumentDB cmdlets.
        $script:mi1Id = $env.sharedMi1Id
        $script:mi2Id = $env.sharedMi2Id
        if ($TestMode -ne 'playback') { New-AzResourceGroup -Name $rg -Location $loc | Out-Null }
        # Create the cluster with the first user-assigned identity.
        New-DocumentDBTestCluster -ResourceGroupName $rg -Name $cluster -Location $loc -UserAssignedIdentity $script:mi1Id | Out-Null
    }
    AfterAll {
        if ($TestMode -ne 'playback') { Remove-AzResourceGroup -Name $rg -ErrorAction SilentlyContinue | Out-Null }
    }

    It 'Identity assign/show/list/remove' {
        # The cluster starts with the first identity.
        $show = Get-AzDocumentDBMongoClusterIdentity -Name $cluster -ResourceGroupName $rg
        $show.Type | Should -Be 'UserAssigned'
        @($show.UserAssignedIdentity.Keys).Count | Should -Be 1

        # A second identity can be assigned once the cluster already has one; assign merges.
        $assigned = Add-AzDocumentDBMongoClusterIdentity -Name $cluster -ResourceGroupName $rg -UserAssignedIdentity $script:mi2Id
        $assigned.Type | Should -Be 'UserAssigned'
        @($assigned.UserAssignedIdentity.Keys).Count | Should -Be 2
        Wait-DocumentDBClusterSucceeded -ResourceGroupName $rg -Name $cluster | Out-Null

        # 'Get' returns the cluster's identity block (both identities).
        $list = Get-AzDocumentDBMongoClusterIdentity -Name $cluster -ResourceGroupName $rg
        @($list.UserAssignedIdentity.Keys).Count | Should -Be 2

        # Remove the second identity; only the first remains afterwards.
        $removed = Remove-AzDocumentDBMongoClusterIdentity -Name $cluster -ResourceGroupName $rg -UserAssignedIdentity $script:mi2Id
        @($removed.UserAssignedIdentity.Keys).Count | Should -Be 1
    }
}
