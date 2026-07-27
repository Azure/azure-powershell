if(($null -eq $TestName) -or ($TestName -contains 'New-AzMongoDBCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMongoDBCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMongoDBCluster' {
    It 'CreateExpanded' {
        {
            # Create a dedicated project to avoid FREE-tier limit (1 per project)
            New-AzMongoDBProject -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -Name $env.ClusterTestProjectName
            $result = New-AzMongoDBCluster -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -ProjectName $env.ClusterTestProjectName -Name $env.NewClusterName -ClusterTier $env.ClusterTier -RegionName $env.RegionName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.ClusterName | Should -Be $env.NewClusterName
            $result.Tier | Should -Be $env.ClusterTier
            $result.RegionName | Should -Be $env.RegionName
        } | Should -Not -Throw
    }

    It 'CreateViaJsonString' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaJsonFilePath' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityOrganizationExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'CreateViaIdentityProjectExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
