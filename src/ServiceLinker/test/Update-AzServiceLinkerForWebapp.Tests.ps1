if(($null -eq $TestName) -or ($TestName -contains 'Update-AzServiceLinkerForWebapp'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzServiceLinkerForWebapp.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzServiceLinkerForWebapp' {
    It 'UpdateExpanded' {
        $linker = Get-AzServiceLinkerForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp -Name $env.preparedLinker

        $updateLinker = Update-AzServiceLinkerForWebapp -ResourceGroupName $env.resourceGroup -Webapp $env.preparedWebapp -LinkerName $linker.Name -TargetService $linker.TargetService -AuthInfo $linker.AuthInfo -ClientType dotnet
        $updateLinker.ClientType | Should -Be dotnet
    }

    It 'UpdateViaIdentityExpanded' -skip {
        { throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
