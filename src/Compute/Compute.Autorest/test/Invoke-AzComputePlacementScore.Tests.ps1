if (($null -eq $TestName) -or ($TestName -contains 'Invoke-AzComputePlacementScore')) {
    $loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
    if (-Not (Test-Path -Path $loadEnvPath)) {
        $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
    }
    . ($loadEnvPath)
}

Describe 'Invoke-AzComputePlacementScore' {
    BeforeEach {
        $script:RestRequest = $null
        Mock Invoke-AzRestMethod {
            $script:RestRequest = [pscustomobject]@{
                Method = $Method
                Path = $Path
                Payload = $Payload
            }
            [pscustomobject]@{ Content = '{"placementScores":[{"placementPreference":8}]}' }
        }
    }

    It 'Posts required SKU sizes and returns the placement scores' {
        $result = Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize @(@{ Sku = 'Standard_D2_v3' })

        $RestRequest.Method | Should -Be 'POST'
        $RestRequest.Path | Should -Be '/subscriptions/subscription-id/providers/Microsoft.Compute/locations/eastus/placementScores/regular/generate?api-version=2026-10-05-preview'
        $body = $RestRequest.Payload | ConvertFrom-Json
        $body.desiredSizes.Count | Should -Be 1
        $body.desiredSizes[0].sku | Should -Be 'Standard_D2_v3'
        $body.PSObject.Properties.Name | Should -Be @('desiredSizes')
        $result.placementScores[0].placementPreference | Should -Be 8
    }

    It 'Includes each optional parameter alone and all optional parameters together' {
        $desiredSize = @(@{ Sku = 'Standard_D2_v3' })

        $null = Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize $desiredSize -AvailabilityZone
        ($RestRequest.Payload | ConvertFrom-Json).availabilityZones | Should -BeTrue

        $null = Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize $desiredSize -DesiredCount 2
        ($RestRequest.Payload | ConvertFrom-Json).desiredCount | Should -Be 2

        $null = Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize $desiredSize -DesiredLocation @('eastus2')
        ($RestRequest.Payload | ConvertFrom-Json).desiredLocations | Should -Be @('eastus2')

        $null = Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize $desiredSize -AvailabilityZone -DesiredCount 3 -DesiredLocation @('eastus2', 'westus')
        $body = $RestRequest.Payload | ConvertFrom-Json
        $body.availabilityZones | Should -BeTrue
        $body.desiredCount | Should -Be 3
        $body.desiredLocations | Should -Be @('eastus2', 'westus')
    }

    It 'Rejects null or empty desired sizes' {
        { Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize $null } | Should -Throw
        { Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize @() } | Should -Throw
        Assert-MockCalled Invoke-AzRestMethod -Times 0
    }

    It 'Does not send the request with WhatIf' {
        Invoke-AzComputePlacementScore -Location eastus -SubscriptionId 'subscription-id' -DesiredSize @(@{ Sku = 'Standard_D2_v3' }) -WhatIf

        Assert-MockCalled Invoke-AzRestMethod -Times 0
    }
}
