### Example 1: Test The Availability Of An Used Artifact signing Account Name
```powershell
Test-AzArtifactSigningAccountNameAvailability -Name unavaliable
```

```output
Message                      NameAvailable Reason
-------                      ------------- ------
Resource name already exists         False AlreadyExists
```

This commands tests the availability of artifact signing account name `unavaliable`.
The results shows `unavaliable` is occupied.

### Example 2: Test The Availability Of An Unused Artifact signing Account Name
```powershell
Test-AzArtifactSigningAccountNameAvailability -Name available
```

```output
NameAvailable
-------------
         True
```

This commands tests the availability of artifact signing account name `available`.
The results shows `available` is not occupied.
