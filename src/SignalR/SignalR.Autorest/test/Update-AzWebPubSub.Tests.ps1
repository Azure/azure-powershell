if(($null -eq $TestName) -or ($TestName -contains 'Update-AzWebPubSub'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzWebPubSub.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Update-AzWebPubSub' {
    It 'UpdateExpanded' {
        $name = $env.WpsPrefix + "update-wps-" + "UpdateExpanded"
        $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        $newWps = Update-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -IdentityType SystemAssigned

        $newWps.IdentityType | Should -Be "SystemAssigned"
        $newWps.IdentityType | Should -Not -Be $wps.IdentityType
    }

    It 'UpdateViaIdentityExpanded' {
        $name = $env.WpsPrefix + "update-wps-" + "UpdateViaIdentityExpanded"
        $wps = New-AzWebPubSub -ResourceGroupName $env.ResourceGroupName -Name $name -Location eastus -SkuName Standard_S1

        $newWps = Update-AzWebPubSub -IdentityType SystemAssigned -InputObject $wps

        $newWps.IdentityType | Should -Be "SystemAssigned"
        $newWps.IdentityType | Should -Not -Be $wps.IdentityType
    }
}
