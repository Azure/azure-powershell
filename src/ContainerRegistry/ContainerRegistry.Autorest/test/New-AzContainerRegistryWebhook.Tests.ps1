if(($null -eq $TestName) -or ($TestName -contains 'New-AzContainerRegistryWebhook'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzContainerRegistryWebhook.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzContainerRegistryWebhook' {
    It 'CreateExpanded' {
        {New-AzContainerRegistryWebhook -RegistryName $env.rstr1 -ResourceGroupName $env.resourceGroup -Name $env.rstr2 -ServiceUri http://www.bing.com -Action Delete,Push -Location "east us" -Status Enabled -Scope "foo:*" } | Should -Not -Throw
    }

    It 'CreateByRegistry' {
        $obj = Get-AzContainerRegistry -Name $env.rstr1 -ResourceGroupName $env.ResourceGroup 
        {New-AzContainerRegistryWebhook -Registry $obj -Name $env.rstr3 -ServiceUri http://www.bing.com -Action Delete,Push -Location "east us" -Status Enabled -Scope "foo:*"  } | Should -Not -Throw
    }
}
