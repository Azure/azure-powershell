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
    $randPasswordStr1 = -Join ((65..90) | Get-Random -Count 5 | % {[char]$_})
    $randPasswordStr2 = -Join ((97..122) | Get-Random -Count 5 | % {[char]$_})
    $randPasswordStr3 = -Join ((0..9) | Get-Random -Count 5 | % {[int32]$_})
    $randPasswordStr4 = -Join ('!','$','#','%' | Get-Random -Count 2)
    $password =  $randPasswordStr1 + $randPasswordStr2 + $randPasswordStr3 + $randPasswordStr4
    return $password
}
function GetOrCreateMariaDb([bool]$forceCreate, $mariaDb, [string]$resourceGroup) {
    if(!$forceCreate) {
        $mariaDbObjArray = Get-AzMariaDbServer -ResourceGroup $resourceGroup
        foreach($mariaDbObj in $mariaDbObjArray) {
            if( $mariaDbObj.SkuName -eq $mariaDb.SkuName) {
                Write-Host -ForegroundColor Yellow "Get mariadb for test from resource group."
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
        $randAdminLogin = -join ((97..122) | Get-Random -Count 10 | % {[char]$_})
        $mariaDb.AdminLogin = $randAdminLogin
    }
    if(!$mariaDb.AdminLoginPassword) {
        $mariaDb.AdminLoginPassword = CreateAdminPassword
    }
    Write-Host -ForegroundColor Yellow "Create mariadb for test..."
    $adminLoginPasswordSecure =  ConvertTo-SecureString $mariaDb.AdminLoginPassword -AsPlainText -Force
    $sku =  $mariaDb.SkuName
    $mariaDbObj = New-AzMariaDbServer -Name $mariaDb.Name -ResourceGroup $resourceGroup -Sku $sku -Location $mariaDb.Location -AdministratorUsername $mariaDb.AdminLogin -AdministratorLoginPassword $adminLoginPasswordSecure
    Write-Host -ForegroundColor Yellow "Created successfully."
    return $mariaDbObj
}