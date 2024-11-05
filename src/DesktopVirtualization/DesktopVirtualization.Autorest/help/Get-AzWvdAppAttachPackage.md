---
external help file:
Module Name: Az.DesktopVirtualization
online version: https://learn.microsoft.com/powershell/module/az.desktopvirtualization/get-azwvdappattachpackage
schema: 2.0.0
---

# Get-AzWvdAppAttachPackage

## SYNOPSIS
Get an app attach package.

## SYNTAX

### List1 (Default)
```
Get-AzWvdAppAttachPackage [-SubscriptionId <String[]>] [-Filter <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzWvdAppAttachPackage -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzWvdAppAttachPackage -InputObject <IDesktopVirtualizationIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzWvdAppAttachPackage -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Filter <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Get an app attach package.

## EXAMPLES

### Example 1: Get an Azure Virtual Desktop App Attach Package by Name
```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -Name packageName1
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
```

This command gets an Azure Virtual Desktop App Attach Packages by name.

### Example 2: List all Azure Virtual Desktop App Attach Packages in a resource group
```powershell
Get-AzWvdAppAttachPackage -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName
```

```output
Location   Name          Type
--------   ----          ----
eastus     packageName1  Microsoft.DesktopVirtualization/appattachpackages
eastus     packageName2  Microsoft.DesktopVirtualization/appattachpackages
```

This command lists Azure Virtual Desktop App Attach Packages in a subscription.

## PARAMETERS

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

### -Filter
OData filter expression.
Valid properties for filtering are package name and host pool.

```yaml
Type: System.String
Parameter Sets: List, List1
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the App Attach package

```yaml
Type: System.String
Parameter Sets: Get
Aliases: AppAttachPackageName

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
Type: System.String[]
Parameter Sets: Get, List, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IDesktopVirtualizationIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.DesktopVirtualization.Models.IAppAttachPackage

## NOTES

## RELATED LINKS

