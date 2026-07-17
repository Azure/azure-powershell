if(($null -eq $TestName) -or ($TestName -contains 'Get-AzMongoDBProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzMongoDBProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzMongoDBProject' {
    It 'List' {
        {
            $result = Get-AzMongoDBProject -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName
            $result.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $result = Get-AzMongoDBProject -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -Name $env.ProjectName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.ProjectName | Should -Be $env.ProjectName
        } | Should -Not -Throw
    }

    It 'GetViaIdentityOrganization' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
