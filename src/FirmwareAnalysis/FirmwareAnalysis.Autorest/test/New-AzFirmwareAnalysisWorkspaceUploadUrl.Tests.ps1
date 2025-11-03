if(($null -eq $TestName) -or ($TestName -contains 'New-AzFirmwareAnalysisWorkspaceUploadUrl'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzFirmwareAnalysisWorkspaceUploadUrl.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzFirmwareAnalysisWorkspaceUploadUrl' {
    It 'Generate' {
        { 
            $config = New-AzFirmwareAnalysisWorkspaceUploadUrl -ResourceGroupName $env.ResourceGroup -WorkspaceName $env.WorkspaceName -FirmwareId (New-Guid).ToString()
            $config.Count | Should -BeGreaterThan 0
        } | Should -Not -Throw
    }
}
