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
        if ($module -eq $null) {
            $message = "Az.ResourceGraph Module must be installed to run this command. " `
                + "Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
            throw $message
        }

        $query = "Resources |where type =~'Microsoft.devcenter/projects' "
        if ($Project -ne $null) {
            $query += "| where name =~ '$Project' "
        }
        $query += "| extend devCenterArr = split(properties.devCenterId, '/') " `
            + "| extend devCenterName = devCenterArr[array_length(devCenterArr) -1]  "`
            + "| where devCenterName =~ '$DevCenter' | take 1 "`
            + "| extend devCenterUri = properties.devCenterUri | project devCenterUri"
        $argResponse = Az.ResourceGraph\Search-AzGraph $query | ConvertTo-Json | ConvertFrom-Json
        $devCenterUri = $argResponse.devCenterUri
        return $devCenterUri.Substring(0, $devCenterUri.Length-1)
    }
}