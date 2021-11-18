### Example 1: List all Metadatas
```powershell
PS C:\> Get-AzSentinelMetadata -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"

{{ Add output here }}
```

This command lists all Metadatas under a Microsoft Sentinel workspace.

### Example 2: Get a Metadata
```powershell
PS C:\> Get-AzSentinelMetadata -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Name "myMetadataName"

{{ Add output here }}
```

This command gets a Metadata.

### Example 3: Get a Metadata by object Id
```powershell
PS C:\> $Metadatas = Get-AzSentinelMetadata -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName"
PS C:\> $Metadatas[0] | Get-AzSentinelMetadata

{{ Add output here }}
```

This command gets a Metadata by object