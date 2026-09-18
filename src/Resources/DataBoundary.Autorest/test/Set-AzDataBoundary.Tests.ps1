if(($null -eq $TestName) -or ($TestName -contains 'Set-AzDataBoundary'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Set-AzDataBoundary.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Set-AzDataBoundary' {
    It 'Put' {
        { 
            $dataBoundary = "EU"
            $default = "default"
            $exception = Set-AzDataBoundary -DataBoundary $dataBoundary -DefaultProfile $default
            $exception -contains "does not have authorization to perform action" | Should -Be True
            $exception -contains "or the scope is invalid. If access was recently granted, please refresh your credentials." | Should -Be True
        } | Should -Throw 
    }
}
