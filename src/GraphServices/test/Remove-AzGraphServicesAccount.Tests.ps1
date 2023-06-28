if(($null -eq $TestName) -or ($TestName -contains 'Remove-AzGraphServicesAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Remove-AzGraphServicesAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Remove-AzGraphServicesAccount' {
    It 'RemoveResource' {
        {
            New-AzGraphServicesAccount -ResourceGroupName $env.resourceGroup -Name $env.createResource -AppId $env.appId -SubscriptionId $env.SubscriptionId -Location $env.location
            Remove-AzGraphServicesAccount -ResourceGroupName $env.resourceGroup -Name $env.createResource
        } | Should -Not -Throw
    }
}
