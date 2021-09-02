#This script converts securestring to plaintext

param(
    [Parameter(Mandatory, ValueFromPipeline)]
    [System.Security.SecureString]
    ${SecureString}
)

try {
    $ssPtr = [System.Runtime.InteropServices.Marshal]::SecureStringToBSTR($SecureString)
    $plaintext = [System.Runtime.InteropServices.Marshal]::PtrToStringBSTR($ssPtr)
} finally {
    [System.Runtime.InteropServices.Marshal]::ZeroFreeBSTR($ssPtr)
}

return $plaintext