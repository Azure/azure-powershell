function Add-AzEventHubBoundDynamicParameter {
    [Microsoft.Azure.PowerShell.Cmdlets.EventHub.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${CommandName},

        [Parameter(Mandatory)]
        [System.Collections.IDictionary]
        ${BoundParameters},

        [Parameter(Mandatory)]
        [System.Collections.IDictionary]
        ${TargetParameters},

        [System.String[]]
        ${ExcludedParameter}
    )

    $command = @(Get-Command -Name $CommandName -ErrorAction Stop)[0]
    while ($command.CommandType -eq [System.Management.Automation.CommandTypes]::Alias) {
        $command = Get-Command -Name $command.ResolvedCommandName -ErrorAction Stop
    }

    if (-not [System.Management.Automation.IDynamicParameters].IsAssignableFrom($command.ImplementingType)) {
        return
    }

    $instance = [System.Activator]::CreateInstance($command.ImplementingType)
    foreach ($parameterName in $instance.GetDynamicParameters().Keys) {
        if (($parameterName -notin $ExcludedParameter) -and $BoundParameters.ContainsKey($parameterName)) {
            $TargetParameters[$parameterName] = $BoundParameters[$parameterName]
        }
    }
}
