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
    $response.Scope | Should -Be "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"
    $response.Valid | Should -Be "True"
}

Describe 'Get-AzReservationAvailableScope' {
    It 'AvailableExpanded' {
        $response = Get-AzReservationAvailableScope -ReservationId "10000000-aaaa-bbbb-cccc-100000000001" -ReservationOrderId "50000000-aaaa-bbbb-cccc-100000000003" -Scope "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"

        ExecuteTestCases($response)
    }

    It 'Available' {
        $param = @{Scope = "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"}        
        $response = Get-AzReservationAvailableScope -ReservationId "10000000-aaaa-bbbb-cccc-100000000001" -ReservationOrderId "50000000-aaaa-bbbb-cccc-100000000003" -Body $param
        
        ExecuteTestCases($response)
    }

    It 'AvailableViaIdentityExpanded' {
        $identity = @{
                        SubscriptionId = "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"
                        ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000003"
                        ReservationId = "10000000-aaaa-bbbb-cccc-100000000001"
                    } 
        $response = Get-AzReservationAvailableScope -InputObject $identity -Scope "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"

        ExecuteTestCases($response)
    }

    It 'AvailableViaIdentity' {
        $body = @{Scope = "/subscriptions/40000000-aaaa-bbbb-cccc-100000000003"} 
        $identity = @{
                        ReservationOrderId = "50000000-aaaa-bbbb-cccc-100000000003"
                        ReservationId = "10000000-aaaa-bbbb-cccc-100000000001"
                    } 
        $response = Get-AzReservationAvailableScope -InputObject $identity -Body $body

        ExecuteTestCases($response)
    }
}