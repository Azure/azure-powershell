$content = get-content a.md

$newFileName = "ChangeLog.md"

for ($i = 0; $i -lt $content.Count; $i++) {
    $line = $content[$i]
    $file = $line.Substring($line.IndexOf("."))
    
    $fileName = Split-Path -Leaf $file
    $filePath = Split-Path -Parent $file
    
    # 构建新文件路径和新文件名
    $newFilePath = $filePath
    $newFileName = "ChangeLog.md"
    
    # 检查文件是否存在
    if (Test-Path $file) {
        # 检查新文件名是否与旧文件名相同，如果不同则重命名,。注意：比较是大小写敏感的
        
        if ($fileName -ceq $newFileName) {
            Write-Output "文件 $file 已经是 $newFileName"
        }
        else {
            $fullPath = Join-Path $newFilePath $newFileName
            Rename-Item $file -NewName $fullPath
        }
    }
    else {
        Write-Output "文件 $file 不存在"
    }
}



