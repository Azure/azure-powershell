$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAdminManagedOffer.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'AdminManagedOffer' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateOffer {
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
            $Offer.DisplayName   | Should Not Be $null
            $Offer.OfferName     | Should Not Be $null
            $Offer.Description   | Should Not Be $null
            $Offer.State         | Should Not Be $null
        }

        function AssertOffersSame {
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
                # Offer
                $Found.DisplayName   | Should Be $Expected.DisplayName
                $Found.OfferName     | Should Be $Expected.OfferName
                $Found.Description   | Should Be $Expected.Description
                $Found.State         | Should Be $Expected.State
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

    it "TestListOffers" -Skip:$('TestListOffers' -in $global:SkippedTests) {
        $global:TestName = 'TestListOffers'

        $allOffers = Get-AzsAdminManagedOffer
        $global:ResourceGroupNames = New-Object  -TypeName System.Collections.Generic.HashSet[System.String]

        foreach ($offer in $allOffers) {
            $rgn = GetResourceGroupName -ID $offer.Id
            $global:ResourceGroupNames.Add($rgn)
        }

        foreach ($rgn in $global:ResourceGroupNames) {
            Get-AzsAdminManagedOffer -ResourceGroupName $rgn
        }
    }

    it "TestGetOffer" -Skip:$('TestGetOffer' -in $global:SkippedTests) {
        $global:TestName = 'TestGetOffer'

        $offer = (Get-AzsAdminManagedOffer)[0]
        $offer | Should Not Be $null
        $rgn = GetResourceGroupName -ID $offer.Id
        $offer2 = Get-AzsAdminManagedOffer -ResourceGroupName $rgn -Name $offer.Name
        AssertOffersSame $offer $offer2
    }

    it "TestGetAllOffers" -Skip:$('TestGetAllOffers' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllOffers'

        $allOffers = Get-AzsAdminManagedOffer
        foreach ($offer in $allOffers) {
            $rgn = GetResourceGroupName -ID $offer.Id
            $offer2 = Get-AzsAdminManagedOffer -ResourceGroupName $rgn -Name $offer.Name
            AssertOffersSame $offer $offer2
        }
    }

    it "TestSetOffer" -Skip:$('TestSetOffer' -in $global:SkippedTests) {
        $global:TestName = "TestSetOffer"

        $allOffers = Get-AzsAdminManagedOffer
        $offer = $allOffers[0]
        $rgn = GetResourceGroupName -Id $offer.Id

        $offer.DisplayName += "-test"

        $offer | Set-AzsOffer
        $updated = Get-AzsAdminManagedOffer -Name $offer.Name -ResourceGroupName $rgn
        $updated.DisplayName | Should Be $offer.DisplayName
    }

    it "TestCreateUpdateThenDeleteOffer" -Skip:$('TestCreateUpdateThenDeleteOffer' -in $global:SkippedTests) {
        $global:TestName = 'TestCreateUpdateThenDeleteOffer'

        $plan = (Get-AzsPlan)[0]

        $offer = New-AzsOffer -Name $global:OfferName -DisplayName "Test Offer" -ResourceGroupName $global:OfferResourceGroupName -BasePlanIds $plan.Id -Location $global:Location
        $saved = Get-AzsAdminManagedOffer -Name $global:OfferName -ResourceGroupName $global:OfferResourceGroupName
        AssertOffersSame $offer $saved
    }

    It 'List1' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
