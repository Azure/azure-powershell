if(($null -eq $TestName) -or ($TestName -contains 'New-AzStorageActionTaskPreviewKeyValuePropertiesObject'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzStorageActionTaskPreviewKeyValuePropertiesObject.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzStorageActionTaskPreviewKeyValuePropertiesObject' {
    It '__AllParameterSets' {
        {
            New-AzStorageActionTaskPreviewKeyValuePropertiesObject -Key "Etag" -Value "0x6FB67175454D36D"
        } | Should -Not -Throw
    }
}
