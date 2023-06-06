if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzStackHCIVMImage'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzStackHCIVMImage.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzStackHCIVMImage' {
    It 'ByResourceId'  {
        Remove-AzStackHCIVMImage -ResourceId $env.imageResourceId | Should -Not -Throw
    }

    It 'ByName'  {
        Remove-AzStackHCIVMImage -Name $env.ImageName -ResourceGroupName $env.ResourceGroupName | Should -Not -Throw
    }
}
