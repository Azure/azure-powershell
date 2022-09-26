
Import-Module C:\code\PSH_Dev\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
Import-Module C:\code\PSH_Dev\artifacts\Debug\Az.Storage\Az.Storage.psd1


$preview = $true

Import-Module C:\Users\weiwei\Desktop\PSH_Script\Assert.ps1
Import-Module C:\Users\weiwei\Desktop\PSH_Script\PSHTest\utils.ps1

# GA feature
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict # -TagFilter blobversion # -TagFilter ToTest 
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\adls.ps1 -Show All -Strict
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\adls_setaclresusive.ps1 -Show All -Strict
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\srp.ps1  -Show All -Strict -ExcludeTagFilter "longrunning"  # -TagFilter "fail"


#preview feature
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane_preview.ps1 -Show All -Strict  #-TagFilter "Totest"
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\srp_preview.ps1 -Show All -Strict -ExcludeTagFilter "longrunning" # -TagFilter "VLW"

# long running
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\srp_preview.ps1 -Show All -Strict -TagFilter "longrunning" 
Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\srp.ps1  -Show All -Strict -TagFilter "longrunning"