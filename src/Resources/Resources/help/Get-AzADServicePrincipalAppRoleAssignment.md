---
external help file: Az.Resources-help.xml
Module Name: Az.Resources
online version: https://learn.microsoft.com/powershell/module/az.resources/get-azadserviceprincipalapproleassignment
schema: 2.0.0
---

# Get-AzADServicePrincipalAppRoleAssignment

## SYNOPSIS
Get appRoleAssignments from servicePrincipals

## SYNTAX

### List (Default)
```
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId <String> [-Expand <String[]>]
 [-Select <String[]>] [-Count] [-Filter <String>] [-Orderby <String[]>] [-Search <String>] [-First <UInt64>]
 [-Skip <UInt64>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>] [<CommonParameters>]
```

### Get
```
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId <String> -AppRoleAssignmentId <String>
 [-Expand <String[]>] [-Select <String[]>] [-DefaultProfile <PSObject>] [-ProgressAction <ActionPreference>]
 [<CommonParameters>]
```

## DESCRIPTION
Get appRoleAssignments from servicePrincipals

## EXAMPLES

### Example 1: List assigned app roles
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:04:28 AM
Zbm-cUeDXUmlicIc3eenIhHyPMkzw2VEh76fTc0bGtM e799a9e2-acac-4960-9ba0-6a17661fa16a funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 6:56:52 AM
```

List assigned app roles.

### Example 2: Get by AppRoleAssignmentId
```powershell
Get-AzADServicePrincipalAppRoleAssignment -ServicePrincipalId 71beb965-8347-495d-a589-c21cdde7a722 -AppRoleAssignmentId Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE
```

```output
Id                                          AppRoleId                            PrincipalDisplayName PrincipalId                          CreatedDateTime
--                                          ---------                            -------------------- -----------                          ---------------
Zbm-cUeDXUmlicIc3eenIkgIm8kv9kJPj4MFhepACNE 649ae968-bdf9-4f22-bb2c-2aa1b4af0a83 funapp1214           71beb965-8347-495d-a589-c21cdde7a722 12/14/2023 7:04:28 AM
```

Get an assigned app role by Id.

## PARAMETERS

### -AppRoleAssignmentId
key: id of appRoleAssignment

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

### -Count
Include count of items

```yaml
Type: System.Management.Automation.SwitchParameter
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

### -Expand
Expand related entities

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Filter
Filter items by property values

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

### -Orderby
Order items by property values

```yaml
Type: System.String[]
Parameter Sets: List
Aliases:

Required: False
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

### -Search
Search items by search phrases

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

### -Select
Select properties to be returned

```yaml
Type: System.String[]
Parameter Sets: (All)
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServicePrincipalId
key: id of servicePrincipal

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

### -Skip
Ignores the first 'n' objects and then gets the remaining objects.

```yaml
Type: System.UInt64
Parameter Sets: List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -First
Gets only the first 'n' objects.

```yaml
Type: System.UInt64
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

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.Resources.MSGraph.Models.ApiV10.IMicrosoftGraphAppRoleAssignment

## NOTES

## RELATED LINKS
