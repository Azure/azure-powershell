if(($null -eq $TestName) -or ($TestName -contains 'New-AzWcfRelay'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzWcfRelay.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzWcfRelay' {
    It 'Create' {
        {
            $wcf = New-AzWcfRelay -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -Name $env.wcfRelayName03  -WcfRelayType 'NetTcp' -UserMetadata "Test 01"
            $wcf.UserMetadata | Should -Be "Test 01"
            $wcf = Get-AzWcfRelay -InputObject $wcf
            $wcf.UserMetadata = "Test 02"
            $data = Set-AzWcfRelay -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -Name $env.wcfRelayName03  -InputObject $wcf
            $data.UserMetadata | Should -Be "Test 02"
            $data = Set-AzWcfRelay -ResourceGroupName $env.resourceGroupName  -Namespace $env.namespaceName01  -Name $env.wcfRelayName03  -UserMetadata "Test 03"
            $data.UserMetadata | Should -Be "Test 03"
            Remove-AzWcfRelay -InputObject $wcf
        } | Should -Not -Throw
    }
}
