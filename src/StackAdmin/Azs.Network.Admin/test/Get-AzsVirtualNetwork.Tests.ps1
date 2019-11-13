$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsVirtualNetwork.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

function ValidateBaseResources {
    param(
        [Parameter(Mandatory = $true)]
        $Resource
    )

    $Resource          | Should Not Be $null
    $Resource.Id       | Should Not Be $null
    $Resource.Name       | Should Not Be $null
}
function ValidateBaseResourceTenant {
    param(
        [Parameter(Mandatory = $true)]
        $Tenant
    )

    $Tenant                  	| Should Not Be $null
    $Tenant.SubscriptionId   | Should Not Be $null
    $Tenant.TenantResourceUri   | Should Not Be $null
}
Describe 'Get-AzsVirtualNetwork' {
    BeforeEach {

        function ValidateConfigurationState {
            param(
                $state
            )

            $state | Should Not Be $null
            $state.ConfigurationStateStatus | Should Not Be $null
            $state.ConfigurationStateLastUpdatedTime | Should Not Be $null
            $state.ProvisioningState | Should Not Be $null
        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestGetAllVirtualNetworks" -Skip:$('TestGetAllVirtualNetworks' -in $global:SkippedTests) {
        $global:TestName = "TestGetAllVirtualNetworks"

        $networks = Get-AzsVirtualNetwork
        foreach ($network in $networks) {
            ValidateBaseResources $network
            ValidateBaseResourceTenant $network
            ValidateConfigurationState $network
        }
    }
}
