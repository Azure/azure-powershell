# Handle rest calls for the CreateTestResources.ps1
# We are using strict mode for added safety
Set-StrictMode -Version Latest

# We require a relatively new version of Powershell
#requires -Version 3.0

$ApiVersion = 'api-version=2021-10-01-preview'

#?api-version=2020-05-01-preview
function BeginPreamble {
    [Diagnostics.CodeAnalysis.SuppressMessageAttribute("PSUseDeclaredVarsMoreThanAssignments", "", Scope = "Function")]
    param()
    Get-CallerPreference -Cmdlet $PSCmdlet -SessionState $ExecutionContext.SessionState
    $callerEA = $ErrorActionPreference
    $ErrorActionPreference = 'Stop'
}

function Get-CallerPreference {
    [CmdletBinding(DefaultParameterSetName = 'AllVariables')]
    param (
        [Parameter(Mandatory = $true)]
        [ValidateScript( { $_.GetType().FullName -eq 'System.Management.Automation.PSScriptCmdlet' })]
        $Cmdlet,

        [Parameter(Mandatory = $true)]
        [System.Management.Automation.SessionState]
        $SessionState,

        [Parameter(ParameterSetName = 'Filtered', ValueFromPipeline = $true)]
        [string[]]
        $Name
    )

    begin {
        $filterHash = @{ }
    }

    process {
        if ($null -ne $Name) {
            foreach ($string in $Name) {
                $filterHash[$string] = $true
            }
        }
    }

    end {
        # List of preference variables taken from the about_Preference_Variables help file in PowerShell version 4.0

        $vars = @{
            'ErrorView'                     = $null
            'FormatEnumerationLimit'        = $null
            'LogCommandHealthEvent'         = $null
            'LogCommandLifecycleEvent'      = $null
            'LogEngineHealthEvent'          = $null
            'LogEngineLifecycleEvent'       = $null
            'LogProviderHealthEvent'        = $null
            'LogProviderLifecycleEvent'     = $null
            'MaximumAliasCount'             = $null
            'MaximumDriveCount'             = $null
            'MaximumErrorCount'             = $null
            'MaximumFunctionCount'          = $null
            'MaximumHistoryCount'           = $null
            'MaximumVariableCount'          = $null
            'OFS'                           = $null
            'OutputEncoding'                = $null
            'ProgressPreference'            = $null
            'PSDefaultParameterValues'      = $null
            'PSEmailServer'                 = $null
            'PSModuleAutoLoadingPreference' = $null
            'PSSessionApplicationName'      = $null
            'PSSessionConfigurationName'    = $null
            'PSSessionOption'               = $null

            'ErrorActionPreference'         = 'ErrorAction'
            'DebugPreference'               = 'Debug'
            'ConfirmPreference'             = 'Confirm'
            'WhatIfPreference'              = 'WhatIf'
            'VerbosePreference'             = 'Verbose'
            'WarningPreference'             = 'WarningAction'
        }


        foreach ($entry in $vars.GetEnumerator()) {
            if (([string]::IsNullOrEmpty($entry.Value) -or -not $Cmdlet.MyInvocation.BoundParameters.ContainsKey($entry.Value)) -and
                ($PSCmdlet.ParameterSetName -eq 'AllVariables' -or $filterHash.ContainsKey($entry.Name))) {
                $variable = $Cmdlet.SessionState.PSVariable.Get($entry.Key)

                if ($null -ne $variable) {
                    if ($SessionState -eq $ExecutionContext.SessionState) {
                        Set-Variable -Scope 1 -Name $variable.Name -Value $variable.Value -Force -Confirm:$false -WhatIf:$false
                    }
                    else {
                        $SessionState.PSVariable.Set($variable.Name, $variable.Value)
                    }
                }
            }
        }

        if ($PSCmdlet.ParameterSetName -eq 'Filtered') {
            foreach ($varName in $filterHash.Keys) {
                if (-not $vars.ContainsKey($varName)) {
                    $variable = $Cmdlet.SessionState.PSVariable.Get($varName)

                    if ($null -ne $variable) {
                        if ($SessionState -eq $ExecutionContext.SessionState) {
                            Set-Variable -Scope 1 -Name $variable.Name -Value $variable.Value -Force -Confirm:$false -WhatIf:$false
                        }
                        else {
                            $SessionState.PSVariable.Set($variable.Name, $variable.Value)
                        }
                    }
                }
            }
        }

    } # end

} # function Get-CallerPreference

function GetHeaderWithAuthToken {

    $authToken = Get-AzAccessToken
    #Write-Host $authToken

    $header = @{
        'Content-Type'  = 'application/json'
        "Authorization" = "Bearer " + $authToken.Token
        "Accept"        = "application/json;odata=fullmetadata"
    }

    return $header
}

function InvokeRest($Uri, $Method, $Body, $params) {
    $authHeaders = GetHeaderWithAuthToken

    if ($Uri.Contains("?api-version"))
    {
        $fullUri = $Uri
    } else {
        $fullUri = $Uri + '?' + $ApiVersion
    }

    #Write-Host $fullUri

    if ($params) { $fullUri += '&' + $params }

    if ($body) { Write-Verbose $body }
    $result = Invoke-WebRequest -Uri $FullUri -Method $Method -Headers $authHeaders -Body $Body -UseBasicParsing
    #Write-Host $result
    $resObj = $result.Content | ConvertFrom-Json

    # Happens with Post commands ...
    if (-not $resObj) { return $resObj }

    Write-Verbose "ResObj: $resObj"

    # Need to make it unique because the rest call returns duplicate ones (bug)
    #if (Get-Member -inputobject $resObj -name "Value" -Membertype Properties) {
    #    return $resObj.Value | Sort-Object -Property id -Unique | Enrich
    #}
    #else {
        return $resObj
    #}
}


function WaitProvisioning($uri, $delaySec, $retryCount, $params) {
    Write-Verbose "Retrying $retryCount times every $delaySec seconds."
    Write-Verbose "Wait URI $uri"

    $tries = 0;
    $res = InvokeRest -Uri $uri -Method 'Get' -params $params

    while (-not ($res.properties.provisioningState -eq 'Succeeded')) {
        Write-Debug "$tries : ProvisioningState = $($res.properties.provisioningState)"
        if (-not ($tries -lt $retryCount)) {
            throw ("$retryCount retries of retrieving $uri with ProvisioningState = Succeeded failed")
        }
        Start-TestSleep -Seconds $delaySec
        $res = InvokeRest -Uri $uri -Method 'Get' -params $params
        $tries += 1
    }
    return $res
}

function CheckExists($uri){
    try {
        $authHeaders = GetHeaderWithAuthToken
        if ($Uri.Contains("?api-version"))
        {
            $fullUri = $uri
        } else {
            $fullUri = $uri + '?' + $ApiVersion
        }

        $result = Invoke-WebRequest -Uri $fullUri -Method 'Get' -Headers $authHeaders -UseBasicParsing | Select-Object -Expand StatusCode

        if ($result -eq 200){
            return $true
        } else {
            return $false
        }
    }
    catch {
        return $false
    }
}

Export-ModuleMember -Function   InvokeRest,
                                WaitProvisioning,
                                CheckExists
