# Minimal playback test for New-AzOracleNetworkAnchor using flattened parameters
# RU note: значения ниже должны совпадать с New-AzOracleNetworkAnchor.Recording.json

if(($null -eq $TestName) -or ($TestName -contains 'New-AzOracleNetworkAnchor'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'New-AzOracleNetworkAnchor.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'New-AzOracleNetworkAnchor' {
    # Constants matching the recording (RU: синхронизировать с записью)
    $rgName   = 'PowerShellTestRg'
    $location = 'eastus'
    $name     = 'OFake_PowerShellTestNetworkAnchor'

    It 'Create' {
        {
            # Create via flattened parameters (no JsonString)
            $created = New-AzOracleNetworkAnchor `
                -Name $name `
                -ResourceGroupName $rgName `
                -Location $location `
                -DisplayName $name `
                -AnchorType VCN `
                -OciResourceId 'ocid1.vcn.oc1.iad.fakeuniqueid'

            # Basic assertions only (RU: держим тест максимально лёгким)
            $created | Should -Not -BeNullOrEmpty
            $created.Name | Should -Be $name
        } | Should -Not -Throw
    }
}
