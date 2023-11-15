if(($null -eq $TestName) -or ($TestName -contains 'New-AzLabServicesLabPlan'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzLabServicesLabPlan.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

$loadVarsPath = Join-Path $PSScriptRoot '\SetVariables.ps1'
. ($loadVarsPath)

Describe 'New-AzLabServicesLabPlan' {
    It 'Create' {
        New-AzLabServicesLabPlan `
        -Name 'LabPlan-test-powershell' `
        -ResourceGroupName $ENV:ResourceGroupName `
        -Location $ENV:Location `
        -AllowedRegion @($ENV:Location) `
        -DefaultAutoShutdownProfileShutdownOnDisconnect 'Disabled' `
        -DefaultAutoShutdownProfileShutdownOnIdle 'None' `
        -DefaultAutoShutdownProfileShutdownWhenNotConnected 'Disabled' `
        -DefaultConnectionProfileClientRdpAccess 'Public' `
        -DefaultConnectionProfileClientSshAccess 'None' `
        -DefaultConnectionProfileWebRdpAccess 'None' `
        -DefaultConnectionProfileWebSshAccess 'None' `
        -SupportInfoEmail 'secondlp@test.com' `
        -SupportInfoInstruction 'second Support Information' `
        -SupportInfoPhone '123-234-3456' `
        -SupportInfoUrl 'https://www.secondtest.com' | Should -Not -BeNullOrEmpty

        Get-AzLabServicesLabPlan -Name 'LabPlan-test-powershell' -ResourceGroupName $ENV:ResourceGroupName | Select-Object -Property SupportInfoEmail | Should -BeExactly "@{SupportInfoEmail=secondlp@test.com}"
    }
}
