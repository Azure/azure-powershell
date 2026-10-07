function Get-AzComputeDynamicParameters {
    [Microsoft.Azure.PowerShell.Cmdlets.Compute.DoNotExportAttribute()]
    [CmdletBinding()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        ${CommandName}
    )

    $dynamicParameters = [System.Management.Automation.RuntimeDefinedParameterDictionary]::new()
    $command = Get-Command -Name $CommandName -ErrorAction Ignore
    if ($command -and [System.Management.Automation.IDynamicParameters].IsAssignableFrom($command.ImplementingType)) {
        $instance = [System.Activator]::CreateInstance($command.ImplementingType)
        foreach ($entry in $instance.GetDynamicParameters().GetEnumerator()) {
            $dynamicParameters.Add($entry.Key, $entry.Value)
        }
    }

    return $dynamicParameters
}
