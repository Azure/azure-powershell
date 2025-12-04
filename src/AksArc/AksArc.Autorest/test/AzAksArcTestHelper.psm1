# Get $Count number of 3-digit unique random numbers.
function Get-RandomNumbers ([int] $Count) {
    $uniqueNumbers = @()
    while ($uniqueNumbers.Count -lt $Count) {
        $num = Get-Random -Minimum 100 -Maximum 1000
        if (-not $uniqueNumbers.Contains($num)) {
            $uniqueNumbers += $num
        }
    }
    return $uniqueNumbers
}
