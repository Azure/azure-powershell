---
external help file:
Module Name: Az.Storage
online version: https://learn.microsoft.com/powershell/module/az.storage/new-azstorageblobaccesspointconfiguration
schema: 2.0.0
---

# New-AzStorageBlobAccessPointConfiguration

## SYNOPSIS
Create a Blob Access Point configuration.

## SYNTAX

### CreateExpanded (Default)
```
New-AzStorageBlobAccessPointConfiguration -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Location <String> -SourceType <String> [-SubscriptionId <String>] [-Description <String>] [-State <String>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### Create
```
New-AzStorageBlobAccessPointConfiguration -AccountName <String> -Name <String> -ResourceGroupName <String>
 -Resource <IBlobAccessPointConfiguration> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob]
 [-NoWait] [-Confirm] [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzStorageBlobAccessPointConfiguration -AccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonFilePath <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzStorageBlobAccessPointConfiguration -AccountName <String> -Name <String> -ResourceGroupName <String>
 -JsonString <String> [-SubscriptionId <String>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-Confirm]
 [-WhatIf] [<CommonParameters>]
```

## DESCRIPTION
Create a Blob Access Point configuration.

## EXAMPLES

### Example 1: Create a configuration with a complete source body
```powershell
$configuration = [Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.BlobAccessPointConfiguration]::FromJsonString(@'
{
  "location": "eastus",
  "properties": {
    "source": {
      "sourceType": "S3Compatible",
      "connection": { "connectionType": "Endpoint", "endpoint": "https://s3.example.com", "tlsVerification": "Perform" },
      "auth": { "authType": "AccessKey", "accessKeyId": "my-access-key-id" }
    }
  }
}
'@)
$configuration.Source.Auth.SecretAccessKey = Read-Host "Secret access key" -AsSecureString
New-AzStorageBlobAccessPointConfiguration -ResourceGroupName "myResourceGroup" -AccountName "mystorageaccount" -Name "myaccesspoint" -Resource $configuration
```

Creates an S3-compatible configuration with a secure credential.
The Resource parameter supports the complete polymorphic source, connection, and authentication settings.
JsonFilePath and JsonString accept REST-shaped bodies; protect any credential-bearing files and do not write them to logs or source control.

## PARAMETERS

### -AccountName
The name of the storage account within the specified resource group.
Storage account names must be between 3 and 24 characters in length and use numbers and lower-case letters only.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -AsJob
Run the command as a job

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -DefaultProfile
The DefaultProfile parameter is not functional.
Use the SubscriptionId parameter when available if executing the cmdlet against a different subscription.

```yaml
Type: System.Management.Automation.PSObject
Parameter Sets: (All)
Aliases: AzureRMContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Description
An arbitrary description of the Blob Access Point configuration.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Create operation

```yaml
Type: System.String
Parameter Sets: CreateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The geo-location where the resource lives

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Blob Access Point configuration.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: BlobAccessPointConfigurationName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NoWait
Run the command asynchronously

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Resource
A BlobAccessPointConfiguration is a tracked Azure resource modeled as a sub-resource of a Storage Account.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConfiguration
Parameter Sets: Create
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SourceType
The source type.
This value determines the remaining shape of the source object.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -State
The configuration state.
A configuration is created in the Active state when this value is not specified.

```yaml
Type: System.String
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.
The value must be an UUID.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Tag
Resource tags.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: CreateExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Confirm
Prompts you for confirmation before running the cmdlet.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: cf

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WhatIf
Shows what would happen if the cmdlet runs.
The cmdlet is not run.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: (All)
Aliases: wi

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConfiguration

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Storage.Models.IBlobAccessPointConfiguration

## NOTES

## RELATED LINKS
