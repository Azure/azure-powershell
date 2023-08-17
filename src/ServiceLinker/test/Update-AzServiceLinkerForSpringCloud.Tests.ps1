if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceLinkerForSpringCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerForSpringCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceLinkerForSpringCloud' {
    It 'UpdateExpanded' {
        $linker = Get-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp -LinkerName $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp -LinkerName $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }
}
