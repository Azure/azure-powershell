$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsDelegatedProvider.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe 'DelegatedProvider' {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateDelegatedProvider {
            param(
                [Parameter(Mandatory = $true)]
                $DelegatedProvider
            )
            # Overall
            $DelegatedProvider                            | Should Not Be $null
            # Resource
            $DelegatedProvider.Id                         | Should Not Be $null
            # DelegatedProvider
            $DelegatedProvider.OfferId                    | Should Not Be $null
            $DelegatedProvider.Owner                      | Should Not Be $null
            $DelegatedProvider.RoutingResourceManagerType | Should Not Be $null
            $DelegatedProvider.SubscriptionId             | Should Not Be $null
            $DelegatedProvider.DisplayName                | Should Not Be $null
            $DelegatedProvider.State                      | Should Not Be $null
            $DelegatedProvider.TenantId                   | Should Not Be $null
        }

        function AssertDelegatedProvidersSame {
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
                $Found                            | Should Not Be $null
                # Resource
                $Found.Id                         | Should Be $Expected.Id
                # DelegatedProvider
                $Found.OfferId                    | Should Be $Found.OfferId
                $Found.Owner                      | Should Be $Found.Owner
                $Found.RoutingResourceManagerType | Should Be $Found.RoutingResourceManagerType
                $Found.SubscriptionId             | Should Be $Found.SubscriptionId
                $Found.DisplayName                | Should Be $Found.DisplayName
                $Found.State                      | Should Be $Found.State
                $Found.TenantId                   | Should Be $Found.TenantId
            }
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListDelegatedProviders" -Skip:$('TestListDelegatedProviders' -in $global:SkippedTests) {
        $global:TestName = 'TestListDelegatedProviders'

        $providers = Get-AzsDelegatedProvider

        foreach ($provider in $providers) {
            ValidateDelegatedProvider $provider
        }
    }

    It "TestGetAllDelegatedProviders" -Skip:$('TestGetAllDelegatedProviders' -in $global:SkippedTests) {
        $global:TestName = 'TestGetAllDelegatedProviders'

        $providers = Get-AzsDelegatedProvider

        foreach ($provider in $providers) {
            $provider2 = Get-AzsDelegatedProvider -DelegatedProviderId $provider.SubscriptionId
            AssertDelegatedProvidersSame $provider $provider2
        }
    }

    It 'GetViaIdentity' {
        #{ throw [System.NotImplementedException] } | Should -Not -Throw
    }
}
