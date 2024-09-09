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
        [hashtable]$RedactedProtectedConfiguration,
        [boolean]$CCRP
    )

    if ($CCRP) {
        # This ensures that when a new feature is implemented, only the ConfigDP
        # needs to change and not the Powershell script (or az CLI).
        $arcAgentryConfigs = New-Object System.Collections.Generic.List[Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]
        $combinedKeys = $ConfigurationSetting.Keys 
    }
    else {
        $arcAgentryConfigs = New-Object System.Collections.ArrayList
        $combinedKeys = $ConfigurationSetting.Keys + $RedactedProtectedConfiguration.Keys
        $combinedKeys = $combinedKeys | Select-Object -Unique
    }

    Write-Debug "Combined keys: $combinedKeys"

    # Do not send protected settings to CCRP
    foreach ($feature in $combinedKeys) {

        $settings = ($ConfigurationSetting.ContainsKey($feature) ? $ConfigurationSetting[$feature] : @{})
        if ($CCRP) {
            $ArcAgentryConfiguration = [Microsoft.Azure.PowerShell.Cmdlets.ConnectedKubernetes.Models.Api20240715Preview.ArcAgentryConfigurations]@{
                Feature = $feature
                Setting = $settings
            }
        }
        else {
            $protectedSettings = ($RedactedProtectedConfiguration.ContainsKey($feature) ? $RedactedProtectedConfiguration[$feature] : @{})
            $ArcAgentryConfiguration = @{
                Feature  = $feature
                Settings = $settings
                ProtectedSettings = $protectedSettings
            }
        }
        $null = $arcAgentryConfigs.Add($ArcAgentryConfiguration)
    }

    # Force only returning the list and not anything else!
    return (, $arcAgentryConfigs)
}

# Note that this method edits the script variable PSBoundParameters.
function Convert-ProxySetting {
    param(
        [string]$name,
        [ref]$ConfigurationProtectedSetting
    )

    try {
        $value = Get-Variable "Script:$name" -ValueOnly

        $valueStr = $value.ToString()
        $valueStr = $valueStr -replace ',', '\,'
        $valueStr = $valueStr -replace '/', '\/'
        $ConfigurationProtectedSetting["proxy"][$name] = $valueStr

        # Note how we are removing k8s parameters from the list of parameters
        # to pass to the internal (creates ARM object) command.
        $Null = ${Script:PSBoundParameters}.Remove($name)
    }
    catch {
        # The variable does not exist so nothing to be done.
        Write-Error "Variable $name does not exist" -ErrorAction SilentlyContinue
    }
    return $ConfigurationProtectedSetting
}