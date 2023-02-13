if(($null -eq $TestName) -or ($TestName -contains 'Get-AzReservationCatalog'))
{
  $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
  if (-Not (Test-Path -Path $loadEnvPath)) {
      $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
  }
  . ($loadEnvPath)
  $TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzReservationCatalog.Recording.json'
  $currentPath = $PSScriptRoot
  while(-not $mockingPath) {
      $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
      $currentPath = Split-Path -Path $currentPath -Parent
  }
  . ($mockingPath | Select-Object -First 1).FullName
}

Describe 'Get-AzReservationCatalog' {
    It 'GetSkusWithLocation' {
        $response = Get-AzReservationCatalog -SubscriptionId "eef82110-c91b-4395-9420-fcfcbefc5a47" -Location "westus" -ReservedResourceType "VirtualMachine"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be virtualMachines
            $sku.Locations | Should -Not -Be $null
            $sku.Locations.Count | Should -Be 1
            $sku.Locations[0] | Should -Be westus
            $sku.Terms.Count | Should -Be 3
        }
    }

    It 'GetSkusWithOutLocation' {
        $response = Get-AzReservationCatalog -SubscriptionId "eef82110-c91b-4395-9420-fcfcbefc5a47" -ReservedResourceType "SuseLinux"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be SuseLinux
            $sku.Locations | Should -Be $null
            $sku.Terms.Count | Should -Be 3
        }
    }

    It 'Get3PPSkus' {
        $response = Get-AzReservationCatalog -SubscriptionId "eef82110-c91b-4395-9420-fcfcbefc5a47" -ReservedResourceType "VirtualMachineSoftware" -PublisherId "canonical" -OfferId "0001-com-ubuntu-pro-jammy" -PlanId "pro-22_04-lts"
        $response.Count | Should -BeGreaterOrEqual 1
        Write-Output $response
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be VirtualMachineSoftware
            $sku.Locations | Should -Be $null
            $sku.Terms.Count | Should -Be 3
        }
    }

    It 'GetViaIdentity' {
        $param = @{SubscriptionId = "eef82110-c91b-4395-9420-fcfcbefc5a47"}
        $response = Get-AzReservationCatalog -InputObject $param -ReservedResourceType "SuseLinux"
        $response.Count | Should -BeGreaterOrEqual 1
        foreach ($sku in $response)
        {
            $sku.ResourceType | Should -Be SuseLinux
            $sku.Locations | Should -Be $null
            $sku.Terms.Count | Should -Be 3
        }
    }
}