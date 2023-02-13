if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationAvailableScope'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationAvailableScope.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

 function ExecuteTestCases([object]$response) {
    $response | Should -Not -Be $null
    $response.Scope | Should -Be "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
    $response.Valid | Should -Be "True"
}

Describe 'Get-AzReservationAvailableScope' {
    It 'AvailableExpanded' {
        $response = Get-AzReservationAvailableScope -ReservationId "eee9bfda-6806-4fa0-9d0c-c5efdd597932" -ReservationOrderId "3739a91e-601d-4ac6-9dc8-fba60718b5f8" -Scope "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"

        ExecuteTestCases($response)
    }

    It 'Available' {
        $param = @{Scope = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"}        
        $response = Get-AzReservationAvailableScope -ReservationId "eee9bfda-6806-4fa0-9d0c-c5efdd597932" -ReservationOrderId "3739a91e-601d-4ac6-9dc8-fba60718b5f8" -Body $param
        
        ExecuteTestCases($response)
    }

    It 'AvailableViaIdentityExpanded' {
        $identity = @{
                        SubscriptionId = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"
                        ReservationOrderId = "3739a91e-601d-4ac6-9dc8-fba60718b5f8"
                        ReservationId = "eee9bfda-6806-4fa0-9d0c-c5efdd597932"
                    } 
        $response = Get-AzReservationAvailableScope -InputObject $identity -Scope "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"

        ExecuteTestCases($response)
    }

    It 'AvailableViaIdentity' {
        $body = @{Scope = "/subscriptions/eef82110-c91b-4395-9420-fcfcbefc5a47"} 
        $identity = @{
                        ReservationOrderId = "3739a91e-601d-4ac6-9dc8-fba60718b5f8"
                        ReservationId = "eee9bfda-6806-4fa0-9d0c-c5efdd597932"
                    } 
        $response = Get-AzReservationAvailableScope -InputObject $identity -Body $body

        ExecuteTestCases($response)
    }
}