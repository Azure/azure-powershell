if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerConnector'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerConnector.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerConnector' {
    It 'New local storage connection' -skip {
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.postgresqId
        $authInfo = New-AzServiceLinkerSecretAuthInfoObject
        $newConnector = New-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.location -Name $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $connectors = Get-AzServiceLinkerConnector -ResourceGroupName $env.resourceGroup -Location $env.location
        $connectors.Name.Contains($env.newConnector) | Should -Be $true
    }
}
