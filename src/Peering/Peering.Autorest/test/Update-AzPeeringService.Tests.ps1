if(($null -eq $TestName) -or ($TestName -contains 'Update-AzPeeringService'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzPeeringService.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzPeeringService' {
    It 'UpdateExpanded' {
        {
            $tags=@{hello='world'}
            $peeringService = Update-AzPeeringService -Name DRTestInterCloud -ResourceGroupName DemoRG -Tag $tags
            $peeringService.Name | Should -Be "DRTestInterCloud"
        } | Should -Not -Throw
    }
}
