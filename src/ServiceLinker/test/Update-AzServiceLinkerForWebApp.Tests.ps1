if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceLinkerForWebApp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerForWebApp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceLinkerForWebApp' {
    It 'UpdateExpanded' {
        $linker = Get-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp -Name $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerForWebApp -ResourceGroupName $env.resourceGroup -WebApp $env.preparedWebApp -LinkerName $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }

}
