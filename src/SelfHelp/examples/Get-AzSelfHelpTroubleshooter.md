### Example 1:  Get-AzSelfHelpTroubleshooter by troubleshooter name (GUID)
```powershell
Get-AzSelfHelpTroubleshooter -Scope "/subscriptions/<subid>" -Name "02d59989-f8a9-4b69-9919-1ef51df4eff6"
```

```output
Name                                 SystemDataCreatedAt SystemDataCreatedBy SystemDataCreatedByType SystemDataLastModifiedAt SystemDataLastModifiedBy SystemDataLastModifiedByType ResourceGroupName
----                                 ------------------- ------------------- ----------------------- ------------------------ ------------------------ ---------------------------- -----------------
02d59989-f8a9-4b69-9919-1ef51df4eff6

```

Get Azure SelfHelp Troubleshooter by name. The name is the guid of the troubleshooter.
