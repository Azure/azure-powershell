### Example 1: Restarts troubleshooter instance
```powershell
Restart-AzSelfHelpTroubleshooter -Scope "/subscriptions/6bded6d5-a6af-43e1-96d3-bf71f6f5f8ba" -Name "02d59989-f8a9-4b69-9919-1ef51df4eff6" 
```

```output
Location TroubleshooterResourceName 

-------- -------------------------- 

         0b8b324c-be00-410b-988b-175815878690 

 
```

Restarts Troubleshooter instance. It returns new resource name which should be used in subsequent request.