---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version:
schema: 2.0.0
---

# Get-AzManagedHsm

## SYNOPSIS
Get managed hsms.
## SYNTAX

```
Get-AzManagedHsm [[-HsmName] <String>] [[-ResourceGroupName] <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [<CommonParameters>]
```

## DESCRIPTION
{{ Fill in the Description }}

## EXAMPLES
The **Get-AzManagedHsm** cmdlet gets information about the managed hsms in a subscription. You can
view all managed hsms instances in a subscription, or filter your results by a resource group or a
particular managed hsm.
Note that although specifying the resource group is optional for this cmdlet when you get a single
managed hsm, you should do so for better performance.

### Example 1: Get all managed hsms in your current subscription
```powershell
PS C:\> Get-AzManagedHsm

Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed hsms in your current subscription.

### Example 2: Get a specific managed hsm
```powershell
PS C:\> Get-AzManagedHsm -Name 'myhsm'

Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets the managed hsm named myhsm in your current subscription.

### Example 3: Get managed hsms in a resource group
```powershell
PS C:\> Get-AzManagedHsm -ResourceGroupName 'myrg1'

Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed hsms in the resource group named myrg1.

### Example 4: Get managed hsms using filtering
```powershell
PS C:\> Get-AzManagedHsm -Name 'myhsm*'

Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed hsms in the subscription that start with "myhsm".

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

```yaml
Type: Microsoft.Azure.Commands.Common.Authentication.Abstractions.Core.IAzureContextContainer
Parameter Sets: (All)
Aliases: AzContext, AzureRmContext, AzureCredential

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -HsmName
Hsm name.
Cmdlet constructs the FQDN of a hsm based on the name and currently selected environment.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases: Name

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -ResourceGroupName
Specifies the name of the resource group associated with the managed hsm being queried.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies the key and optional value of the specified tag to filter the list of managed hsms by.

```yaml
Type: System.Collections.Hashtable
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### System.String

### System.Collections.Hashtable

## OUTPUTS

### Microsoft.Azure.Commands.KeyVault.Models.PSManagedHsm

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultIdentityItem

## NOTES

## RELATED LINKS

[New-AzManagedHsm](./New-AzManagedHsm.md)

[Remove-AzManagedHsm](./Remove-AzManagedHsm.md)