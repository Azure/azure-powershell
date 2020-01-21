$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsUserSubscription.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'UserSubscription' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {
        function ValidateSubscription {
            param(
                [Parameter(Mandatory = $true)]
                $Subscription
            )
            $Subscription                | Should Not Be $null
            # Resource
            $Subscription.Id             | Should Not Be $null
            $Subscription.DisplayName    | Should Not Be $null
            $Subscription.OfferId        | Should Not Be $null
            $Subscription.Owner          | Should Not Be $null
            $Subscription.State          | Should Not Be $null
            $Subscription.SubscriptionId | Should Not Be $null
            $Subscription.TenantId       | Should Not Be $null

        }

    }

    AfterEach {
        $global:Client = $null
    }

    it "TestListSubscriptions" -Skip:$('TestListSubscriptions' -in $global:SkippedTests) {
        $global:TestName = 'TestListSubscriptions'
        $Subscriptions = Get-AzsUserSubscription
        $Subscriptions | Should Not Be $null
        foreach ($Subscription in $Subscriptions) {
            ValidateSubscription -Subscription $Subscription
        }
    }

    it "TestSetSubscription" -Skip:$('TestSetSubscription' -in $global:SkippedTests) {
        $global:TestName = "TestSetSubscription"
        $Subscriptions = Get-AzsUserSubscription
        foreach ($sub in $subscriptions) {
            $sub.DisplayName += "-test"
            $sub.Owner = $global:Owner
            $sub | Set-AzsUserSubscription
            $updated = Get-AzsUserSubscription -TargetSubscriptionId $sub.SubscriptionId
            $updated.DisplayName | Should Be $sub.DisplayName
            $updated.Owner       | Should Be $global:Owner
            break;
        }
    }

    it "CheckNameAvailability" -Skip:$('CheckNameAvailability' -in $global:SkippedTests) {
        $global:TestName = 'CheckNameAvailability'
        Test-AzsNameAvailability -Name $global:TestAvailability -ResourceType $global:ResourceType
    }

    it "TestMoveSubscription" -Skip:$('TestMoveSubscription' -in $global:SkippedTests) {
        $global:TestName = 'MoveSubscription'
        $resourceIds = Get-AzsUserSubscription -Filter "offerName eq 'o1'" | Select -ExpandProperty Id
        Move-AzsUserSubscription -DestinationDelegatedProviderOffer $Null -ResourceId $resourceIds
    }

    it "TestTestMoveSubscription" -Skip:$('TestTestMoveSubscription' -in $global:SkippedTests) {
        $global:TestName = 'MoveSubscription'
        $resourceIds = Get-AzsUserSubscription -Filter "offerName eq 'o1'" | Select-Object -ExpandProperty Id
        Test-AzsMoveUserSubscription -DestinationDelegatedProviderOffer $Null -ResourceId $resourceIds
    }

    It 'Get' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
