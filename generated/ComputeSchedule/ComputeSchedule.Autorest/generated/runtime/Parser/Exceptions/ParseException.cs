/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    internal class ParserException : Exception
    {
        internal ParserException(string message)
            : base(message)
        { }

        internal ParserException(string message, SourceLocation location)
            : base(message)
        {

            Location = location;
        }

        internal SourceLocation Location { get; }
    }
}