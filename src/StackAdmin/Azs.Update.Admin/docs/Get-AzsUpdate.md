---
external help file:
Module Name: Azs.Update.Admin
online version: https://docs.microsoft.com/en-us/powershell/module/azs.update.admin/get-azsupdate
schema: 2.0.0
---

# Get-AzsUpdate

## SYNOPSIS
Get a specific update at an update location.

## SYNTAX

### List (Default)
```
Get-AzsUpdate [-Location <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzsUpdate -Name <String> [-Location <String>] [-ResourceGroupName <String>] [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzsUpdate -InputObject <IUpdateAdminIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get a specific update at an update location.

## EXAMPLES

### Example 1: Get All Updates
```powershell
PS C:\> Get-AzsUpdate

Location        DisplayName                    Name                                     State                Publisher
--------        -----------                    ----                                     -----                ---------
northwest       AzS Update - 1.2203.0.10       northwest/Microsoft1.2203.0.10           Installed            Microsoft
northwest       AzS Update - 1.2203.0.13       northwest/Microsoft1.2203.0.13           Installed            Microsoft
northwest       AzS Update - 1.2203.0.20       northwest/Microsoft1.2203.0.20           Installed            Microsoft
```

Without any parameters, Get-AzsUpdate will list all updates that the stamp can discover

### Example 2: Get Update by Name
```powershell
PS C:\> Get-AzsUpdate -Name Microsoft1.2203.0.10
or
PS C:\> Get-AzsUpdate -Name northwest/Microsoft1.2203.0.10


Location        DisplayName                    Name                                     State                Publisher
--------        -----------                    ----                                     -----                ---------
northwest       AzS Update - 1.2203.0.10       northwest/Microsoft1.2203.0.10           Installed            Microsoft
```

Will retrieve all updates that correspond to the specified Name

### Example 2: Get All Updates by Location
```powershell
PS C:\> Get-AzsUpdate -Location northwest

Location        DisplayName                    Name                                     State                Publisher
--------        -----------                    ----                                     -----                ---------
northwest       AzS Update - 1.2203.0.10       northwest/Microsoft1.2203.0.10           Installed            Microsoft
northwest       AzS Update - 1.2203.0.13       northwest/Microsoft1.2203.0.13           Installed            Microsoft
northwest       AzS Update - 1.2203.0.20       northwest/Microsoft1.2203.0.20           Installed            Microsoft
```

Will retrieve all updates within a specified Location. Currently, only one location is supported so this is the equivalent as just Get-AzsUpdate

## PARAMETERS

### -DefaultProfile
The credentials, account, tenant, and subscription used for communication with Azure.

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
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.IUpdateAdminIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Location
The name of the update location.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzLocation)[0].Location
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
Name of the update.

```yaml
Type: System.String
Parameter Sets: Get
Aliases:

Required: True
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
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: -join("System.",(Get-AzLocation)[0].Location)
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String[]
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.IUpdateAdminIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.UpdateAdmin.Models.Api20210701.IUpdate

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT <IUpdateAdminIdentity>: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[ResourceGroupName <String>]`: The name of the resource group. The name is case insensitive.
  - `[RunName <String>]`: Update run identifier.
  - `[SubscriptionId <String>]`: The ID of the target subscription.
  - `[UpdateLocation <String>]`: The name of the update location.
  - `[UpdateName <String>]`: Name of the update.

## RELATED LINKS

