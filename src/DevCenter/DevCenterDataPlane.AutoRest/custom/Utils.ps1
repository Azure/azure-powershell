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
        if ($null -eq $module) {
            $message = "Az.ResourceGraph Module must be installed to run this command. " `
                + "Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
            throw $message
        }

        $query = "Resources |where type =~'Microsoft.devcenter/projects' "
        if ($null -ne $Project) {
            $query += "| where name =~ '$Project' "
        }
        $query += "| extend devCenterArr = split(properties.devCenterId, '/') " `
            + "| extend devCenterName = devCenterArr[array_length(devCenterArr) -1]  "`
            + "| where devCenterName =~ '$DevCenter' | take 1 "`
            + "| extend devCenterUri = properties.devCenterUri | project devCenterUri"
        $argResponse = Az.ResourceGraph\Search-AzGraph $query | ConvertTo-Json | ConvertFrom-Json
        $devCenterUri = $argResponse.devCenterUri
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