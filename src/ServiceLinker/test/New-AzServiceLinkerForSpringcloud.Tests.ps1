if(($null -eq $TestName) -or ($TestName -contains 'New-AzServiceLinkerForSpringcloud'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzServiceLinkerForSpringcloud.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzServiceLinkerForSpringcloud' {

    It 'CreateExpanded' { 
        $target = New-AzServiceLinkerAzureResourceObject -Id $env.keyvaultId
        $authInfo = New-AzServiceLinkerSystemAssignedIdentityAuthInfoObject
        $newLinker = New-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup-Service $env.spring -App $env.springApp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo
        # assert the linker create successfully
        $linkers = Get-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp
        $linkers.Name.Contains($env.newLinker) | Should -Be $true

        $updateLinker = Update-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.newLinker -TargetService $target -AuthInfo $authInfo -ClientType dotnet
        
        $null = Remove-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp -LinkerName $env.newLinker
        
        # assert the linker delete successfully
        $linkers = Get-AzServiceLinkerForSpringcloud -ResourceGroupName $env.resourceGroup -Service $env.spring -App $env.springApp
        if($linkers -ne $null){
            $linkers.Name.Contains($env.newLinker) | Should -Be $false
        }
    }
}
