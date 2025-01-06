---
external help file: Az.NetworkCloud-help.xml
Module Name: Az.NetworkCloud
online version: https://learn.microsoft.com/powershell/module/az.networkcloud/get-aznetworkcloudconsole
schema: 2.0.0
---

# Get-AzNetworkCloudConsole

## SYNOPSIS
Get properties of the provided virtual machine console.

## SYNTAX

### List (Default)
```
Get-AzNetworkCloudConsole -ResourceGroupName <String> [-SubscriptionId <String[]>] -VirtualMachineName <String>
 [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzNetworkCloudConsole -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -VirtualMachineName <String> [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNetworkCloudConsole -InputObject <INetworkCloudIdentity> [-DefaultProfile <PSObject>]
 [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

## DESCRIPTION
Get properties of the provided virtual machine console.

## EXAMPLES

### Example 1: List virtual machine's consoles
```powershell
Get-AzNetworkCloudConsole -SubscriptionId subscriptionId -VirtualMachineName virtualMachineName -ResourceGroupName resourceGroupName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy      SystemDataLastModifiedByType AzureAsyncOperation
-------- ----    ------------------- -------------------  ------------------------ ------------------------  ----------------------------  ----------------------------
eastus   default 06/27/2023 21:32:03  <user>              User                     06/27/2023 21:32:41       <identity>                    Application
```

This command gets all consoles for the provided virtual machine.

### Example 2: Get virtual machine's console
```powershell
Get-AzNetworkCloudConsole -Name consoleName -SubscriptionId subscriptionId -ResourceGroupName resourceGroupName -VirtualMachineName virtualMachineName
```

```output
Location Name    SystemDataCreatedAt SystemDataCreatedBy  SystemDataCreatedByType  SystemDataLastModifiedAt  SystemDataLastModifiedBy      SystemDataLastModifiedByType AzureAsyncOperation
-------- ----    ------------------- -------------------  ------------------------ ------------------------  ----------------------------  ----------------------------
eastus   default 06/27/2023 21:32:03  <user>              User                     06/27/2023 21:32:41       <identity>                    Application
```

This command gets a specific console of the provided virtual machine.

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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of the virtual machine console.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: ConsoleName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ProgressAction
{{ Fill ProgressAction Description }}

```yaml
Type: System.Management.Automation.ActionPreference
Parameter Sets: (All)
Aliases: proga

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
Parameter Sets: List, Get
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
Parameter Sets: List, Get
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -VirtualMachineName
The name of the virtual machine.

```yaml
Type: System.String
Parameter Sets: List, Get
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.INetworkCloudIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.NetworkCloud.Models.Api20240701.IConsole

## NOTES

## RELATED LINKS
