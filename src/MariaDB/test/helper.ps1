function getUseModules() {
    $usedModule = & 'gmo'
    foreach($module in $usedModule)
    {
      $name = $module.Name
      $version = $module.Version
      Write-Host -ForegroundColor Green "Using module name: $name $version"
    }
} 

function RandomNumber([int32]$len) {
    return -join (0,1,2,3,4,5,6,7,8,9 | Get-Random -Count $len | % {[int32]$_})
}
function RandomLetters([int32]$len) {
    return -join ((65..90) + (97..122) | Get-Random -Count $len | % {[char]$_})
}
function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function CreateAdminPassword()
{
    $randPasswordArray1 = ('A','B','C','D','E','F','G','H','L','K' | Get-Random -Count 5)
    $randPasswordArray2 = ('a','b','c','f','g','h','j','t' | Get-Random -Count 5)
    $randPasswordArray3 = (0,1,2,3,4,5,6,7,8,9 | Get-Random -Count 5)
    $randPasswordArray4 = ('!','$','#','%' | Get-Random -Count 2)
    $randPasswordArray =  $randPasswordArray1 + $randPasswordArray2 + $randPasswordArray3
    foreach($randPasswordStr in $randPasswordArray) {
        $password += $randPasswordStr
    }
    return $password
}
function GetOrCreateMariaDb([bool]$forceCreate, $mariaDb, [string]$resourceGroup) {
    if(!$forceCreate) {
        $mariaDbObjArray = Get-AzMariaDbServer -ResourceGroup $resourceGroup
        foreach($mariaDbObj in $mariaDbObjArray) {
            if( $mariaDbObj.SkuName -eq $mariaDb.SkuName) {
                Write-Host -ForegroundColor Green "Get mariadb for test from resource group."
                return $mariaDbObj
             }
        }
    }
    if(!$mariaDb.Name) {
        $rstr = 'mariadb-test-' + (RandomString -allChars $false -len 6)
        $mariaDb.Name = $rstr
    }
    if(!$mariaDb.Location) {
        $mariaDb.Location = 'eastus'
    }
    if(!$mariaDb.AdminLogin) {
        $randAdminLoginArray = ((97..122) | Get-Random -Count 10 | % {[char]$_})
        foreach($randAdminLoginStr in $randAdminLoginArray) {
            $adminLogin += $randAdminLoginStr
        }
        $mariaDb.AdminLogin = $adminLogin
    }
    if(!$mariaDb.AdminLoginPassword) {
        $mariaDb.AdminLoginPassword = CreateAdminPassword
    }
    Write-Host -ForegroundColor Green "Create mariadb for test."
    $adminLoginPasswordSecure =  ConvertTo-SecureString $mariaDb.AdminLoginPassword -AsPlainText -Force 
    $mariaDbObj = New-AzMariaDbServer -Name $mariaDb.Name -ResourceGroup $resourceGroup -SkuName $mariaDb.SkuName -Location $mariaDb.Location -AdministratorLogin $mariaDb.AdminLogin -AdministratorLoginPassword $adminLoginPasswordSecure
    return $mariaDbObj
}