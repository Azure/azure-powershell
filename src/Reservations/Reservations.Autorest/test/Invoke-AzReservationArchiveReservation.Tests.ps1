if(($null -eq $TestName) -or ($TestName -contains 'Invoke-AzReservationArchiveReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Invoke-AzReservationArchiveReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Invoke-AzReservationArchiveReservation' {
    It 'Archive' {
        {
            Invoke-AzReservationArchiveReservation -ReservationId "50000000-aaaa-bbbb-cccc-100000000003" -ReservationOrderId "30000000-aaaa-bbbb-cccc-100000000003"
        } | Should -Not -Throw
    }

    It 'ArchiveViaIdentity' {
        { 
            $param = @{
                ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000005" 
                ReservationId = "30000000-aaaa-bbbb-cccc-100000000005" 
            }
            Invoke-AzReservationArchiveReservation -InputObject $param
        } | Should -Not -Throw
    }
}
