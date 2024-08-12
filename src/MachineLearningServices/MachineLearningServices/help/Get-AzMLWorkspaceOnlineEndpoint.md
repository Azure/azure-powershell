---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspaceonlineendpoint
schema: 2.0.0
---

# Get-AzMLWorkspaceOnlineEndpoint

## SYNOPSIS
Get Online Endpoint.

## SYNTAX

### List (Default)
```
Get-AzMLWorkspaceOnlineEndpoint [-Name <String>] -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-ComputeType <EndpointComputeType>] [-Count <Int32>] [-OrderBy <OrderString>]
 [-Property <String>] [-Skip <String>] [-Tag <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspaceOnlineEndpoint -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 -WorkspaceName <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspaceOnlineEndpoint -InputObject <IMachineLearningServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get Online Endpoint.

## EXAMPLES

### Example 1: Lists all online enpoints under a workspace
```powershell
Get-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01
```

```output
Location Name          SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ----          -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   online-cli02  5/19/2022 2:49:44 AM UserName (Example)                  5/19/2022 2:50:27 AM                                                                                   Managed ml-rg-test
eastus   online-cli01  5/19/2022 2:47:34 AM UserName (Example)                  5/19/2022 2:48:26 AM                                                                                   Managed ml-rg-test
eastus   online-pwsh01 5/18/2022 9:44:06 AM UserName (Example)                  5/18/2022 9:44:48 AM                                                                                   Managed ml-rg-test
```

Lists all online enpoints under a workspace

### Example 2: Get a online enpoint by name
```powershell
Get-AzMLWorkspaceOnlineEndpoint -ResourceGroupName ml-rg-test -WorkspaceName mlworkspace-cli01 -Name online-cli01
```

```output
Location Name         SystemDataCreatedAt  SystemDataCreatedBy                 SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Kind    ResourceGroupName
-------- ----         -------------------  -------------------                 ----------------------- ------------------------ ------------------------ ---------------------------- ----    -----------------
eastus   online-cli01 5/19/2022 2:47:34 AM UserName (Example)                  5/19/2022 2:48:26 AM                                                                                   Managed ml-rg-test
```

Get a online enpoint by name

## PARAMETERS

### -ComputeType
EndpointComputeType to be filtered by.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.EndpointComputeType
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Count
Number of endpoints to be retrieved in a page of results.

```yaml
Type: System.Int32
Parameter Sets: List
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

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Online Endpoint name.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

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

### -OrderBy
The option to order the response.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Support.OrderString
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Property
A set of properties with which to filter the returned models.
It is a comma separated string of properties key and/or properties key=value Example: propKey1,propKey2,propKey3=value3 .

```yaml
Type: System.String
Parameter Sets: List
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

### -Tag
A set of tags with which to filter the returned models.
It is a comma separated string of tags key or tags key=value.
Example: tagKey1,tagKey2,tagKey3=value3 .

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -WorkspaceName
Name of Azure Machine Learning workspace.

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

### -Skip
Continuation token for pagination.

```yaml
Type: System.String
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.IMachineLearningServicesIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IOnlineEndpoint

## NOTES

## RELATED LINKS
