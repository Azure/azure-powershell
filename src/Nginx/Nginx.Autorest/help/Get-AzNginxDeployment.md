---
external help file:
Module Name: Az.Nginx
online version: https://learn.microsoft.com/powershell/module/az.nginx/get-aznginxdeployment
schema: 2.0.0
---

# Get-AzNginxDeployment

## SYNOPSIS
Get the NGINX deployment

## SYNTAX

### List (Default)
```
Get-AzNginxDeployment [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzNginxDeployment -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzNginxDeployment -InputObject <INginxIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List1
```
Get-AzNginxDeployment -ResourceGroupName <String> [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get the NGINX deployment

## EXAMPLES

### Example 1: Get a NGINX deployment with name
```powershell
Get-AzNginxDeployment -Name nginx-test -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus nginx-test
```

This command gets a NGINX deployment in a resource group.

### Example 2: List all NGINX deployments in a subscription
```powershell
Get-AzNginxDeployment
```

```output
Location      Name
--------      ----
westcentralus nginx-test
westcentralus nginx-test1
eastus2       nginx-test2

```

This command lists all NGINX deployments in a subscription.

### Example 3: List all NGINX deployments in a resource group
```powershell
Get-AzNginxDeployment -ResourceGroupName nginx-test-rg
```

```output
Location      Name
--------      ----
westcentralus nginx-test
westcentralus nginx-test1
```

This command lists all NGINX deployments in a resource group.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name of targeted NGINX deployment

```yaml
Type: System.String
Parameter Sets: Get
Aliases: DeploymentName

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
Parameter Sets: Get, List1
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

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.INginxIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Nginx.Models.Api20230401.INginxDeployment

## NOTES

## RELATED LINKS

