if(($null -eq $TestName) -or ($TestName -contains 'New-AzMongoDBProject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzMongoDBProject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzMongoDBProject' {
    It 'CreateExpanded' {
        {
            $result = New-AzMongoDBProject -ResourceGroupName $env.ProjectResourceGroupName -OrganizationName $env.OrganizationName -Name $env.NewProjectName
            $result.ProvisioningState | Should -Be 'Succeeded'
            $result.ProjectName | Should -Be $env.NewProjectName
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
}
