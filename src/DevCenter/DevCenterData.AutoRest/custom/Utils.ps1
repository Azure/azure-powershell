function GetEndpointFromResourceGraph {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory, HelpMessage = 'Name of the dev center')]
        [System.String]
        ${DevCenter},

        [Parameter(HelpMessage = 'Name of the project')]
        [System.String]
        ${Project}


    ) 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.ResourceGraph" }
        if (!$module) {
            $noModuleFoundMessage = "Az.ResourceGraph Module must be installed to run this command. " `
                + "Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
            Write-Error $noModuleFoundMessage -ErrorAction Stop
        }

        $query = "Resources |where type =~'Microsoft.devcenter/projects' "
        if ($Project) {
            $query += "| where name =~ '$Project' "
        }
        $query += "| extend devCenterArr = split(properties.devCenterId, '/') " `
            + "| extend devCenterName = devCenterArr[array_length(devCenterArr) -1]  "`
            + "| where devCenterName =~ '$DevCenter' | take 1 "`
            + "| extend devCenterUri = properties.devCenterUri | project devCenterUri"
        $argResponse = Az.ResourceGraph\Search-AzGraph -Query $query
        $devCenterUri = $argResponse.devCenterUri
        if (!$devCenterUri) {
            $azContext = Get-AzContext
            $tenantId = $azContext.Tenant.Id
            $errorHelp = "under the current tenant '$tenantId'. Please contact your admin to gain access to specific projects or " +
            "use a different tenant where you have access to projects."
            if (!$Project) {
                $noProjectFound = "No projects were found in the dev center '$DevCenter' " + $errorHelp
                Write-Error $noProjectFound -ErrorAction Stop
            }
            else {
                $noProjectFound = "No project '$Project' was found in the dev center '$DevCenter' " + $errorHelp
                Write-Error $noProjectFound -ErrorAction Stop
            }
        }
        return $devCenterUri.Substring(0, $devCenterUri.Length - 1)
    }
}

function GetDelayedActionTimeFromAllActions {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true, HelpMessage = 'Endpoint URL')]
        [System.String]
        ${Endpoint},

        [Parameter(Mandatory = $true, HelpMessage = 'Name of the project')]
        [System.String]
        ${Project},

        [Parameter(Mandatory = $true, HelpMessage = 'Name of the dev box')]
        [System.String]
        ${DevBoxName},

        [Parameter(Mandatory)]
        [System.TimeSpan]
        ${DelayTime},

        [Parameter(HelpMessage = 'User id')]
        [System.String]
        ${UserId}

    ) 

    process {
        $action = Az.DevCenterdata.internal\Get-AzDevCenterUserDevBoxAction -Endpoint $Endpoint -ProjectName `
            $Project -DevBoxName $DevBoxName -UserId $UserId | ConvertTo-Json | ConvertFrom-Json

        if (!$action) {
            $action = "No actions were found."
            Write-Error $action -ErrorAction Stop
        }
        
        $excludedDate = [DateTime]::ParseExact("0001-01-01T00:00:00.0000000", "yyyy-MM-ddTHH:mm:ss.fffffff", $null)
        $actionWithEarliestScheduledTime = $action |
        Where-Object { $null -ne $_.NextScheduledTime -and $_.NextScheduledTime -ne $excludedDate } |
        Sort-Object NextScheduledTime | Select-Object -First 1



        $newScheduledTime = $actionWithEarliestScheduledTime.NextScheduledTime + $DelayTime

        return $newScheduledTime
    }
}
function GetDelayedActionTimeFromActionName {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true, HelpMessage = 'Name of the action')]
        [System.String]
        ${ActionName},

        [Parameter(Mandatory = $true, HelpMessage = 'Endpoint URL')]
        [System.String]
        ${Endpoint},

        [Parameter(Mandatory = $true, HelpMessage = 'Name of the project')]
        [System.String]
        ${Project},

        [Parameter(Mandatory = $true, HelpMessage = 'Name of the dev box')]
        [System.String]
        ${DevBoxName},

        [Parameter(Mandatory)]
        [System.TimeSpan]
        ${DelayTime},

        [Parameter(HelpMessage = 'User id')]
        [System.String]
        ${UserId}
        
    ) 

    process {
        $action = Az.DevCenterdata.internal\Get-AzDevCenterUserDevBoxAction -Endpoint $Endpoint -ActionName $ActionName `
            -ProjectName $Project -DevBoxName $DevBoxName -UserId $UserId | ConvertTo-Json | ConvertFrom-Json
        
        $newScheduledTime = $action.NextScheduledTime + $DelayTime

        return $newScheduledTime
    }
}

function ValidateAndProcessEndpoint {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenterdata.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true, HelpMessage = 'Endpoint URL')]
        [System.String]
        ${Endpoint}     
    ) 

    process {
        $regex = "(https)://.+.*\.(devcenter.azure-test.net|devcenter.azure.com)[/]?$"
        if ($Endpoint -notmatch $regex) {
            $incorrectEndpoint = "The endpoint $Endpoint is invalid. Please ensure that the " `
                + "endpoint starts with 'https' and is properly formatted. Use " +
            "'Get-AzDevCenterAdminProject' to view the endpoint of a specific project. " +
            "Contact your admin for further assistance."

            Write-Error $incorrectEndpoint -ErrorAction Stop
        }

        if ($Endpoint.EndsWith("/")) {
            return $Endpoint.Substring(0, $Endpoint.Length - 1)
        }

        return $Endpoint

    }
}