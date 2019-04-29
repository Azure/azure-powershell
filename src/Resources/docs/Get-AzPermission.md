---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpermission
schema: 2.0.0
---

# Get-AzPermission

## SYNOPSIS
Gets all permissions the caller has for a resource group.

## SYNTAX

### ListSubscriptionIdViaHost2 (Default)
```
Get-AzPermission -ResourceGroupName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List3
```
Get-AzPermission -ResourceGroupName <String> -SubscriptionId <String> -ParentResourcePath <String>
 -ResourceName <String> -ResourceProviderNamespace <String> -ResourceType <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List2
```
Get-AzPermission -ResourceGroupName <String> -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### ListSubscriptionIdViaHost3
```
Get-AzPermission -ResourceGroupName <String> -ParentResourcePath <String> -ResourceName <String>
 -ResourceProviderNamespace <String> -ResourceType <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
Gets all permissions the caller has for a resource group.

## EXAMPLES

### Example 1
```powershell
PS C:\> {{ Add example code here }}
```

{{ Add example description here }}

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

### -ParentResourcePath
The parent resource identity.

```yaml
Type: System.String
Parameter Sets: List3, ListSubscriptionIdViaHost3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The name of the resource group.

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

### -ResourceName
The name of the resource to get the permissions for.

```yaml
Type: System.String
Parameter Sets: List3, ListSubscriptionIdViaHost3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceProviderNamespace
The namespace of the resource provider.

```yaml
Type: System.String
Parameter Sets: List3, ListSubscriptionIdViaHost3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceType
The resource type of the resource.

```yaml
Type: System.String
Parameter Sets: List3, ListSubscriptionIdViaHost3
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -SubscriptionId
The ID of the target subscription.

```yaml
Type: System.String
Parameter Sets: List3, List2
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api201801Preview.IPermission
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpermission](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpermission)

