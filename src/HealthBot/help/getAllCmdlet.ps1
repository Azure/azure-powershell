$allfiles = Get-ChildItem
$Content
foreach($file in $allfiles)
{
    if($file.name.contains('-') -and !$file.name.contains('Object'))
    {
        $fileContent = Get-Content $file.name | Out-String
        $fileWorkContent = $fileContent.split("SYNTAX")[1].Split("## DESCRIPTION")[0].Replace('###','-').split('```')
        $addPoowershell = $true
        $mixContent = ''
        foreach($eachContent in $fileWorkContent)
        {
            if($addPoowershell)
            {
                $mixContent = $mixContent + $eachContent + '```Powershell'
            }else
            {
                $mixContent = $mixContent + $eachContent + '```'
            }
            $addPoowershell= !$addPoowershell
        }
        $mixContent = $mixContent.Substring(0,$mixContent.Length-13)
        $content = $content + '#### Name :' + $file.name.Replace('.md','') + "`n`n#### Syntax:" + $mixContent
        # $content = $content + '#### Name :' + $file.name.Replace('.md','') + "`n`n#### Syntax:" + $fileContent.split("SYNTAX")[1].Split("## DESCRIPTION")[0].Replace('###','-')
    }
}
$Content | Out-File .\OutFile.md