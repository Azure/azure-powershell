function RandomString([bool]$allChars, [int32]$len) {
    if ($allChars) {
        return -join ((33..126) | Get-Random -Count $len | % {[char]$_})
    } else {
        return -join ((48..57) + (97..122) | Get-Random -Count $len | % {[char]$_})
    }
}

function RandomResolverName([bool]$allChars, [int32]$len) {
    return "dnsresolver" + (RandomString -allChars $false -len 6)
}
function GetRandomHashtable([int32]$size) {
    $hashtable = @{}

    $keyPrefix = "key"
    $valuePrefix = "value"

    For($i=0; $i -le $size; $i++){
        $randomSuffix = (RandomString -allChars $false -len 5)
        $hashtable.Add($keyPrefix + $randomSuffix, $valuePrefix + $randomSuffix)
    }
    return $hashtable
}

function RandomIp() {
    return (Get-Random -Minimum 0 -Maximum 256), (Get-Random -Minimum 0 -Maximum 256), (Get-Random -Minimum 0 -Maximum 256),(Get-Random -Minimum 0 -Maximum 256) -join "."
}

function RandomGUID() {
    return [guid]::NewGuid().toString()
}
