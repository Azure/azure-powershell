if(($null -eq $TestName) -or ($TestName -contains 'Limit-AzMongoDBProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Limit-AzMongoDBProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Limit-AzMongoDBProject' {
    It 'Limit' {
        {
            $result = Limit-AzMongoDBProject -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -ProjectName $env.ProjectName
            $result.Type | Should -Not -BeNullOrEmpty
            $result.Maximum | Should -Not -BeNullOrEmpty
        } | Should -Not -Throw
    }

    It 'LimitViaIdentityOrganization' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'LimitViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
