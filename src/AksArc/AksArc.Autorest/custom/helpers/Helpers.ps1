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

function CreateConnectedCluster {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $SubscriptionId,
        [System.String] $ResourceGroupName,
        [System.String] $ClusterName, 
        [System.String] $Location,
        [System.String[]] ${AdminGroupObjectID}
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

    $APIVersion = "2024-01-01"
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
            "enableAzureRBAC": false, 
            "adminGroupObjectIDs": [$AdminGroupObjectIDArr]
        }
    }
}
"@  
    $null = Invoke-AzRestMethod -Path "/subscriptions/$SubscriptionId/resourceGroups/$ResourceGroupName/providers/Microsoft.Kubernetes/connectedClusters/$ClusterName/?api-version=$APIVersion" -Method PUT -payload $json
}

function GenerateSSHKey {
    [Microsoft.Azure.PowerShell.Cmdlets.AksArc.DoNotExportAttribute()]
    param(
        [System.String] $ClusterName
    )
    $SshPublicKeyObj = [Microsoft.Azure.PowerShell.Cmdlets.AksArc.Models.LinuxProfilePropertiesSshPublicKeysItem]::New()
    $suffix = Get-Random -Minimum -1000 -Maximum 9999
    $filename = $ClusterName + "_" + $suffix
    $sshkeydir = $HOME + "\.ssh\" + $filename

    ssh-keygen -b 2048 -t rsa -f $sshkeydir -q -N ''
    
    $publickeyfile = $sshkeydir + ".pub"
    $publicKey = Get-Content -Path $publickeyfile
    
    $SshPublicKeyObj.KeyData = $publicKey
    return $SshPublicKeyObj
}