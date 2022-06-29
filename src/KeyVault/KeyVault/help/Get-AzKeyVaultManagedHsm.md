---
external help file: Microsoft.Azure.PowerShell.Cmdlets.KeyVault.dll-Help.xml
Module Name: Az.KeyVault
online version: https://docs.microsoft.com/powershell/module/az.keyvault/get-azkeyvaultmanagedhsm
schema: 2.0.0
---

# Get-AzKeyVaultManagedHsm

## SYNOPSIS
Get managed HSMs.

## SYNTAX

### GetManagedHsm
```
Get-AzKeyVaultManagedHsm [[-Name] <String>] [[-ResourceGroupName] <String>] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-SubscriptionId <String>] [<CommonParameters>]
```

### GetDeletedManagedHsm
```
Get-AzKeyVaultManagedHsm [-Name] <String> [-Location] <String> [-InRemovedState] [-Tag <Hashtable>]
 [-DefaultProfile <IAzureContextContainer>] [-SubscriptionId <String>] [<CommonParameters>]
```

### ListDeletedManagedHsms
```
Get-AzKeyVaultManagedHsm [-InRemovedState] [-Tag <Hashtable>] [-DefaultProfile <IAzureContextContainer>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
The **Get-AzKeyVaultManagedHsm** cmdlet gets information about the managed HSMs in a subscription. You can
view all managed HSMs instances in a subscription, or filter your results by a resource group or a
particular managed HSM.
Note that although specifying the resource group is optional for this cmdlet when you get a single
managed HSM, you should do so for better performance.

## EXAMPLES

### Example 1: Get all managed HSMs in your current subscription
```powershell
Get-AzKeyVaultManagedHsm
```

```output
Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed HSMs in your current subscription.

### Example 2: Get a specific managed HSM
```powershell
Get-AzKeyVaultManagedHsm -Name 'myhsm'
```

```output
Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets the managed HSM named myhsm in your current subscription.

### Example 3: Get managed HSMs in a resource group
```powershell
Get-AzKeyVaultManagedHsm -ResourceGroupName 'myrg1'
```

```output
Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed HSMs in the resource group named myrg1.

### Example 4: Get managed HSMs using filtering
```powershell
Get-AzKeyVaultManagedHsm -Name 'myhsm*'
```

```output
Name  Resource Group Name Location    SKU
----  ------------------- --------    ---
myhsm myrg1               eastus2euap StandardB1
```

This command gets all managed HSMs in the subscription that start with "myhsm".

### Example 5: List deleted managed HSMs
```powershell
Get-AzKeyVaultManagedHsm -InRemovedState
```
```output
Name                     Location      DeletionDate           ScheduledPurgeDate    Purge Protection Enabled?
----                     --------      ------------           ------------------    -------------------------
xxxxxxxx-mhsm-4op2n2g4xe eastus2       12/30/2021 2:29:00 AM  3/30/2022 2:29:00 AM  True
xxxxxxx-mhsm-ertopo7tnxa westus        12/29/2021 11:48:42 PM 3/29/2022 11:48:42 PM True
xxxxxxx-mhsm-gg66fgctz67 westus        12/29/2021 11:48:42 PM 3/29/2022 11:48:42 PM False
xxxxxxx-mhsm-2m5jiop6mfo westcentralus 12/30/2021 12:26:14 AM 3/30/2022 12:26:14 AM True
```

This command gets all deleted managed HSMs in current subscription.

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

### -InRemovedState
Specifies whether to show the previously deleted managed HSM pool in the output.

```yaml
Type: System.Management.Automation.SwitchParameter
Parameter Sets: GetDeletedManagedHsm, ListDeletedManagedHsms
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
The location of the deleted managed HSM pool.

```yaml
Type: System.String
Parameter Sets: GetDeletedManagedHsm
Aliases:

Required: True
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Name
HSM name. Cmdlet constructs the FQDN of a HSM based on the name and currently selected environment.

```yaml
Type: System.String
Parameter Sets: GetManagedHsm
Aliases: HsmName

Required: False
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

```yaml
Type: System.String
Parameter Sets: GetDeletedManagedHsm
Aliases: HsmName

Required: True
Position: 0
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -ResourceGroupName
Specifies the name of the resource group associated with the managed HSM being queried.

```yaml
Type: System.String
Parameter Sets: GetManagedHsm
Aliases:

Required: False
Position: 1
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: True
```

### -SubscriptionId
The ID of the subscription.
By default, cmdlets are executed in the subscription that is set in the current context. If the user specifies another subscription, the current cmdlet is executed in the subscription specified by the user.
Overriding subscriptions only take effect during the lifecycle of the current cmdlet. It does not change the subscription in the context, and does not affect subsequent cmdlets.

```yaml
Type: System.String
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: True (ByPropertyName)
Accept wildcard characters: False
```

### -Tag
Specifies the key and optional value of the specified tag to filter the list of managed HSMs by.

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

### Microsoft.Azure.Commands.KeyVault.Models.PSDeletedManagedHsm

### Microsoft.Azure.Commands.KeyVault.Models.PSKeyVaultIdentityItem

## NOTES

## RELATED LINKS

[New-AzKeyVaultManagedHsm](./New-AzKeyVaultManagedHsm.md)

[Remove-AzKeyVaultManagedHsm](./Remove-AzKeyVaultManagedHsm.md)

[Update-AzKeyVaultManagedHsm](./Update-AzKeyVaultManagedHsm.md)