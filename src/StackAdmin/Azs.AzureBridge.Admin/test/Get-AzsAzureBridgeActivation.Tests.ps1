$TestRecordingFile = Join-Path $PSScriptRoot 'Get-AzsAzureBridgeActivation.Recording.json'
$currentPath = $PSScriptRoot
while(-not $mockingPath) {
    $mockingPath = Get-ChildItem -Path $currentPath -Recurse -Include 'HttpPipelineMocking.ps1' -File
    $currentPath = Split-Path -Path $currentPath -Parent
}
. ($mockingPath | Select-Object -First 1).FullName

Describe "AzsAzureBridgeActivation" -Tags @('AzureBridgeActivation', 'Azs.AzureBridge.Admin') {

    . $PSScriptRoot\Common.ps1

    BeforeEach {

        function ValidateActivationInfo {
            param(
                [Parameter(Mandatory = $true)]
                $Activation
            )

            $Activation          | Should Not Be $null

            # Resource
            $Activation.Id       | Should Not Be $null
            $Activation.Name     | Should Not Be $null
            $Activation.Type     | Should Not Be $null

            $Activation.ProvisioningState    | Should Not Be $null
            $Activation.Expiration         | Should Not Be $null
            $Activation.MarketplaceSyndicationEnabled        | Should Not Be $null
            $Activation.AzureRegistrationResourceIdentifier  | Should Not Be $null
            $Activation.Location    | Should Not Be $null
            $Activation.DisplayName  | Should Not Be $null

        }
    }

    AfterEach {
        $global:Client = $null
    }

    It "TestListAzsAzureBridgeActivation" -Skip:$('TestListAzsAzureBridgeActivation' -in $global:SkippedTests) {
        $global:TestName = "TestListAzsAzureBridgeActivation"
        $Activations = Get-AzsAzureBridgeActivation -ResourceGroupName $global:ResourceGroupName

        Foreach ($Activation in $Activations) {
            ValidateActivationInfo -Activation $Activation
        }
    }

    It "TestGetAzsAzureBridgeActivationByName" -Skip:$('TestGetAzsAzureBridgeActivationByName' -in $global:SkippedTests) {
        $global:TestName = "TestGetAzsAzureBridgeActivationByName"
        $Activation = Get-AzsAzureBridgeActivation -Name $global:ActivationName -ResourceGroupName $global:ResourceGroupName
        ValidateActivationInfo -Activation $Activation
    }
}
