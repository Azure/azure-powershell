### Example 1: Create a Contact Detail object
```powershell
New-AzPeeringContactDetailObject -Email "abc@xyz.com" -Phone 1234567890 -Role "Noc"
```

```output
Email       Phone      Role
-----       -----      ----
abc@xyz.com 1234567890 Noc
```

Creates a ContactDetail object with the specified email phone and role stores it in memory

