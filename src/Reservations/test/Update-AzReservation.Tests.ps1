if(($null -eq $TestName) -or ($TestName -contains 'Update-AzReservation'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Update-AzReservation.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

function GetNewName([string]$oldName) {
    $ranNum = Get-Random -Maximum 9
    return $oldName.remove($oldName.Length-1,1).insert($oldName.Length-1,$ranNum)
}

Describe 'Update-AzReservation' {
    It 'UpdateExpanded' {
        $reservation = Get-AzReservation -ReservationOrderId "10000000-aaaa-bbbb-cccc-200000000007" -ReservationId "30000000-aaaa-bbbb-cccc-200000000018"
        $newName = GetNewName($reservation.DisplayName)
        $res = Update-AzReservation -ReservationOrderId "10000000-aaaa-bbbb-cccc-200000000007" -ReservationId "30000000-aaaa-bbbb-cccc-200000000018" -Name $newName

        $res.DisplayName | Should -Not -Be reservation.DisplayName
    }

    It 'Update' {
        $reservation = Get-AzReservation -ReservationOrderId "10000000-aaaa-bbbb-cccc-200000000007" -ReservationId "30000000-aaaa-bbbb-cccc-200000000018"
        $newName = GetNewName($reservation.DisplayName)
        $newRi = @{Name = $newName}
        $res = Update-AzReservation -ReservationOrderId "10000000-aaaa-bbbb-cccc-200000000007" -ReservationId "30000000-aaaa-bbbb-cccc-200000000018" -Reservation $newRi

        $res.DisplayName | Should -Not -Be reservation.DisplayName
    }

    It 'UpdateViaIdentityExpanded' {
        $input = @{
            ReservationId = "30000000-aaaa-bbbb-cccc-200000000018"
            ReservationOrderId = "10000000-aaaa-bbbb-cccc-200000000007"
        }
        $reservation = Get-AzReservation -InputObject $input
        $newName = GetNewName($reservation.DisplayName)
        $res = Update-AzReservation -InputObject $input -Name $newName

        $res.DisplayName | Should -Not -Be reservation.DisplayName
    }

    It 'UpdateViaIdentity' {
        $input = @{
            ReservationId = "30000000-aaaa-bbbb-cccc-200000000018"
            ReservationOrderId = "10000000-aaaa-bbbb-cccc-200000000007"
        }
        $reservation = Get-AzReservation -InputObject $input
        $newName = GetNewName($reservation.DisplayName)
        $newRi = @{Name = $newName}
        $res = Update-AzReservation -InputObject $input -Reservation $newRi

        $res.DisplayName | Should -Not -Be reservation.DisplayName
    }
}
