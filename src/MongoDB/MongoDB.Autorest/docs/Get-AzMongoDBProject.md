---
external help file:
Module Name: Az.MongoDB
online version: https://learn.microsoft.com/powershell/module/az.mongodb/get-azmongodbproject
schema: 2.0.0
---

# Get-AzMongoDBProject

## SYNOPSIS
Get a Project

## SYNTAX

### List (Default)
```
Get-AzMongoDBProject -OrganizationName <String> -ResourceGroupName <String> [-SubscriptionId <String[]>]
 [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### Get
```
Get-AzMongoDBProject -Name <String> -OrganizationName <String> -ResourceGroupName <String>
 [-SubscriptionId <String[]>] [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzMongoDBProject -InputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>] [<CommonParameters>]
```

### GetViaIdentityOrganization
```
Get-AzMongoDBProject -Name <String> -OrganizationInputObject <IMongoDbIdentity> [-DefaultProfile <PSObject>]
 [<CommonParameters>]
```

## DESCRIPTION
Get a Project

## EXAMPLES

### Example 1: List all Projects under an Organization
```powershell
Get-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest
```

```output
Name           SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType
----           ------------------- ------------------- -----------------------
asdfsadf
mavarsh-test-1
mavarsh-test2
tesgin
```

Lists all projects that belong to the given organization in the resource group.

### Example 2: Get a specific Project
```powershell
Get-AzMongoDBProject -ResourceGroupName sharmaanuTest -OrganizationName KanedaTest -Name mavarsh-test-1 | Format-List
```

```output
ClusterCount                 : 0
Id                           : /subscriptions/61641157-140c-4b97-b365-30ff76d9f82e/resourceGroups/sharmaanuTest/providers/MongoDB.Atlas/organizations/KanedaTest/projects/mavarsh-test-1
Name                         : mavarsh-test-1
OrganizationId               : 6a2b114e620de528f66a43eb
ProjectId                    : 6a39281864733305129a1678
ProjectName                  : mavarsh-test-1
ProvisioningState            : Succeeded
ResourceGroupName            : sharmaanuTest
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
Type                         : MongoDB.Atlas/organizations/projects
```

Gets the details of a single project by name.

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

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
Name of the MongoDB Atlas Project resource.

```yaml
Type: System.String
Parameter Sets: Get, GetViaIdentityOrganization
Aliases: ProjectName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -OrganizationInputObject
Identity Parameter

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity
Parameter Sets: GetViaIdentityOrganization
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -OrganizationName
Name of the Organization resource

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
Parameter Sets: Get, List
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

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IMongoDbIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.MongoDB.Models.IProject

## NOTES

## RELATED LINKS

