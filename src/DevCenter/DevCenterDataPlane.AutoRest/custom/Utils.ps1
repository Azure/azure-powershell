function GetEndpointFromResourceGraph {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenter.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true, HelpMessage = 'Name of the dev center')]
        [System.String]
        ${DevCenter},

        [Parameter(Mandatory = $false, HelpMessage = 'Name of the project')]
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
        $argResponse = Az.ResourceGraph\Search-AzGraph $query
        $devCenterUri = $argResponse.devCenterUri
        if (!$devCenterUri) {
            $azContext = Get-AzContext
            $tenantId = $azContext.Tenant.Id
            $errorHelp = "under the current tenant '$tenantId'. Please contact your admin to gain access to specific projects or " +
            "use a different tenant where you have access to projects."
            if (!$Project) {
                $noProjectFound = "No projects were found in the dev center '$DevCenter' " + $errorHelp
                Write-Error $noProjectFound -ErrorAction Stop
            } else {
                $noProjectFound = "No project '$Project' was found in the dev center '$DevCenter' " + $errorHelp
                Write-Error $noProjectFound -ErrorAction Stop
            }
        }
        return $devCenterUri.Substring(0, $devCenterUri.Length - 1)
    }
}

function GetDelayedActionTimeFromAllActions {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenter.DoNotExportAttribute()]
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
        $action = Az.DevCenter\Get-AzDevCenterDevDevBoxAction -Endpoint $Endpoint -ProjectName `
            $Project -DevBoxName $DevBoxName -UserId $UserId | ConvertTo-Json | ConvertFrom-Json
        $actionWithEarliestScheduledTime = $action | Where-Object { $null -ne $_.NextScheduledTime } |
        Sort-Object NextScheduledTime | Select-Object -First 1
        $newScheduledTime = $actionWithEarliestScheduledTime.NextScheduledTime + $DelayTime

        return $newScheduledTime
    }
}
function GetDelayedActionTimeFromActionName {
    [Microsoft.Azure.PowerShell.Cmdlets.DevCenter.DoNotExportAttribute()]
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
        $action = Az.DevCenter\Get-AzDevCenterDevDevBoxAction -Endpoint $Endpoint -ActionName $ActionName `
            -ProjectName $Project -DevBoxName $DevBoxName -UserId $UserId | ConvertTo-Json | ConvertFrom-Json
        $newScheduledTime = $action.NextScheduledTime + $DelayTime

        return $newScheduledTime
    }
}