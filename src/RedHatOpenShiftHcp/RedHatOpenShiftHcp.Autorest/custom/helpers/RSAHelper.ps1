# ----------------------------------------------------------------------------------
# Copyright (c) Microsoft Corporation. All rights reserved.
# Licensed under the Apache License, Version 2.0 (the "License"); see LICENSE for details.
# ----------------------------------------------------------------------------------
#
# Windows PowerShell 5.1 (.NET Framework) lacks RSA.ExportRSAPrivateKey(), which PowerShell 7+ (.NET Core)
# provides. This manual PKCS#1 (RSAPrivateKey) DER encoder fills that gap so the custom
# Request-AzRedHatOpenShiftHcpClusterAdminCredential cmdlet can emit a PEM private key on both editions.
# Ported from Az.ConnectedKubernetes (src/ConnectedKubernetes/.../custom/helpers/RSAHelper.ps1).

function ExportRSAPrivateKeyBase64 {
    [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.DoNotExportAttribute()]
    param(
        [Parameter(Mandatory)]
        [System.Security.Cryptography.RSA]
        $RSA
    )
    process {
        $RSAParams = $RSA.ExportParameters(1)
        [byte]$Sequence = 0x30
        [byte[]]$Version = (0x00)
        $stream = [System.IO.MemoryStream]::new()
        $writer = [System.IO.BinaryWriter]::new($stream)
        $writer.Write($Sequence); # SEQUENCE
        $innerStream = [System.IO.MemoryStream]::new()
        $innerWriter = [System.IO.BinaryWriter]::new($innerStream)

        EncodeIntegerBigEndian $innerWriter $Version
        EncodeIntegerBigEndian $innerWriter $RSAParams.Modulus
        EncodeIntegerBigEndian $innerWriter $RSAParams.Exponent
        EncodeIntegerBigEndian $innerWriter $RSAParams.D
        EncodeIntegerBigEndian $innerWriter $RSAParams.P
        EncodeIntegerBigEndian $innerWriter $RSAParams.Q
        EncodeIntegerBigEndian $innerWriter $RSAParams.DP
        EncodeIntegerBigEndian $innerWriter $RSAParams.DQ
        EncodeIntegerBigEndian $innerWriter $RSAParams.InverseQ

        $length = ([int]($innerStream.Length))
        EncodeLength $writer $length
        $writer.Write($innerStream.GetBuffer(), 0, $length)

        $base64 = [Convert]::ToBase64String($stream.GetBuffer(), 0, ([int]($stream.Length)))

        return $base64
    }
}

function EncodeLength {
    [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.DoNotExportAttribute()]
    param(
        [System.IO.BinaryWriter]$stream,
        [int]$length
    )
    process {
        [byte]$bytex80 = 0x80
        if ($length -lt 0) {
            throw "Length must be non-negative"
        }
        if ($length -lt $bytex80) {
            $stream.Write(([byte]$length))
        }
        else {
            $temp = $length
            $bytesRequired = 0;
            while ($temp -gt 0) {
                $temp = $temp -shr 8
                $bytesRequired++
            }

            [byte]$byteToWrite = $bytesRequired -bor $bytex80
            $stream.Write($byteToWrite)
            $iValue = ($bytesRequired - 1)
            [byte]$0ffByte = 0xff
            for ($i = $iValue; $i -ge 0; $i--) {
                [byte]$byteToWrite = ($length -shr (8 * $i) -band $0ffByte)
                $stream.Write($byteToWrite )
            }
        }
    }
}

function EncodeIntegerBigEndian {
    [Microsoft.Azure.PowerShell.Cmdlets.RedHatOpenShiftHcp.DoNotExportAttribute()]
    param(
        [System.IO.BinaryWriter]$stream,
        [byte[]]$value,
        [bool]$forceUnsigned = $true
    )
    process {
        [byte]$Integer = 0x02

        $stream.Write($Integer); # INTEGER
        $prefixZeros = 0
        for ($i = 0; $i -lt $value.Length; $i++) {
            if ($value[$i] -ne 0) { break }
            $prefixZeros++
        }
        if (($value.Length - $prefixZeros) -eq 0) {
            EncodeLength $stream 1
            $stream.Write(([byte]0))
        }
        else {
            [byte]$newByte = 0x7f
            if (($forceUnsigned) -AND ($value[$prefixZeros] -gt $newByte)) {
                EncodeLength $stream ($value.Length - $prefixZeros + 1)
                $stream.Write(([byte]0))
            }
            else {
                EncodeLength $stream ($value.Length - $prefixZeros)
            }
            for ($i = $prefixZeros; $i -lt $value.Length; $i++) {
                $stream.Write($value[$i])
            }
        }
    }
}
