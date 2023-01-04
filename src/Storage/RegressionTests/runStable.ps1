

#Import-Module d:\code\PSH_Dev\artifacts\Debug\Az.Accounts\Az.Accounts.psd1
#Import-Module d:\code\PSH_Dev\artifacts\Debug\Az.Storage\Az.Storage.psd1


Import-Module $PSScriptRoot\utils.ps1
# Import-Module $PSScriptRoot\Assert.ps1


# $preview = $true

Invoke-Pester $PSScriptRoott\dataplane.ps1 -Show All -Strict #  -TagFilter ToTest # -TagFilter blobversion,qq
Invoke-Pester $PSScriptRoot\adls.ps1 -Show All -Strict
Invoke-Pester $PSScriptRoot\adls_setaclresusive.ps1 -Show All -Strict
Invoke-Pester $PSScriptRoot\srp.ps1  -Show All -Strict -ExcludeTagFilter "longrunning"  # -TagFilter "fail"

Invoke-Pester $PSScriptRoot\srp.ps1  -Show All -Strict -TagFilter "longrunning"


#Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane.ps1 -Show All -Strict -TagFilter accesspolicy
#Invoke-Pester C:\Users\weiwei\Desktop\PSH_Script\PSHTest\dataplane_preview.ps1 -Show All -Strict -TagFilter accesspolicy
