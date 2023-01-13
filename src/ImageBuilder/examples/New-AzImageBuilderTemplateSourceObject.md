### Example 1: Create a managed image source
```powershell
$imageid = '/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-image'
New-AzImageBuilderTemplateSourceObject -ManagedImageSource -ImageId $imageid
```

```output
ImageId
-------
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/images/test-linux-…
```

This command creates a managed image source.

### Example 2: Create a shared image source
```powershell
New-AzImageBuilderTemplateSourceObject -SharedImageVersionSource -ImageVersionId /subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/galleries/lucasimagegallery/images/myimagedefinition/versions/1.0.0 
```

```output
ImageVersionId
--------------
/subscriptions/9e223dbe-3399-4e19-88eb-0975f02ac87f/resourceGroups/wyunchi-imagebuilder/providers/Microsoft.Compute/gallerie…
```

This command creates a shared image source.

### Example 3: Create a platfrom image source
```powershell
New-AzImageBuilderTemplateSourceObject -PlatformImageSource -Publisher 'Canonical' -Offer 'UbuntuServer' -Sku '18.04-LTS' -Version 'latest'
```

```output
ExactVersion Offer        Publisher Sku       Version
------------ -----        --------- ---       -------
             UbuntuServer Canonical 18.04-LTS latest
```

This command creates a platfrom image source.