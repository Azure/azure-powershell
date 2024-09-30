---
external help file:
Module Name: Az.SelfHelp
online version: https://learn.microsoft.com/powershell/module/az.selfhelp/get-azselfhelpsolutionselfhelp
schema: 2.0.0
---

# Get-AzSelfHelpSolutionSelfHelp

## SYNOPSIS
Finds and Executes a Self Help Solution based on the Solution Id.
These are static self help content to help users troubleshoot their issues.

## SYNTAX

### Get (Default)
```
Get-AzSelfHelpSolutionSelfHelp -SolutionId <String> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzSelfHelpSolutionSelfHelp -InputObject <ISelfHelpIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Finds and Executes a Self Help Solution based on the Solution Id.
These are static self help content to help users troubleshoot their issues.

## EXAMPLES

### Example 1: Get Self Help Solutions for a given solutionId
```powershell
Get-AzSelfHelpSolutionSelfHelp -SolutionId "apollo-48996ff7-002f-47c1-85b2-df138843d5d5"
```

```output
Name                                        SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                        ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
apollo-48996ff7-002f-47c1-85b2-df138843d5d5
```

Gets Self Help Solutions for a given solutionId.
Self Help Solutions consist of rich instructional video tutorials, links and guides to public documentation related to a specific problem that enables users to troubleshoot Azure issues.

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
Type: Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -SolutionId
SolutionId is a unique id to identify a solution.
You can retrieve the solution id using the Discovery api - https://learn.microsoft.com/en-us/rest/api/help/discovery-solution/list?view=rest-help-2023-09-01-preview&tabs=HTTP

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

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see [about_CommonParameters](http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.ISelfHelpIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.SelfHelp.Models.Api20240301Preview.ISolutionResourceSelfHelp

## NOTES

## RELATED LINKS

