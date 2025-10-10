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
  # Ensure Az.Oracle module (which defines PipelineMock) is loaded before mocking
  $modulePsd1 = Join-Path $PSScriptRoot '..\Az.Oracle.psd1'
  if (Test-Path -Path $modulePsd1) { Import-Module $modulePsd1 -Force }
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
    $raName   = '/subscriptions/3b3aa069-da96-41b6-b5aa-6f20dd9db826/resourceGroups/PowerShellTestRgMihr/providers/Oracle.Database/resourceAnchors/Create'

    # $hasCmd = Get-Command -Name New-AzOracleNetworkAnchor -ErrorAction SilentlyContinue
    # $isRecord   = ($TestMode -eq 'record' -or $env:AZURE_TEST_MODE -eq 'Record')
    # $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')

    It 'Create' {
        {
                
           $created = New-AzOracleNetworkAnchor `
                    -Name $name `
                    -ResourceGroupName $rgName `
                    -Location $location `
                    -SubscriptionId $env.SubscriptionId `
                    -ResourceAnchorId $raName `
                    -ResourceAnchorId $raName `
                    -Zone "1" `
                    -SubnetId "/subscriptions/3b3aa069-da96-41b6-b5aa-6f20dd9db826/resourceGroups/IAD-AZ/providers/Microsoft.Network/virtualNetworks/VNIADAZ01/subnets/delegated"
                $created | Should -Not -BeNullOrEmpty
            $created.Name | Should -Be $name
        
        } | Should -Not -Throw
    }
}
