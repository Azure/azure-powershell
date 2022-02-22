."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"


$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

Function BeSuccessfullyCreatedVirtualNetworkLink {
    <#
    .SYNOPSIS
    Tests whether a virtual network link is created successfully
    #>
        [CmdletBinding()]
        Param(
            $ActualValue,
            [switch]$Negate
        )
    
        [bool]$Pass = $ActualValue.ProvisioningState -eq $env.SuccessProvisioningState -and  $null -ne $ActualValue.Name -and $null -ne $ActualValue.Id

        If ( $Negate ) { $Pass = -not($Pass) }
    
        If ( -not($Pass) ) {
            $FailureMessage = 'The virtual network link is not created successfully.'
        }
    
        $ObjProperties = @{
            Succeeded      = $Pass
            FailureMessage = $FailureMessage
        }
        return New-Object PSObject -Property $ObjProperties
}

Function BeSameVirtualNetworkLinkAsExpected {
    <#
    .SYNOPSIS
    Tests whether a virtual network link is created successfully
    #>
        [CmdletBinding()]
        Param(
            $ActualValue,
            $ExpectedValue,
            [switch]$Negate
        )
    
        [bool]$Pass = $ActualValue.ProvisioningState -eq $ExpectedValue.ProvisioningState -and $ActualValue.Name -eq $ExpectedValue.Name -and $ActualValue.Id -eq $ExpectedValue.Id

        If ( $Negate ) { $Pass = -not($Pass) }
    
        If ( -not($Pass) ) {
            $FailureMessage = 'The virtual network link is different from the expected.'
        }
    
        $ObjProperties = @{
            Succeeded      = $Pass
            FailureMessage = $FailureMessage
        }
        return New-Object PSObject -Property $ObjProperties
}