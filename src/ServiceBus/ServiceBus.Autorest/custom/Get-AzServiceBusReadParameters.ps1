function Get-AzServiceBusReadParameters {
    [Microsoft.Azure.PowerShell.Cmdlets.ServiceBus.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${CommandName},

        [Parameter(Mandatory)]
        [System.Collections.IDictionary]
        ${BoundParameters}
    )

    $command = @(Get-Command -Name $CommandName -ErrorAction Stop)[0]
    while ($command.CommandType -eq [System.Management.Automation.CommandTypes]::Alias) {
        $command = Get-Command -Name $command.ResolvedCommandName -ErrorAction Stop
    }

    $parameterNames = @($command.Parameters.Keys)
    $parameterNames += @($command.Parameters.Values | ForEach-Object { $_.Aliases })

    $readParameters = @{}
    foreach ($parameter in $BoundParameters.GetEnumerator()) {
        if ($parameter.Key -in $parameterNames) {
            $readParameters[$parameter.Key] = $parameter.Value
        }
    }

    return $readParameters
}
