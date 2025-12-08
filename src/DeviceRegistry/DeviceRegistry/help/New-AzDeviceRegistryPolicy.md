---
external help file: Az.DeviceRegistry-help.xml
Module Name: Az.DeviceRegistry
online version: https://learn.microsoft.com/powershell/module/az.deviceregistry/new-azdeviceregistrypolicy
schema: 2.0.0
---

# New-AzDeviceRegistryPolicy

## SYNOPSIS
Create a Policy

## SYNTAX

### CreateExpanded (Default)
```
New-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -Location <String> [-LeafCertificateConfigurationValidityPeriodInDay <Int32>]
 [-Tag <Hashtable>] [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonFilePath
```
New-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonFilePath <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

### CreateViaJsonString
```
New-AzDeviceRegistryPolicy -Name <String> -NamespaceName <String> -ResourceGroupName <String>
 [-SubscriptionId <String>] -JsonString <String> [-DefaultProfile <PSObject>] [-AsJob] [-NoWait]
 [-WhatIf] [-Confirm] [<CommonParameters>]
```

## DESCRIPTION
Create a Policy

## EXAMPLES

### Example 1: Create a policy with ECC certificate using JSON string
```powershell
$jsonString = @"
{
    "location": "eastus2",
    "properties": {
        "certificate": {
            "certificateAuthorityConfiguration": {
                "keyType": "ECC"
            },
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 90
            }
        }
    },
    "tags": {
        "environment": "production",
        "team": "iot"
    }
}
"@

New-AzDeviceRegistryPolicy -Name my-policy-ecc -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-ecc
Location                     : eastus2
Name                         : my-policy-ecc
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "ECC"
                                   },
                                   "leafCertificateValidityPeriodInDays": 90
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:15:20 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:15:20 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "team": "iot"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy with ECC (Elliptic Curve Cryptography) certificate authority and 90-day certificate validity.
**Note:** The expanded parameters do not expose the certificateAuthorityConfiguration keyType, so JsonString or JsonFilePath must be used.

### Example 2: Create a policy with RSA certificate using JSON string
```powershell
$jsonString = @"
{
    "location": "eastus2",
    "properties": {
        "certificate": {
            "certificateAuthorityConfiguration": {
                "keyType": "RSA"
            },
            "leafCertificateConfiguration": {
                "validityPeriodInDays": 365
            }
        }
    },
    "tags": {
        "environment": "production",
        "certType": "RSA"
    }
}
"@

New-AzDeviceRegistryPolicy -Name my-policy-rsa -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonString $jsonString
```

```output
Id                           : /subscriptions/xxxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxx/resourceGroups/my-resource-group/providers/Microsoft.DeviceRegistry/namespaces/my-namespace/credentials/default/policies/my-policy-rsa
Location                     : eastus2
Name                         : my-policy-rsa
Properties                   : {
                                 "provisioningState": "Succeeded",
                                 "certificate": {
                                   "certificateAuthorityConfiguration": {
                                     "keyType": "RSA"
                                   },
                                   "leafCertificateValidityPeriodInDays": 365
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:20:45 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:20:45 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production",
                                 "certType": "RSA"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy with RSA certificate authority and 365-day certificate validity.

### Example 3: Create a policy from a JSON file
```powershell
New-AzDeviceRegistryPolicy -Name my-policy -NamespaceName my-namespace -ResourceGroupName my-resource-group -JsonFilePath "C:\policies\policy-config.json"
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
                                   "leafCertificateValidityPeriodInDays": 90
                                 }
                               }
ResourceGroupName            : my-resource-group
SystemDataCreatedAt          : 12/2/2024 11:25:10 AM
SystemDataCreatedBy          : user@contoso.com
SystemDataCreatedByType      : User
SystemDataLastModifiedAt     : 12/2/2024 11:25:10 AM
SystemDataLastModifiedBy     : user@contoso.com
SystemDataLastModifiedByType : User
Tag                          : {
                                 "environment": "production"
                               }
Type                         : Microsoft.DeviceRegistry/namespaces/credentials/policies
```

Creates a new policy from a JSON file containing the complete policy configuration including certificate authority settings.

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

### -LeafCertificateConfigurationValidityPeriodInDay
The validity period in days.

```yaml
Type: System.Int32
Parameter Sets: CreateExpanded
Aliases:

Required: False
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
The name of the Policy tracked resource.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: PolicyName

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
Parameter Sets: (All)
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
Parameter Sets: (All)
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Models.IPolicy

## NOTES

## RELATED LINKS
