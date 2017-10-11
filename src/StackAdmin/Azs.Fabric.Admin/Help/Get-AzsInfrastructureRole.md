---
external help file: Azs.Fabric.Admin-help.xml
Module Name: Azs.Fabric.Admin
online version: 
schema: 2.0.0
---

# Get-AzsInfrastructureRole

## SYNOPSIS
Get infrastructure roles.

## SYNTAX

### InfraRoles_List (Default)
```
Get-AzsInfrastructureRole [-Filter <String>] [-Skip <Int32>] -Location <String> [-Top <Int32>]
 [<CommonParameters>]
```

### InfraRoles_Get
```
Get-AzsInfrastructureRole -Location <String> -InfrastructureRole <String> [<CommonParameters>]
```

## DESCRIPTION
Get infrastructure roles.

## EXAMPLES

### Example 1
```
PS C:\> Get-AzsInfrastructureRole -Location "local"
Type                                              Instances
----                                              ---------
Microsoft.Fabric.Admin/fabricLocations/InfraRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
Microsoft.Fabric.Admin/fabricLocations/InfraRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
Microsoft.Fabric.Admin/fabricLocations/InfraRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
Microsoft.Fabric.Admin/fabricLocations/InfraRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
Microsoft.Fabric.Admin/fabricLocations/InfraRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
...
```

Get a list of all infrastructure roles.

### Example 2
```
PS C:\> Get-AzsInfrastructureRole -Location "local" -InfrastructureRole "Active Directory Federation Services"
Type                                              Instances
----                                              ---------
Microsoft.Fabric.Admin/fabricLocations/InfrastructureRoles {subscriptions/1c0daa04-01ae-4df9-a5d8-491b755f5288/resourceGroups/system.local/providers/Microsoft.Fabric.Admin/fabricLocations/local/i...
```

Get an infrastructure role based on the name.

## PARAMETERS

### -Filter
OData filter parameter.

```yaml
Type: String
Parameter Sets: InfraRoles_List
Aliases: 

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -InfrastructureRole
Infra role name.

```yaml
Type: String
Parameter Sets: InfraRoles_Get
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Location
Location of the resource.

```yaml
Type: String
Parameter Sets: (All)
Aliases: 

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -Skip
Skip the first N items as specified by the parameter value.

```yaml
Type: Int32
Parameter Sets: InfraRoles_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### -Top
Return the top N items as specified by the parameter value.
Applies after the -Skip parameter.

```yaml
Type: Int32
Parameter Sets: InfraRoles_List
Aliases: 

Required: False
Position: Named
Default value: -1
Accept pipeline input: False
Accept wildcard characters: False
```

### CommonParameters
This cmdlet supports the common parameters: -Debug, -ErrorAction, -ErrorVariable, -InformationAction, -InformationVariable, -OutVariable, -OutBuffer, -PipelineVariable, -Verbose, -WarningAction, and -WarningVariable. For more information, see about_CommonParameters (http://go.microsoft.com/fwlink/?LinkID=113216).

## INPUTS

## OUTPUTS

### Microsoft.AzureStack.Management.Fabric.Admin.Models.InfraRole

## NOTES

## RELATED LINKS

