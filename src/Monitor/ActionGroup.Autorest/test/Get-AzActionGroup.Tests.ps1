if(($null -eq $TestName) -or ($TestName -contains 'Get-AzActionGroup'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzActionGroup.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzActionGroup' {
    It 'GetViaIdentity' {
        {
            $ag = New-AzActionGroup -Name $env.actiongroup3 -ResourceGroupName $env.resourceGroup -Location $env.region -GroupShortName 'ag3'
            Get-AzActionGroup -InputObject $ag
        } | Should -Not -Throw
    }

    It 'List' {
        {
            Get-AzActionGroup -SubscriptionId $env.SubscriptionId
        } | Should -Not -Throw
    }

    It 'Get' {
        {
            Get-AzActionGroup -Name $env.actiongroupname -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

    It 'List1' {
        {
            Get-AzActionGroup -ResourceGroupName $env.resourceGroup
        } | Should -Not -Throw
    }

}
