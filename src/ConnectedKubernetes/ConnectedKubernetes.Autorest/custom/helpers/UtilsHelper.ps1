# The syntax of the configuration settings and protected settings is a hashtable
# of hashtables where the final values must be strings.  So it might look like
# this:
#
# {
#   "feature1": {
#     "setting1": "value1",
#     "setting2": "value2",
#     ...
#   },
#   "feature2": {
#     ...
#   }
# }
#
# This function confirms that format.
function Test-ConfigurationSyntax {
    param(
        [string]$name
    )
    $configuration = $PSBoundParameters[$name]

    foreach ($key in $configuration.Keys) {
        if ('Hashtable' -ne $configuration[$key].GetType().Name) {
            Write-Error "$name[$key] is not a hashtable"
        }
        foreach ($subkey in $configuration[$key].Keys) {
            if ('String' -ne $configuration[$key][$subkey].GetType().Name) {
                Write-Error "$name[$key][$subkey] is not a string"
            }
        }
    }
}

function ConvertTo-ArcAgentryConfiguration {

    param(
        [hashtable]$ConfigurationSetting,
        [hashtable]$ConfigurationProtectedSetting,
        [boolean]$CCRP
    )

    if ($CCRP) {
        # This ensures that when a new feature is implemented, only the ConfigDP
        # needs to change and not the Powershell script (or az CLI).
        $arcAgentryConfigs = New-Object System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]
    }
    else {
        $arcAgentryConfigs = New-Object System.Collections.ArrayList
    }

    # Do not send protected settings to CCRP
    $combinedKeys = $ConfigurationSetting.Keys + $RedactedProtectedConfiguration.Keys
    $combinedKeys = $combinedKeys | Get-Unique 
    foreach ($feature in $combinedKeys) {
        $ArcAgentryConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]@{
            Feature            = $feature
            "Setting"          = ($ConfigurationSetting.ContainsKey($feature) ? $ConfigurationSetting[$feature] : @{})
            "ProtectedSetting" = ($RedactedProtectedConfiguration.ContainsKey($feature) ? $RedactedProtectedConfiguration[$feature] : @{})
        }
        $arcAgentryConfigs.Add($ArcAgentryConfiguration)
    }

    return $arcAgentryConfigs
}