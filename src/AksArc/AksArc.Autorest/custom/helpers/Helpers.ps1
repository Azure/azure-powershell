function GetConnectedClusterResourceURI {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $SubscriptionId,
        [System.String] $ResourceGroupName,
        [System.String] $ClusterName 
    )

    $Scope = "/"
    if ($SubscriptionId) {
        $Scope += "subscriptions/$SubscriptionId"
    }
    if ($ResourceGroupName) {
        $Scope += "/resourceGroups/$ResourceGroupName"
    }
    if ($ClusterName) {
        $Scope += "/providers/Microsoft.Kubernetes/connectedClusters/$ClusterName"
    }

    return $Scope
}

function Get-NodePoolInfoFromURI {
    param (
        [String] $NodePoolResourceURI
    )
    $normalizedResourceID = "/${NodePoolResourceURI}" -replace '/{2,}', '/'
    $splitResourceID = $normalizedResourceID -split '/'
    $subscriptionIndex = $null
    for ($i = 0; $i -lt $splitResourceID.Length; $i++) {
        if ($splitResourceID[$i] -eq "subscriptions") {
            $subscriptionIndex = $i + 1
            break
        }
    }
    $scope = GetConnectedClusterResourceURI -SubscriptionId $splitResourceID[$subscriptionIndex] `
        -ResourceGroupName $splitResourceID[$subscriptionIndex+2] `
        -ClusterName $splitResourceID[$subscriptionIndex+6]
    return @{
        "scope" = $scope
        "name" = $splitResourceID[$subscriptionIndex+12]
    }
}

function CreateConnectedCluster {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $SubscriptionId,
        [System.String] $ResourceGroupName,
        [System.String] $ClusterName, 
        [System.String] $Location,
        [System.String[]] ${AdminGroupObjectID}, 
        [System.Management.Automation.SwitchParameter] $EnableAzureRbac
    )

    # Validate GUIDS
    foreach ($id in $AdminGroupObjectID) {
        if ($id -match $guidRegex) {
            continue
        } else {
            $invalidGuid = $true
        }
    }

    if ($invalidGuid) {
        throw "Invalid AdminGroupObjectID. Not a valid GUID."
        return
    } elseif ($AdminGroupObjectID.Length -ne 0) {
        $AdminGroupObjectIDArr = $AdminGroupObjectID -join '", "'
        $AdminGroupObjectIDArr = '"' + $AdminGroupObjectIDArr + '"'
    }

    $EnableAzureRbacStr = "false"
    if ($EnableAzureRbac) {
        $EnableAzureRbacStr = "true"
    } 

    $json = 
@"
{
    "location": "$Location",
    "kind": "ProvisionedCluster",
    "identity": {
        "type": "SystemAssigned"
    },
    "properties": {
        "agentPublicKeyCertificate": "",
        "arcAgentProfile": {
            "desiredAgentVersion": "",
            "agentAutoUpgrade": "Enabled"
        },
        "aadProfile": {
            "enableAzureRBAC": $EnableAzureRbacStr, 
            "adminGroupObjectIDs": [$AdminGroupObjectIDArr]
        }
    }
}
"@  
    return Invoke-AzRestMethod -Path "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Kubernetes/connectedClusters/$ClusterName/?api-version=$ConnectedClusterAPIVersion" -Method PUT -payload $json
}

function UpdateConnectedCluster {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $SubscriptionId,
        [System.String] $ResourceGroupName,
        [System.String] $ClusterName, 
        [System.String[]] ${AdminGroupObjectID}
    )

    $ConnectedClusterResource = Invoke-AzRestMethod -Path "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Kubernetes/connectedClusters/$ClusterName/?api-version=$ConnectedClusterAPIVersion" -Method GET

    $Location = ($ConnectedClusterResource.Content | ConvertFrom-Json).location
    $EnableAzureRbac = ($ConnectedClusterResource.Content | ConvertFrom-Json).properties.aadProfile.enableAzureRBAC

    return CreateConnectedCluster -SubscriptionId $SubscriptionId -ResourceGroupName $ResourceGroupName -ClusterName $ClusterName -Location $Location -AdminGroupObjectID $AdminGroupObjectID -EnableAzureRbac:$EnableAzureRbac
}

function GenerateSSHKey {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $ClusterName
    )
    $SshPublicKeyObj = [Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.LinuxProfilePropertiesSshPublicKeysItem]::New()
    $suffix = Get-Random -Minimum -1000 -Maximum 9999
    $filename = $ClusterName + "_" + $suffix
    $sshKeyDir = Join-Path -Path $HOME -ChildPath ".ssh"
    New-Item -Path $sshKeyDir -ItemType Directory -Force
    $sshKeyFile = Join-Path -Path $sshKeyDir -ChildPath $filename

    if (!(Get-Command "ssh-keygen")) {
        throw "ssh-keygen command not found. Please install OpenSSH client tools and ensure ssh-keygen is in your PATH."
    }
    if ($PSVersionTable.PSVersion.Major -eq 7) {
        ssh-keygen -b 2048 -t rsa -f $sshKeyFile -q -N ''
    } else {
        ssh-keygen -b 2048 -t rsa -f $sshKeyFile -q -N '""'
    }
    
    $publickeyfile = $sshKeyFile + ".pub"
    $publicKey = Get-Content -Path $publickeyfile
    
    $SshPublicKeyObj.KeyData = $publicKey
    return $SshPublicKeyObj
}

function ConvertCustomLocationNameToID {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $CustomLocationName,
        [System.String] $SubscriptionId,
        [System.String] $ResourceGroupName
    )

    if ($CustomLocationName -match $armIDRegex) {
        return $CustomLocationName
    }

    return "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.ExtendedLocation/customLocations/$CustomLocationName"
}