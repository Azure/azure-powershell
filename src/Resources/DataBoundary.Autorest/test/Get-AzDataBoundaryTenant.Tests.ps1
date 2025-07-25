if(($null -eq $TestName) -or ($TestName -contains 'Get-AzDataBoundaryTenant'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzDataBoundaryTenant.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzDataBoundaryTenant' {
    It 'Get' {
        {
            $default = "default"
            $boundaryData = Get-AzDataBoundaryTenant -DefaultProfile $default
            $boundaryData.DataBoundary | Should -Be "Global"
            $boundaryData.ProvisioningState | Should -Be "Succeeded"
        } | Should -Not -Throw
    }
}
