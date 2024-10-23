---
external help file: Az.MachineLearningServices-help.xml
Module Name: Az.MachineLearningServices
online version: https://learn.microsoft.com/powershell/module/az.machinelearningservices/get-azmlworkspace
schema: 2.0.0
---

# Get-AzMLWorkspace

## SYNOPSIS
Gets the properties of the specified machine learning workspace.

## SYNTAX

### List1 (Default)
```
Get-AzMLWorkspace [-SubscriptionId <String[]>] [-Skip <String>] [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

### Get
```
Get-AzMLWorkspace -Name <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### List
```
Get-AzMLWorkspace -ResourceGroupName <String> [-SubscriptionId <String[]>] [-Skip <String>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMLWorkspace -InputObject <IMachineLearningServicesIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Gets the properties of the specified machine learning workspace.

## EXAMPLES

### Example 1: List the properties of the specified machine learning workspace under a subscription
```powershell
Get-AzMLWorkspace
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----                 -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-portal01 5/5/2022 1:27:26 AM  user@example.com    User                    5/5/2022 1:27:26 AM      user@example.com        User                         eastus   ml-rg-test
mlworkspace-cli01    5/18/2022 6:33:49 AM user@example.com    User                    5/18/2022 6:33:49 AM     user@example.com        User                         eastus   ml-rg-test
mlworkspace-demo     5/25/2022 3:06:22 AM user@example.com    User                    5/25/2022 3:06:22 AM     user@example.com        User                         eastus   ml-rg-test
```

List the properties of the specified machine learning workspace under a subscription.

### Example 2: List the properties of the specified machine learning workspace under a resource group
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test
```

```output
Name                 SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----                 -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-portal01 5/5/2022 1:27:26 AM  user@example.com     User                    5/5/2022 1:27:26 AM      user@example.com         User                         eastus   ml-rg-test
mlworkspace-cli01    5/18/2022 6:33:49 AM user@example.com     User                    5/18/2022 6:33:49 AM     user@example.com         User                         eastus   ml-rg-test
mlworkspace-demo     5/25/2022 3:06:22 AM user@example.com     User                    5/25/2022 3:06:22 AM     user@example.com         User                         eastus   ml-rg-test
```

List the properties of the specified machine learning workspace under a resource group.

### Example 3: Gets the properties of the specified machine learning workspace
```powershell
Get-AzMLWorkspace -ResourceGroupName ml-rg-test -Name mlworkspace-cli01
```

```output
Name              SystemDataCreatedAt  SystemDataCreatedBy  SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType Location ResourceGroupName
----              -------------------  -------------------  ----------------------- ------------------------ ------------------------ ---------------------------- -------- -----------------
mlworkspace-cli01 5/18/2022 6:33:49 AM user@example.com     User                    5/18/2022 6:33:49 AM     user@example.com         User                         eastus   ml-rg-test
```

Gets the properties of the specified machine learning workspace.

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
Name of Azure Machine Learning workspace.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: WorkspaceName

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

```yaml
Type: System.String[]
Parameter Sets: List1, Get, List
Aliases:

Required: False
Position: Named
Default value: (Get-AzContext).Subscription.Id
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Continuation token for pagination.

```yaml
Type: System.String
Parameter Sets: List1, List
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

### Microsoft.Azure.PowerShell.Cmdlets.MachineLearningServices.Models.Api20240401.IWorkspace

## NOTES

## RELATED LINKS
