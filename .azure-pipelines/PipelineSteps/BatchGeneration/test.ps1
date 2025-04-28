function Get-SubModuleWithExtensionCheck {
    param (
        [string]$srcPath
    )
    
    $result = @{}

    Get-ChildItem -Path $srcPath -Directory | ForEach-Object {
        $module = $_

        Get-ChildItem -Path $module.FullName -Directory | Where-Object { 
            $_.Name -like '*.autorest'
        } | ForEach-Object {
            $subModule = $_
            
            $readmePath = Join-Path $subModule.FullName 'README.md'

            if (Test-Path $readmePath) {
                $readmeContent = Get-Content -Path $readmePath -Raw

                if ($readmeContent -notmatch 'use-extension:\s+"@autorest/powershell":\s+"3.x"') {
                    if ($result.ContainsKey($module.Name)) {
                        $result[$module.Name] += $subModule.Name
                    } else {
                        $result[$module.Name] = @($subModule.Name)
                    }
                }
            }
        }
    }

    return $result
}

# 使用示例
$srcPath = "C:\Users\bernardpan\Desktop\work\azure-powershell\src"  # 替换成你的路径
$subModulesDict = Get-SubModuleWithExtensionCheck -srcPath $srcPath

# 打印结果
$subModulesDict
