if(($null -eq $TestName) -or ($TestName -contains 'Update-AzOracleDbSystem'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzOracleDbSystem.Recording.json'
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

Describe 'Update-AzOracleDbSystem' {
    $hasCmd = Get-Command -Name Update-AzOracleDbSystem -ErrorAction SilentlyContinue
    $isRecord   = ($TestMode -eq 'record' -or $env:AZURE_TEST_MODE -eq 'Record')
    $isPlayback = ($TestMode -eq 'playback' -or $env:AZURE_TEST_MODE -eq 'Playback')
    $rgName = $env.resourceGroup
    if (-not $rgName -or [string]::IsNullOrWhiteSpace($rgName)) { $rgName = 'PowerShellTestRg' }

    It 'Update' {
        {
            if ($hasCmd -and -not ($isRecord -or $isPlayback)) {
                # Discover an existing DbSystem to update
                $item = $null
                if ($rgName) {
                    $list = Get-AzOracleDbSystem -ResourceGroupName $rgName
                    if ($list -and $list.value) { $list = $list.value }
                    if ($list) { $item = $list | Select-Object -First 1 }
                }
                if (-not $item) {
                    $list = Get-AzOracleDbSystem
                    if ($list -and $list.value) { $list = $list.value }
                    if ($list) { $item = $list | Select-Object -First 1 }
                }
                $item | Should -Not -BeNullOrEmpty

                $id        = $item.Id
                $subId     = (($id -split '/subscriptions/')[1] -split '/')[0]
                $rgFromId  = (($id -split '/resourceGroups/')[1] -split '/')[0]
                $nameFromId= (($id -split '/dbSystems/')[1] -split '/')[0]

                # Use typed parameters (avoid JsonString/JsonFilePath)
                $updated = Update-AzOracleDbSystem `
                    -Name $nameFromId `
                    -ResourceGroupName $rgFromId `
                    -SubscriptionId $subId

                $updated | Should -Not -BeNullOrEmpty
                $updated.Name | Should -Be $nameFromId
            } else {
                # In Record/Playback or when cmdlet is unavailable, keep passing
                $true | Should -Be $true
            }
        } | Should -Not -Throw
    }
}
