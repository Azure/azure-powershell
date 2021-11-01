if(($null -eq $TestName) -or ($TestName -contains 'Restart-AzWebPubSub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Restart-AzWebPubSub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Restart-AzWebPubSub' {
    It 'Restart' {
        $name = $env.WpsPrefix + "restart-wps-" + "Restart"
        New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        Restart-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name

        $wps = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name
        $wps.ProvisioningState | Should -Be "Succeeded"
    }

    It 'RestartViaIdentity' {
        $name = $env.WpsPrefix + "restart-wps-" + "RestartViaIdentity"
        $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        Restart-AzWebPubSub -InputObject $wps

        $wps = Get-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name
        $wps.ProvisioningState | Should -Be "Succeeded"
    }
}
