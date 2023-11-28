/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    internal struct SourceLocation
    {
        private int line;
        private int column;
        private int position;

        internal SourceLocation(int line = 0, int column = 0, int position = 0)
        {
            this.line = line;
            this.column = column;
            this.position = position;
        }

        internal int Line => line;

        internal int Column => column;

        internal int Position => position;

        internal void Advance()
        {
            this.column++;
            this.position++;
        }

        internal void MarkNewLine()
        {
            this.line++;
            this.column = 0;
        }

        internal SourceLocation Clone()
        {
            return new SourceLocation(line, column, position);
        }
    }
}