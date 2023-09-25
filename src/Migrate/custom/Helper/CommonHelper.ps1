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

function GetHCIClusterARGQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies HCI Cluster Id.
        ${HCIClusterID}
    )

    process {
        $query = "resources | where type == 'microsoft.extendedlocation/customlocations'"
        $query += "| mv-expand ClusterId = properties['clusterExtensionIds']"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += "| extend CustomLocation = toupper(tostring(id))"
        $query += "| extend resourceBridgeID = toupper(tostring(properties['hostResourceId']))"
        $query += "| extend customLocationRegion = location"
        $query += "| join ("
        $query += "kubernetesconfigurationresources"
        $query += "| where type == 'microsoft.kubernetesconfiguration/extensions'"
        $query += "| where properties['ConfigurationSettings']['HCIClusterID'] =~ '$HCIClusterID'"
        $query += "| project ClusterId = id"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += ") on ClusterId"
        $query += "| join ("
        $query += "resources"
        $query += "| where type == 'microsoft.resourceconnector/appliances'"
        $query += "| where properties['provisioningState'] == 'Succeeded'"
        $query += "| extend statusOfTheBridge = properties['status']"
        $query += "| extend resourceBridgeID = toupper(tostring(id))"
        $query += ") on resourceBridgeID"

        return $query
    }
}

function GetStorageContainerARGQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies HCI Cluster Id.
        ${HCIClusterID}
    )

    process {
        $query = "resources | where type == 'microsoft.extendedlocation/customlocations'"
        $query += "| mv-expand ClusterId = properties['clusterExtensionIds']"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += "| extend CustomLocation = toupper(tostring(id))"
        $query += "| project ClusterId, CustomLocation"
        $query += "| join ("
        $query += "kubernetesconfigurationresources"
        $query += "| where type == 'microsoft.kubernetesconfiguration/extensions'"
        $query += "| where properties['ConfigurationSettings']['HCIClusterID'] =~ '$HCIClusterID'"
        $query += "| project ClusterId = id"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += ") on ClusterId"
        $query += "| join ("
        $query += "resources | where type == 'microsoft.azurestackhci/storagecontainers'"
        $query += "| extend CustomLocation = toupper(tostring(extendedLocation['name']))"
        $query += "| extend AvailableSizeMB = properties['status']['availableSizeMB']"
        $query += "| extend  ContainerSizeMB = properties['status']['containerSizeMB']"
        $query += ") on CustomLocation"
        $query += "| project-away ClusterId, CustomLocation"

        return $query
    }
}
function GetVirtualSwitchARGQuery {
    [Microsoft.Azure.PowerShell.Cmdlets.Migrate.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.String]
        # Specifies HCI Cluster Id.
        ${HCIClusterID}
    )

    process {
        $query = "resources | where type == 'microsoft.extendedlocation/customlocations'"
        $query += "| mv-expand ClusterId = properties['clusterExtensionIds']"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += "| extend CustomLocation = toupper(tostring(id))"
        $query += "| project ClusterId, CustomLocation"
        $query += "| join ("
        $query += "kubernetesconfigurationresources"
        $query += "| where type == 'microsoft.kubernetesconfiguration/extensions'"
        $query += "| where properties['ConfigurationSettings']['HCIClusterID'] =~ '$HCIClusterID'"
        $query += "| project ClusterId = id"
        $query += "| extend ClusterId = toupper(tostring(ClusterId))"
        $query += ") on ClusterId"
        $query += "| join ("
        $query += "resources"
        $query += "| where type == 'microsoft.azurestackhci/virtualnetworks'"
        $query += "| extend CustomLocation = toupper(tostring(extendedLocation['name']))"
        $query += ") on CustomLocation"
        $query += "| project-away ClusterId, CustomLocation, ClusterId1, CustomLocation1"

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

    # cannot be exactly one of these, but could be slighlty differnet (e.g. hololens2)
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