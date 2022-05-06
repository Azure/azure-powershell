if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceLinkerForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceLinkerForSpringcloud' {
    It 'UpdateExpanded' {
        $linker = Get-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }
}
