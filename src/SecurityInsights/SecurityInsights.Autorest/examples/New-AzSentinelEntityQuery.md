### Example 1: Create Entity Query
```powershell
 $template = Get-AzSentinelEntityQueryTemplate -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id "myEntityQueryTemplateId"
 New-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Kind Activity -Title ($template.title) -InputEntityType ($template.inputEntityType) -TemplateName ($template.Name)
```

```output
Title              		: The user has created an account
Name                	: 6d37a904-d199-43ff-892b-53653b784122
Content            		: The user InitiatedByAccount has created the account TargetAccount Count time(s)
Description         	: This activity displays account creation events performed by the user
Enabled            		: True
Kind               		: Activity
CreatedTimeUtc      	: 12/22/2021 11:44:34 AM
LastModifiedTimeUtc 	: 12/22/2021 11:47:13 AM
```

This command creates an Entity Query by using a Template.

### Example 2: Create Entity Query from cmdlet inputs
```powershell
 New-AzSentinelEntityQuery -ResourceGroupName "myResourceGroupName" -workspaceName "myWorkspaceName" -Id ((New-Guid).Guid) -Kind Activity -Title 'An account was deleted on this host' -InputEntityType 'Host' -Content "On 'SomeCompute' the account 'SomeAccount' was deleted by 'SomeUser'" -Description "Account deleted on host" -QueryDefinitionQuery 'let GetAccountActions = (v_Host_Name:string, v_Host_NTDomain:string, v_Host_DnsDomain:string, v_Host_AzureID:string, v_Host_OMSAgentID:string){\nSecurityEvent\n| where EventID in (4725, 4726, 4767, 4720, 4722, 4723, 4724)\n// parsing for Host to handle variety of conventions coming from data\n| extend Host_HostName = case(\nComputer has ''@'', tostring(split(Computer, ''@'')[0]),\nComputer has ''\\'', tostring(split(Computer, ''\\'')[1]),\nComputer has ''.'', tostring(split(Computer, ''.'')[0]),\nComputer\n)\n| extend Host_NTDomain = case(\nComputer has ''\\'', tostring(split(Computer, ''\\'')[0]), \nComputer has ''.'', tostring(split(Computer, ''.'')[-2]), \nComputer\n)\n| extend Host_DnsDomain = case(\nComputer has ''\\'', tostring(split(Computer, ''\\'')[0]), \nComputer has ''.'', strcat_array(array_slice(split(Computer,''.''),-2,-1),''.''), \nComputer\n)\n| where (Host_HostName =~ v_Host_Name and Host_NTDomain =~ v_Host_NTDomain) \nor (Host_HostName =~ v_Host_Name and Host_DnsDomain =~ v_Host_DnsDomain) \nor v_Host_AzureID =~ _ResourceId \nor v_Host_OMSAgentID == SourceComputerId\n| project TimeGenerated, EventID, Activity, Computer, TargetAccount, TargetUserName, TargetDomainName, TargetSid, SubjectUserName, SubjectUserSid, _ResourceId, SourceComputerId\n| extend AddedBy = SubjectUserName\n// Future support for Activities\n| extend timestamp = TimeGenerated, HostCustomEntity = Computer, AccountCustomEntity = TargetAccount\n};\nGetAccountActions(''someHost'', ''SomeNTDomain'', ''SomeDNSDomain'', ''SomeID'', ''SomeOMSAgentID'')\n \n| where EventID == 4726' -RequiredInputFieldsSet @(@("Host_HostName","Host_NTDomain"),@("Host_HostName","Host_DnsDomain"),@("Host_AzureID"),@("Host_OMSAgentID")) -EntitiesFilter @{"Host_OsFamily" = @("Windows")}
```

This command creates an Entity Query.