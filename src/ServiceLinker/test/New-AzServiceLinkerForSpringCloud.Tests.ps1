if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerForSpringCloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerForSpringCloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerForSpringCloud' {
    # skip because the test requires user token
    It 'CreateExpanded' -skip { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.keyvaultId
        $authInfo = New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject
        $newLinker = New-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup-ServiceName $env.spring -AppName $env.springApp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForSpringCloud -ResourceGroupName $env.resourceGroup -ServiceName $env.spring -AppName $env.springApp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true

    }
}
