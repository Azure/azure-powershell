﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System.Management.Automation
{
    public enum ErrorCategory
    {
        NotSpecified = 0,
        OpenError = 1,
        CloseError = 2,
        DeviceError = 3,
        DeadlockDetected = 4,
        InvalidArgument = 5,
        InvalidData = 6,
        InvalidOperation = 7,
        InvalidResult = 8,
        InvalidType = 9,
        MetadataError = 10,
        NotImplemented = 11,
        NotInstalled = 12,
        ObjectNotFound = 13,
        OperationStopped = 14,
        OperationTimeout = 15,
        SyntaxError = 16,
        ParserError = 17,
        PermissionDenied = 18,
        ResourceBusy = 19,
        ResourceExists = 20,
        ResourceUnavailable = 21,
        ReadError = 22,
        WriteError = 23,
        FromStdErr = 24,
        SecurityError = 25,
        ProtocolError = 26,
        ConnectionError = 27,
        AuthenticationError = 28,
        LimitsExceeded = 29,
        QuotaExceeded = 30,
        NotEnabled = 31,
    }
}
