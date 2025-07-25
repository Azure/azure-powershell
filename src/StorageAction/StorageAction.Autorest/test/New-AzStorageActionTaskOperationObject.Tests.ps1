if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageActionTaskOperationObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageActionTaskOperationObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageActionTaskOperationObject' {
    It '__AllParameterSets' {
        {
            New-AzStorageActionTaskOperationObject -Name SetBlobTier -Parameter @{"tier"= "Hot"} -OnFailure break -OnSuccess continue
        } | Should -Not -Throw
    }
}
