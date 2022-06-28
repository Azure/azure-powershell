if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationsCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationsCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationsCatalog' {
    It 'GetSkusWithLocation' {
        $response = Get-AzReservationsCatalog -SubscriptionId $env.SubscriptionId -Location "westus" -ReservedResourceType "VirtualMachine"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be virtualMachines
            $sku.Location | Should -Be westus
            $sku.Term.Count | Should -Be 3
        }
    }

    It 'GetSkusWithOutLocation' {
        $response = Get-AzReservationsCatalog -SubscriptionId $env.SubscriptionId -ReservedResourceType "SuseLinux"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be SuseLinux
            $sku.Location | Should -Be $null
            $sku.Term.Count | Should -Be 3
        }
    }

    It 'Get3PPSkus' {
        $response = Get-AzReservationsCatalog -SubscriptionId $env.SubscriptionId -ReservedResourceType "VirtualMachineSoftware" -PublisherId "test_test_pmc2pc1" -OfferId "mnk_vmri_test_001" -PlanId "testplan001"
        $response.Count | Should -BeGreaterOrEqual 1
        Write-Output $response
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be VirtualMachineSoftware
            $sku.Location | Should -Be $null
            $sku.Term.Count | Should -Be 3
        }
    }

    It 'GetViaIdentity' {
        $param = @{SubscriptionId = $env.SubscriptionId}
        $response = Get-AzReservationsCatalog -InputObject $param -ReservedResourceType "SuseLinux"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be SuseLinux
            $sku.Location | Should -Be $null
            $sku.Term.Count | Should -Be 3
        }
    }

    function setupEnv() {
        set-content -Path (Join-Path $PSScriptRoot $envFile) -Value (ConvertTo-Json $env)
    }
}
