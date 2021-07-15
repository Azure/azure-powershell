."$PSScriptRoot\testDataGenerator.ps1"
."$PSScriptRoot\virtualNetworkClient.ps1"


$loadEnvPath = Join-Path $PSScriptRoot 'loadEnv.ps1'
if (-Not (Test-Path -Path $loadEnvPath)) {
    $loadEnvPath = Join-Path $PSScriptRoot '..\loadEnv.ps1'
}
. ($loadEnvPath)

Function BeSuccessfullyCreated {
    <#
    .SYNOPSIS
    Tests whether a DNS Resolver is created successfully
    #>
        [CmdletBinding()]
        Param(
            $ActualValue,
            [switch]$Negate
        )
    
        [bool]$Pass = $ActualValue.ProvisioningState -eq $env.SuccessProvisioningState -and $ActualValue.Name -ne $null -and $ActualValue.Id -ne $null -and $ActualValue.ResourceGuid -ne $null

        If ( $Negate ) { $Pass = -not($Pass) }
    
        If ( -not($Pass) ) {
            $FailureMessage = 'The DNS resolver is not created successfully.'
        }
    
        $ObjProperties = @{
            Succeeded      = $Pass
            FailureMessage = $FailureMessage
        }
        return New-Object PSObject -Property $ObjProperties
}

Function BeSameAsExpected {
    <#
    .SYNOPSIS
    Tests whether a DNS Resolver is created successfully
    #>
        [CmdletBinding()]
        Param(
            $ActualValue,
            $ExpectedValue,
            [switch]$Negate
        )
    
        [bool]$Pass = $ActualValue.ProvisioningState -eq $ExpectedValue.ProvisioningState -and $ActualValue.Name -eq $ExpectedValue.Name -and $ActualValue.Id -eq $ExpectedValue.Id -and $ActualValue.ResourceId -eq $ExpectedValue.ResourceId

        If ( $Negate ) { $Pass = -not($Pass) }
    
        If ( -not($Pass) ) {
            $FailureMessage = 'The DNS resolver is different from the expected.'
        }
    
        $ObjProperties = @{
            Succeeded      = $Pass
            FailureMessage = $FailureMessage
        }
        return New-Object PSObject -Property $ObjProperties
}

Function BeSameDnsResolverCollectionAsExpected {
    <#
    .SYNOPSIS
    Tests whether DNS Resolver collection is same as expected
    #>
        [CmdletBinding()]
        Param(
            $ActualValue,
            $ExpectedValue,
            [switch]$Negate
        )
    
        [bool]$Pass = $True

        Write-Host $ActualValue.Count
        Write-Host $ExpectedValue.Count
        Write-Host ($ActualValue | Format-Table | Out-String)
        Write-Host ($ExpectedValue | Format-Table | Out-String)
        if($ActualValue.Count -eq $ExpectedValue.Count){
            foreach ($actualResolver in $ActualValue) {
                foreach ($expectedResolver in $ExpectedValue) {
                    if($actualResolver.Id -eq $expectedResolver.Id){
                        [bool]$isSameResolver = $actualResolver.ProvisioningState -eq $expectedResolver.ProvisioningState -and $actualResolver.Name -eq $expectedResolver.Name -and $actualResolver.Id -eq $expectedResolver.Id -and $actualResolver.ResourceId -eq $expectedResolver.ResourceId
    
                        if (-not($isSameResolver)) {
                            $Pass = $False
                            Write-Host ($actualResolver | Format-Table | Out-String)
                            Write-Host ($expectedResolver | Format-Table | Out-String)
                            break
                        }
                    }
                    
                }
            }
        }
        else {
            $Pass = $False
        }

        If ( $Negate ) { $Pass = -not($Pass) }
    
        If ( -not($Pass) ) {
            $FailureMessage = 'The DNS resolver(s) are different from the expected.'
        }
    
        $ObjProperties = @{
            Succeeded      = $Pass
            FailureMessage = $FailureMessage
        }
        return New-Object PSObject -Property $ObjProperties
}