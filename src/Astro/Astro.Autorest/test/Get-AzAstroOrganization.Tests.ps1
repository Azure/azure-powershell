if(($null -eq $TestName) -or ($TestName -contains 'Get-AzAstroOrganization'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzAstroOrganization.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzAstroOrganization' {
    It 'List' {
        { 
            $result = Get-AzAstroOrganization -ResourceGroupName $env.ResourceGroupName
            $result.Count | Should -BeGreaterThan 0 
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            $org = Get-AzAstroOrganization -ResourceGroupName $env.ResourceGroupName -Name UT.1.test
            $org.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }

    It 'List1' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
