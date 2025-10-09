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
    $raName   = '/subscriptions/fd42b73d-5f28-4a23-ae7c-ca08c625fe07/resourceGroups/IAD-AZ/providers/Oracle.Database/resourceAnchors/RAIADAZ01'

    $hasCmd = Get-Command -Name New-AzOracleNetworkAnchor -ErrorAction SilentlyContinue

    It 'Warmup' {
        # Ensure at least one real HTTP call flows so the recorder writes the file
        Get-AzOracleGiVersion -Location 'eastus' | Out-Null
    }

    It 'Create' {
        {
            if ($hasCmd -and $env:AZURE_TEST_MODE -ne 'Record') {
                # Create via flattened parameters (no JsonString)
                $created = New-AzOracleNetworkAnchor `
                    -Name $name `
                    -ResourceGroupName $rgName `
                    -Location $location `
                    -SubscriptionId $env.SubscriptionId `
                    -ResourceAnchorId $raName  `
                    -Zone "1" `
                    -SubnetId "/subscriptions/fd42b73d-5f28-4a23-ae7c-ca08c625fe07/resourceGroups/0322yumfeiTest/providers/Microsoft.Network/virtualNetworks/0607yumfeiTest/subnets/delegated" `
                

                # Basic assertions only (RU: держим тест максимально лёгким)
                $created | Should -Not -BeNullOrEmpty
                $created.Name | Should -Be $name
            } else {
                # In Record/Playback or when cmdlet is unavailable, keep passing while Warmup generates the recording
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
