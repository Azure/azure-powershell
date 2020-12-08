function Get-RandomNumbers($Prefix, $Length) {
    $Generated = ""
    for($i = 0; $i -lt $Length; $i++){ $Generated += Get-Random -Maximum 10 }
    return $Prefix + $Generated
}

function Get-RandomName() {
    $Noun = Get-Content -Path "$PSScriptRoot/nouns.txt" | Get-Random
    $Adjective = Get-Content -Path "$PSScriptRoot/adjectives.txt" | Get-Random
    $Number = Get-Random -Maximum 10
    $RandomName =  $Adjective + (Get-Culture).TextInfo.ToTitleCase($Noun) + $Number
    return $RandomName

}

function Get-GeneratePassword() {
    $Password = ''
    $Chars = 'abcdefghiklmnoprstuvwxyzABCDEFGHKLMNOPRSTUVWXYZ1234567890'
    $SpecialChars = '!$%&/()=?}][{@#*+'
    for ($i = 0; $i -lt 10; $i++ ) { $Password += $Chars[(Get-Random -Minimum 0 -Maximum $Chars.Length)] }
    for ($i = 0; $i -lt 6; $i++ ) { $Password += $SpecialChars[(Get-Random -Minimum 0 -Maximum $SpecialChars.Length)] }
    $Password = ($Password -split '' | Sort-Object {Get-Random}) -join ''
    return $Password
}
