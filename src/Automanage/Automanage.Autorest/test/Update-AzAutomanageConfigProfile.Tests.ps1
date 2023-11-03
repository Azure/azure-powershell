if(($null -eq $TestName) -or ($TestName -contains 'Update-AzAutomanageConfigProfile'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzAutomanageConfigProfile.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzAutomanageConfigProfile' {
    # The server responded with a Server Error, Status: InternalServerError
    It 'UpdateExpanded' -skip {
        { 
            Update-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01 -Tag @{"Organization" = "Administration"}
        } | Should -Not -Throw
    }
    # The server responded with a Server Error, Status: InternalServerError
    It 'UpdateViaIdentityExpanded' -skip {
        { 
            $obj = Get-AzAutomanageConfigProfile -ResourceGroupName automangerg -Name confpro-pwsh01
            Update-AzAutomanageConfigProfile -InputObject $obj -Tag @{"Organization" = "Administration"}
        } | Should -Not -Throw
    }
}
