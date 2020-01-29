$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsOfferDelegation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'OfferDelegation' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateOfferDelegation {
            param(
                [Parameter(Mandatory = $true)]
                $Offer
            )
            # Overall
            $Offer               | Should Not Be $null

            # Resource
            $Offer.Id            | Should Not Be $null
            $Offer.Name          | Should Not Be $null
            $Offer.Type          | Should Not Be $null
            $Offer.Location      | Should Not Be $null

            # Offer
            $Offer.SubscriptionId | Should Not Be $null
        }

        function AssertOfferDelegationsSame {
            param(
                [Parameter(Mandatory = $true)]
                $Expected,

                [Parameter(Mandatory = $true)]
                $Found
            )
            if ($Expected -eq $null) {
                $Found | Should Be $null
            }
            else {
                $Found                  | Should Not Be $null

                # Resource
                $Found.Id               | Should Be $Expected.Id
                $Found.Location         | Should Be $Expected.Location
                $Found.Name             | Should Be $Expected.Name
                $Found.Type             | Should Be $Expected.Type

                # OfferDelegation
                $Found.SubscriptionId   | Should Be $Expected.SubscriptionId
            }
        }

        function GetResourceGroupName() {
            param(
                $ID
            )
            $rg = "resourceGroups/"
            $pv = "providers/"
            $start = $ID.IndexOf($rg) + $rg.Length
            $length = $ID.IndexOf($pv) - $start - 1
            return $ID.Substring($start, $length);
        }
    }

    AfterEach {
        $global:Client = $null
    }

    it "TestListOfferDelegations" -Skip:$('TestListOfferDelegations' -in $global:SkippedTests) {
        $global:TestName = "TestListOfferDelegations"

        $offers = Get-AzsAdminManagedOffer

        foreach ($offer in $offers) {
            $resourceGroupName = GetResourceGroupName -ID $offer.Id
            $offerdel = Get-AzsOfferDelegation -ResourceGroupName $resourceGroupName -OfferName $offer.Name
            ValidateOfferDelegation $offerdel
        }
    }

    It 'Get' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
