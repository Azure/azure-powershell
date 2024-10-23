if(($null -eq $TestName) -or ($TestName -contains 'Export-AzTerraform'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Export-AzTerraform.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Export-AzTerraform' {
    It 'Export' {
        { 
            $result = Export-AzTerraform -ExportParameter $(New-AzTerraformExportResourceObject -ResourceId "/subscriptions/$($env.SubscriptionId)/resourceGroups/$($env.resourceGroup)/providers/Microsoft.Network/virtualNetworks/$($env.vNetName)")
            $result.Status | Should -Be "Succeeded"
            $result = Export-AzTerraform -ExportParameter $(New-AzTerraformExportResourceGroupObject -ResourceGroupName $env.resourceGroup)
            $result.Status | Should -Be "Succeeded"
            $result = Export-AzTerraform -ExportParameter $(New-AzTerraformExportQueryObject -Query "type =~ `"microsoft.network/virtualnetworks`"")
            $result.Status | Should -Be "Succeeded"
         } | Should -Not -Throw
    }
}
