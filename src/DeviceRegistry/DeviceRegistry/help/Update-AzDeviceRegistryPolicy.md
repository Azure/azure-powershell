---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/update-azdeviceregistrypolicy
schema: 2.0.0
---

# Update-AzDeviceRegistryPolicy

## SYNOPSIS
Update a Policy

## SYNTAX

### UpdateExpanded (Default)
```
Update-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] [-CertificateAuthorityConfiguration <IAny>]
 [-LeafCertificateConfigurationValidityPeriodInDay <Int32>] [-Tag <Hashtable>] [-DefaultProfile <PSObject>]
 [-AsJob] [-NoWait] [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonString
```
Update-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaJsonFilePath
```
Update-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityNamespaceExpanded
```
Update-AzDeviceRegistryPolicy -Name <String> -NamespaceInputObject <IDeviceRegistryIdentity>
 [-CertificateAuthorityConfiguration <IAny>] [-LeafCertificateConfigurationValidityPeriodInDay <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### UpdateViaIdentityExpanded
```
Update-AzDeviceRegistryPolicy -InputObject <IDeviceRegistryIdentity>
 [-CertificateAuthorityConfiguration <IAny>] [-LeafCertificateConfigurationValidityPeriodInDay <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Update a Policy

## EXAMPLES

### Example 1: Update policy certificate validity using JSON string
```powershell
$jsonString = @"
{
    "properties": {
        "certificate": {
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 60
            }
        }
    }
}
"@

Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy
Location                     : eastus2
Name                         : my-policy
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 60
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:30:45 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates the certificate validity period for an existing policy.
**Note:** For PATCH operations, you only need to specify the fields you want to change.

### Example 2: Update policy tags using JSON string
```powershell
$jsonString = @"
{
    "tags": {
        "environment": "production",
        "team": "iot",
        "updated": "true"
    }
}
"@

Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy
Location                     : eastus2
Name                         : my-policy
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 60
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:32:18 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot",
                                 "updated": "true"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates only the tags on an existing policy without modifying the certificate configuration.

### Example 3: Update policy from a JSON file
```powershell
Update-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\policies\policy-update.json"
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy
Location                     : eastus2
Name                         : my-policy
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 180
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:35:02 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates a policy from a JSON file containing the update payload.

### Example 4: Update policy via identity object
```powershell
$policyIdentity = @{
    SubscriptionId = "xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx"
    ResourceGroupName = "my-resource-group"
    NamespaceName = "my-namespace"
    CredentialName = "default"
    PolicyName = "my-policy-name"
}

Update-AzDeviceRegistryPolicy -InputObject $policyIdentity -Tag @{"environment" = "staging"}
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy
Location                     : eastus2
Name                         : my-policy
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 120
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:37:44 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "staging"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Updates a policy object using an identity object parameter.

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

### -CertificateAuthorityConfiguration
The configuration to set up an ICA.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IAny
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
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

### -LeafCertificateConfigurationValidityPeriodInDay
The validity period in days.

```yaml
Type: System.Int32
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the Policy tracked resource.

```yaml
Type: System.String
Parameter Sets: UpdateExpanded, UpdateViaJsonString, UpdateViaJsonFilePath, UpdateViaIdentityNamespaceExpanded
Aliases: PolicyName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -NamespaceInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IDeviceRegistryIdentity
Parameter Sets: UpdateViaIdentityNamespaceExpanded
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
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
Parameter Sets: UpdateExpanded, UpdateViaIdentityNamespaceExpanded, UpdateViaIdentityExpanded
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

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IPolicy

## NOTES

## RELATED LINKS
