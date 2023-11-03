if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationUnarchiveReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationUnarchiveReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzReservationUnarchiveReservation' {
    It 'Unarchive' {
        {
            Invoke-AzReservationUnarchiveReservation -ReservationId "afeee3d5-5e0c-4df1-be77-409d34863e9a" -ReservationOrderId "30000000-aaaa-bbbb-cccc-100000000003"
        } | Should -Not -Throw
    }

    It 'UnarchiveViaIdentity' {
        { 
            $param = @{
                ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000005" 
                ReservationId = "30000000-aaaa-bbbb-cccc-100000000005" 
            }
            Invoke-AzReservationUnarchiveReservation -InputObject $param
        } | Should -Not -Throw
    }
}
