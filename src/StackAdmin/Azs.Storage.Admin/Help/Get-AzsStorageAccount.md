---
external help file: Azs.Storage.Admin-help.xml
Module Name: Azs.Storage.Admin
online version: 
schema: 2.0.0
---

# Get-AzsStorageAccount

## SYNOPSIS
Returns the requested storage account.

## SYNTAX

### List (Default)
```
Get-AzsStorageAccount -FarmName <String> [-ResourceGroupName <String>] [-Summary] [-Skip <Int32>]
 [-Top <Int32>] [<CommonParameters>]
```

### Get
```
Get-AzsStorageAccount -FarmName <String> [-AccountId <String>] [-ResourceGroupName <String>]
 [<CommonParameters>]
```

### ResourceId
```
Get-AzsStorageAccount [-ResourceId <String>] [<CommonParameters>]
```

## DESCRIPTION
Returns the requested storage account.

## EXAMPLES

### -------------------------- EXAMPLE 1 --------------------------
```
Get-AzsStorageAccount -ResourceGroupName "system.local" -FarmName f9b8e2e2-e4b4-44e0-9d92-6a848b1a5376 -Summary $false
```

TenantViewId              : /subscriptions/a35a3f50-9f21-4f04-a978-01bc4ad7aa4f/resourcegroups/system.local/providers/Microsoft.Storage/storageaccounts/systemportal
AccountType               : Standard_LRS
ProvisioningState         : Succeeded
PrimaryEndpoints          : {\[blob, https://systemportal.blob.local.azurestack.external/\], \[queue, https://systemportal.queue.local.azurestack.external/\], \[table, https://systemportal.table.local.azurestack.external/\]}
CreationTime              : 03/25/2018 12:00:05
AlternateName             :
PrimaryLocation           : local
StatusOfPrimary           : Available
TenantSubscriptionId      : a35a3f50-9f21-4f04-a978-01bc4ad7aa4f
TenantStorageAccountName  : systemportal
TenantResourceGroupName   : system.local
CurrentOperation          : None
CustomDomain              :
AcquisitionOperationCount : 0
DeletedTime               :
AccountStatus             : Active
RecoveredTime             :
RecycledTime              :
Permissions               : Full
AccountId                 : fc1cb9b818554f03abbd00adc59890b7
WacInternalState          : Active
ResourceAdminApiVersion   :
Id                        : /subscriptions/a35a3f50-9f21-4f04-a978-01bc4ad7aa4f/resourcegroups/System.local/providers/Microsoft.Storage.Admin/farms/6925d0ee-a2eb-47b3-aeb2-b3cfbf8b2b51/storageaccounts/fc1cb9b818554f03abbd00adc59890b7
Name                      : fc1cb9b818554f03abbd00adc59890b7
Type                      : Microsoft.Storage.Admin/storageaccounts
Location                  : local
Tags                      :
...

Get a list of storage accounts.

## PARAMETERS

### -AccountId
Internal storage account ID, which is not visible to tenant.

```yaml
Type: String
Parameter Sets: Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -FarmName
Farm Id.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
Resource group name.

```yaml
Type: String
Parameter Sets: List, Get
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceId
The resource id.

```yaml
Type: String
Parameter Sets: ResourceId
Aliases: id

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Summary
Switch for wheter summary or detailed information is returned.

```yaml
Type: SwitchParameter
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: False
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Storage.Admin.Models.StorageAccount

## NOTES

## RELATED LINKS

