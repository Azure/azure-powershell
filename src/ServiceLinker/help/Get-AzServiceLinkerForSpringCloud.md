---
external help file:
Module Name: Az.ServiceLinker
online version: https://docs.microsoft.com/powershell/module/az.servicelinker/get-azservicelinkerforspringcloud
schema: 2.0.0
---

# Get-AzServiceLinkerForSpringCloud

## SYNOPSIS
Returns Linker resource for a given name in spring cloud.

## SYNTAX

### List (Default)
```
Get-AzServiceLinkerForSpringCloud -AppName <String> -ResourceGroupName <String> -ServiceName <String>
 [-ResourceUri <String>] [-DefaultProfile <PSObject>] [-DeploymentName <String>] [-SubscriptionId <String>]
 [<CommonParameters>]
```

### Get
```
Get-AzServiceLinkerForSpringCloud -Name <String> -AppName <String> -ResourceGroupName <String>
 -ServiceName <String> [-ResourceUri <String>] [-DefaultProfile <PSObject>] [-DeploymentName <String>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

### GetViaIdentity
```
Get-AzServiceLinkerForSpringCloud -InputObject <IServiceLinkerIdentity> [-DefaultProfile <PSObject>]
 [-SubscriptionId <String>] [<CommonParameters>]
```

## DESCRIPTION
Returns Linker resource for a given name in spring cloud.

## EXAMPLES

### Example 1: List all linkers in a spring cloud app's deployment
```powershell
Get-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -ResourceGroupName servicelinker-test-group -DeploymentName "default"
```

```output
Name
----
appconfig_08b18
postgresql_novnet
postgresql_203ca
eventhub_3ab5f
```

List all linkers in a spring cloud app's deployment

### Example 2: Get linker by name
```powershell
Get-AzServiceLinkerForSpringCloud -ServiceName servicelinker-springcloud -AppName appconfiguration -DeploymentName "default" -ResourceGroupName servicelinker-test-group  -Name postgresql_connection | Format-List
```

```output
AuthInfo                     : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model
                               s.Api20220501.SecretAuthInfo
ClientType                   : dotnet
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/re 
                               sourceGroups/servicelinker-test-group/providers/ 
                               Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers 
                               /Microsoft.ServiceLinker/linkers/postgresql_connection     
Name                         : postgresql_connection
ProvisioningState            : Succeeded
Scope                        : 
SecretStoreKeyVaultId        :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetService                : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model 
                               s.Api20220501.AzureResource
Type                         : microsoft.servicelinker/linkers
VNetSolutionType             : serviceEndpoint

```

Get linker by name

### Example 3: Get linker via identity object
```powershell
$identity = @{
ResourceUri = '/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/servicelinker-test-linux-group/providers/Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default'
LinkerName = 'postgresql_connection'}

$identity | Get-AzServiceLinkerForSpringCloud  | Format-List
```

```output
AuthInfo                     : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model
                               s.Api20220501.SecretAuthInfo
ClientType                   : dotnet
Id                           : /subscriptions/00000000-0000-0000-0000-000000000000/re 
                               sourceGroups/servicelinker-test-group/providers/ 
                               Microsoft.AppPlatform/Spring/servicelinker-springcloud/apps/appconfiguration/deployments/default/providers 
                               /Microsoft.ServiceLinker/linkers/postgresql_connection     
Name                         : postgresql_connection
ProvisioningState            : Succeeded
Scope                        : 
SecretStoreKeyVaultId        :
SystemDataCreatedAt          :
SystemDataCreatedBy          :
SystemDataCreatedByType      :
SystemDataLastModifiedAt     :
SystemDataLastModifiedBy     :
SystemDataLastModifiedByType :
TargetService                : Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Model 
                               s.Api20220501.AzureResource
Type                         : microsoft.servicelinker/linkers
VNetSolutionType             : serviceEndpoint

```

Get linker by name

## PARAMETERS

### -AppName
The app Name of spring cloud service to be connected.

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

### -DeploymentName
The deployment Name of spring cloud app to be connected.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: True
Position: Named
Default value: "default"
Accept pipeline input: False
Accept wildcard characters: False
```

### -InputObject
Identity Parameter
To construct, see NOTES section for INPUTOBJECT properties and create a hash table.

```yaml
Type: Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity
Parameter Sets: GetViaIdentity
Aliases:

Required: True
Position: Named
Default value: None
Accept pipeline input: True (ByValue)
Accept wildcard characters: False
```

### -Name
The name Linker resource.

```yaml
Type: System.String
Parameter Sets: Get
Aliases: LinkerName

Required: True
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ResourceGroupName
The resource group of the resource to be connected.

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

### -ResourceUri
The fully qualified Azure Resource manager identifier of the resource to be connected.

```yaml
Type: System.String
Parameter Sets: Get, List
Aliases:

Required: False
Position: Named
Default value: None
Accept pipeline input: False
Accept wildcard characters: False
```

### -ServiceName
The Name of spring cloud service to be connected.

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
Gets subscription ID which uniquely identify the Microsoft Azure subscription.
The subscription ID forms part of the URI for every service call.

```yaml
Type: System.String
Parameter Sets: (All)
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

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.IServiceLinkerIdentity

## OUTPUTS

### Microsoft.Azure.PowerShell.Cmdlets.ServiceLinker.Models.Api20220501.ILinkerResource

## NOTES

ALIASES

COMPLEX PARAMETER PROPERTIES

To create the parameters described below, construct a hash table containing the appropriate properties. For information on hash tables, run Get-Help about_Hash_Tables.


INPUTOBJECT `<IServiceLinkerIdentity>`: Identity Parameter
  - `[Id <String>]`: Resource identity path
  - `[LinkerName <String>]`: The name Linker resource.
  - `[ResourceUri <String>]`: The fully qualified Azure Resource manager identifier of the resource to be connected.

## RELATED LINKS

