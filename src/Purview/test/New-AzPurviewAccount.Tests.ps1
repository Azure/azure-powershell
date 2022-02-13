if(($null -eq $TestName) -or ($TestName -contains 'New-AzPurviewAccount'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzPurviewAccount.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzPurviewAccount' {
    It 'CreateExpanded' {
        $pa = New-AzPurviewAccount -Name $env.accountName3 -ResourceGroupName $env.resourceGroupName -Location eastus -IdentityType SystemAssigned -SkuCapacity $env.skuCapacity -SkuName $env.skuName
        $pa.Name | should -be $env.accountName3
    }
}