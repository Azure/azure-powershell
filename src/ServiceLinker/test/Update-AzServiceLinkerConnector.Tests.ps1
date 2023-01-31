if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceLinkerConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceLinkerConnector' {
    It 'UpdateExpanded' -skip {
        $linker = Get-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.containerApp -Name $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.location -Name $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }

}
