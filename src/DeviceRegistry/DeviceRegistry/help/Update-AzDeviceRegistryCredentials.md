---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistrycredentials
schema: 2.0.0
---

# Update-AzDeviceRegistryCredentials

## SYNOPSIS
Update a Credential

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryCredentials -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryCredentials -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryCredentials -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryCredentials -InputObject <IDeviceRegistryIdentity> [-Tag <Hashtable>]
 [-DefaultProfile <PSObject>] [-AsJob] [-NoWait] [-WhatIf] [-Confirm]
 [<CommonParameters>]
```

## DESCRIPTION
Update a Credential

## EXAMPLES

### Example 1: Update credentials tags using expanded parameters
```powershell
Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -Tag @{"environment" = "production"; "team" = "iot"; "updated" = "true"}
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:45:33 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "updated": "true"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates the tags on the credentials resource.
Note: Credentials are system-managed, only tags can be updated by users.

### Example 2: Update credentials via identity object
```powershell
$credentialsIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
}
Update-AzDeviceRegistryCredentials -InputObject $credentialsIdentity -Tag @{"environment" = "staging"; "team" = "iot"}
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:46:12 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "staging",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates the credentials using an identity object parameter.

### Example 3: Update credentials from a JSON file
```powershell
Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\credentials\update.json"
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:47:05 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "version": "2.0"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates credentials from a JSON file containing the update payload.

### Example 4: Update credentials from a JSON string
```powershell
$jsonString = @"
{
    "tags": {
        "environment": "production",
        "team": "iot",
        "version": "2.0"
    }
}
"@

Update-AzDeviceRegistryCredentials -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default
Location                     : eastus2
Name                         : default
ProvisioningState            : Succeeded
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 10:30:15 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 10:47:28 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "version": "2.0"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials
```

Updates credentials from a JSON string containing the update configuration.

## PARAMETERS

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

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -JsonFilePath
Path of Json file supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonFilePath
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -JsonString
Json string supplied to the Update operation

```yaml
Type: System.String
Parameter Sets: UpdateViaJsonString
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceName
The name of the namespace.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

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

### -ResourceGroupName
The name of the resource group.
The name is case insensitive.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
Aliases:

Required: True
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
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.ICredential

## NOTES

## RELATED LINKS
