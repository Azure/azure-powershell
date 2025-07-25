### Example 1: New-AzSelfHelpTroubleshooter
```powershell
$parameters = [ordered]@{
 "addParam1"= "/subscriptions/02d59989-f8a9-4b69-9919-1ef51df4eff6"
 
 }
New-AzSelfHelpTroubleshooter -Scope "/subscriptions/6bded6d5-a
6af-43e1-96d3-bf71f6f5f8ba" -Name "12d59989-f8a9-4b69-9919-1ef51df4eff6" -Parameter $parameters -SolutionId "e104dbdf-9e14-4c9f-bc78-21ac90382231"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
12d59989-f8a9-4b69-9919-1ef51df4eff6
```

Creates new troubleshooter resource.
