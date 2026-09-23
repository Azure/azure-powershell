/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System.Text;

namespace Microsoft.Azure.PowerShell.Cmdlets.ComputeSchedule.Runtime.Json
{
    internal static class StringBuilderExtensions
    {
        /// <summary>
        /// Extracts the buffered value and resets the buffer
        /// </summary>
        internal static string Extract(this StringBuilder builder)
        {
            var text = builder.ToString();

            builder.Clear();

            return text;
        }
    }
}