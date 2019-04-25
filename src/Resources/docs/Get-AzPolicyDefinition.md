---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpolicydefinition
schema: 2.0.0
---

# Get-AzPolicyDefinition

## SYNOPSIS
This operation retrieves the policy definition in the given subscription with the given name.

## SYNTAX

### ListSubscriptionIdViaHost (Default)
```
Get-AzPolicyDefinition [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetSubscriptionIdViaHost
```
Get-AzPolicyDefinition -Name <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get1
```
Get-AzPolicyDefinition -Name <String> -ManagementGroupId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzPolicyDefinition -Name <String> -SubscriptionId <String> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### List
```
Get-AzPolicyDefinition -SubscriptionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzPolicyDefinition -ManagementGroupId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

## DESCRIPTION
This operation retrieves the policy definition in the given subscription with the given name.

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

### -ManagementGroupId
The ID of the management group.

```yaml
Type: System.String
Parameter Sets: Get1, List1
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Name
The name of the policy definition to get.

```yaml
Type: System.String
Parameter Sets: GetSubscriptionIdViaHost, Get1, Get
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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.Resources.Models.Api20180501.IPolicyDefinition
## NOTES

## RELATED LINKS

[https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpolicydefinition](https://docs.microsoft.com/en-us/powershell/module/az.resources/get-azpolicydefinition)

