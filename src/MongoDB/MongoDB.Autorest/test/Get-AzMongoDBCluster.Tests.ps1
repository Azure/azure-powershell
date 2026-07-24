if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMongoDBCluster'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMongoDBCluster.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMongoDBCluster' {
    It 'List' {
        {
            $result = Get-AzMongoDBCluster -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -ProjectName $env.ProjectName
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzMongoDBCluster -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -ProjectName $env.ProjectName -Name $env.ClusterName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.ClusterName | Should -Be $env.ClusterName
            $result.State | Should -Be 'IDLE'
        } | Should -Not -Throw
    }

    It 'GetViaIdentityProject' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentityOrganization' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
