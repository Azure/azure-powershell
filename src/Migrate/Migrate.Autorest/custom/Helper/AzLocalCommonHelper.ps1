function CheckResourceGraphModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.ResourceGraph" }
        if ($null -eq $module) {
            $message = "Az.ResourceGraph Module must be installed to run this command. Please run 'Install-Module -Name Az.ResourceGraph' to install and continue."
            throw $message
        }
    }
}

function CheckResourcesModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.Resources" }
        if ($null -eq $module) {
            $message = "Az.Resources Module must be installed to run this command. Please run 'Install-Module -Name Az.Resources' to install and continue."
            throw $message
        }
    }
}

function CheckStorageModuleDependency {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param() 

    process {
        $module = Get-Module -ListAvailable | Where-Object { $_.Name -eq "Az.Storage" }
        if ($null -eq $module) {
            $message = "Az.Storage Module must be installed to run this command. Please run 'Install-Module -Name Az.Storage' to install and continue."
            throw $message
        }
    }
}

function GetARGQueryForArcResourceBridge {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies HCI Cluster Id.
        ${HCIClusterID}
    )

    process {
        $query = @"
resources | where type == 'microsoft.extendedlocation/customlocations'
| mv-expand ClusterId = properties['clusterExtensionIds']
| extend ClusterId = toupper(tostring(ClusterId))
| extend CustomLocation = toupper(tostring(id))
| extend resourceBridgeID = toupper(tostring(properties['hostResourceId']))
| extend customLocationRegion = location
| join (
    kubernetesconfigurationresources
    | where type == 'microsoft.kubernetesconfiguration/extensions'
    | where properties['ConfigurationSettings']['HCIClusterID'] =~ '$HCIClusterID'
    | project ClusterId = id
    | extend ClusterId = toupper(tostring(ClusterId))
) on ClusterId
| join (
    resources
    | where type == 'microsoft.resourceconnector/appliances'
    | where properties['provisioningState'] == 'Succeeded'
    | extend statusOfTheBridge = properties['status']
    | extend resourceBridgeID = toupper(tostring(id))
) on resourceBridgeID
"@
        return $query
    }
}

function IsReservedOrTrademarked {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies VM name.
        ${Value}
    )

    $uppercased = $Value.ToUpper();

    # cannot be exactly one of these, but could be slightly different (e.g. hololens2)
    $reservedWords = @(
        "ACCESS",
        "APP_CODE",
        "APP_THEMES",
        "APP_DATA",
        "APP_GLOBALRESOURCES",
        "APP_LOCALRESOURCES",
        "APP_WEBREFERENCES",
        "APP_BROWSERS",
        "AZURE",
        "BING",
        "BIZSPARK",
        "BIZTALK",
        "CORTANA",
        "DIRECTX",
        "DOTNET",
        "DYNAMICS",
        "EXCEL",
        "EXCHANGE",
        "FOREFRONT",
        "GROOVE",
        "HOLOLENS",
        "HYPERV",
        "KINECT",
        "LYNC",
        "MSDN",
        "O365",
        "OFFICE",
        "OFFICE365",
        "ONEDRIVE",
        "ONENOTE",
        "OUTLOOK",
        "POWERPOINT",
        "SHAREPOINT",
        "SKYPE",
        "VISIO",
        "VISUALSTUDIO"
    )

    # The following words can't be used as either a whole word or a substring in the name:
    $microsoft = "MICROSOFT";
    $windows = "WINDOWS";

    # The following words can't be used at the start of a resource name, but can be used later in the name:
    $startLogin = "LOGIN";
    $startXbox = "XBOX";

    if ($uppercased.startsWith($startLogin) -or $uppercased.startsWith($startXbox)) {
        return $true;
    }

    if ($uppercased.contains($microsoft) -or $uppercased.contains($windows)) {
        return $true;
    }

    foreach ($reservedName in $reservedWords) {
        if ($uppercased -eq $reservedName) {
            return $true;
        }
    }

    return $false;
}

function GenerateHashForArtifact {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies resource group name.
        ${Artifact}
    )

    $hashCode = 0
    $artifactLength = $Artifact.Length
    $tempItemLength = 0
    if ($artifactLength -gt 0) {
        while ($tempItemLength -lt $artifactLength) {
            $hashCode = ((($hashCode -shl 5) - $hashCode) + $Artifact[$tempItemLength++] -bor 0)
            
            # Treat as Double, then convert to Bytes, then convert back to Int32 to match JavaScript behavior
            $hashCode = [System.BitConverter]::ToInt32([System.BitConverter]::GetBytes($hashCode), 0)
        }
    }

    if ($hashCode -lt 0) {
        return -1 * $hashCode
    }
    else {
        return $hashCode
    }
}

function InvokeAzMigrateGetCommandWithRetries {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies the name of Az.Migrate command.
        ${CommandName},

        [Parameter(Mandatory)]
        [System.Collections.Hashtable]
        # Specifies the parameters for Az.Migrate command.
        ${Parameters},

        [Parameter()]
        [System.Int32]
        # Specifies the maximum number of retries.
        ${MaxRetryCount} = 3,

        [Parameter()]
        [System.Int32]
        # Specifies the delay between retries in seconds.
        ${RetryDelayInSeconds} = 30,

        [Parameter()]
        [System.String]
        # Specifies the error message to throw if command fails.
        ${ErrorMessage} = "Internal Az.Migrate commands failed to execute."
    )

    process {
        # Filter out ErrorAction and ErrorVariable from the parameters
        $params = @{}
        foreach ($key in $Parameters.Keys) {
            if ($key -ne "ErrorAction" -and $key -ne "ErrorVariable") {
                $params[$key] = $Parameters[$key]
            }
        }

        # Extract user-specified ErrorAction and ErrorVariable or defaults
        # but do not include them in $params
        if ($Parameters.ContainsKey("ErrorVariable")) {
            $errorVariable = $Parameters["ErrorVariable"]
        }
        else
        {
            $errorVariable = "notPresent"
        }

        if ($Parameters.ContainsKey("ErrorAction")) {
            $errorAction = $Parameters["ErrorAction"]
        }
        else
        {
            $errorAction = "Continue"
        }

        for ($i = 0; $i -le $MaxRetryCount; $i++) {
            try {
                $result = & $CommandName @params -ErrorVariable $errorVariable -ErrorAction $errorAction

                if ($null -eq $result) {
                    throw $ErrorMessage
                }

                break
            }
            catch {
                if ($i -lt $MaxRetryCount) {
                    Start-Sleep -Seconds $RetryDelayInSeconds
                }
                else {
                    throw "Get command failed after $MaxRetryCount retries. Error: $($_.Exception)"
                }
            }
        }

        return $result
    }
}

function ValidateReplication {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param (
        [Parameter(Mandatory)]
        [PSCustomObject]
        ${Machine},

        [Parameter(Mandatory)]
        [System.String]
        ${MigrationType}
    )
    # Check if the VM is already protected
    $protectedItem = Az.Migrate\Get-AzMigrateLocalServerReplication `
        -DiscoveredMachineId $Machine.Id  `
        -ErrorAction SilentlyContinue
    if ($null -ne $protectedItem) {
        throw $VmReplicationValidationMessages.AlreadyInReplication
    }

    # Check the VM power status
    if ($Machine.PowerStatus -eq $PowerStatus.OffVMware -or $Machine.PowerStatus -eq $PowerStatus.OffHyperV) {
        throw $VmReplicationValidationMessages.VmPoweredOff
    }

    # Hyper-V scenario checks
    if ($MigrationType -eq $AzLocalInstanceTypes.HyperVToAzLocal) {
        # Hyper-V VMs with 'otherguestfamily' OS type and missing OS name could also mean Hyper-V Integration Services are not running
        if ([string]::IsNullOrEmpty($Machine.OperatingSystemDetailOSType) -or
            ($Machine.OperatingSystemDetailOSType -eq $OsTypes.OtherGuestFamily -and [string]::IsNullOrEmpty($Machine.GuestOSDetailOsname)))
        {
            throw $VmReplicationValidationMessages.HyperVIntegrationServicesNotRunning
        }

        # Hyper-V VMs should be highly available
        if (![string]::IsNullOrEmpty($Machine.ClusterId) -and $Machine.HighAvailability -eq $HighAvailability.NO) {
            throw $VmReplicationValidationMessages.VmNotHighlyAvailable
        }
    }

    # VMware scenario checks
    if ($MigrationType -eq $AzLocalInstanceTypes.VMwareToAzLocal) {
        # VMware tools should be running to support static ip migration
        if ($Machine.VMwareToolsStatus -eq $VMwareToolsStatus.NotRunning) {
            Write-Warning $VmReplicationValidationMessages.VmWareToolsNotRunning
        }

        if ($Machine.VMwareToolsStatus -eq $VMwareToolsStatus.NotInstalled) {
            Write-Warning $VmReplicationValidationMessages.VmWareToolsNotInstalled
        }
    }

    # Only OS type of windowsguest and linuxguest are supported for Hyper-V and VMware scenarios
    if ($Machine.OperatingSystemDetailOSType -ne $OsTypes.WindowsGuest -and
        $Machine.OperatingSystemDetailOSType -ne $OsTypes.LinuxGuest)
    {
        Write-Warning $VmReplicationValidationMessages.OsTypeNotSupported
    }
}

function Test-AzureResourceIdFormat {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory = $true)]
        [string] $Data,
        
        [Parameter(Mandatory = $true)]
        [string] $Format
    )

    try {
        if ([string]::IsNullOrWhiteSpace($Data)) {
            return $false
        }

        # Find where format string starts (after first /)
        $firstTokenEnd = $Format.IndexOf("/", 1)
        if ($firstTokenEnd -eq -1) {
            return $false
        }

        $formatPrefix = $Format.Substring(0, $firstTokenEnd)
        $matchIndex = $Data.ToLower().IndexOf($formatPrefix.ToLower())

        if ($matchIndex -eq -1) {
            return $false
        }

        $processData = $Data.Substring($matchIndex)
        $processFormat = $Format
        $tokens = @()
        
        $counter = 0
        while ($true) {
            $markerPattern = "{$counter}"
            $markerStartIndex = $processFormat.IndexOf($markerPattern)

            if ($markerStartIndex -eq -1) {
                break
            }

            $markerEndIndex = $processData.IndexOf("/", $markerStartIndex)

            if ($markerEndIndex -eq -1) {
                $token = $processData.Substring($markerStartIndex)
                if ([string]::IsNullOrWhiteSpace($token)) {
                    return $false
                }
                $tokens += $token
            }
            else {
                $token = $processData.Substring($markerStartIndex, $markerEndIndex - $markerStartIndex)
                if ([string]::IsNullOrWhiteSpace($token)) {
                    return $false
                }
                $tokens += $token
                $processData = $processData.Substring($markerEndIndex)
                $processFormat = $processFormat.Substring($markerStartIndex + $markerPattern.Length)
            }

            $counter++
        }

        # Verify format matches with the extracted tokens
        $formatWithTokens = $Format
        for ($i = 0; $i -lt $tokens.Count; $i++) {
            $formatWithTokens = $formatWithTokens -replace "\{$i\}", $tokens[$i]
        }

        return $Data.ToLower() -like $formatWithTokens.ToLower()
    }
    catch
    {
        return $false
    }
}