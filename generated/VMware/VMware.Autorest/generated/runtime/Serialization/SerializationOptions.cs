/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Linq;

namespace Microsoft.Azure.PowerShell.Cmdlets.VMware.Runtime.Json
{
    internal class SerializationOptions
    {
        internal static readonly SerializationOptions Default = new SerializationOptions();

        internal SerializationOptions() { }

        internal SerializationOptions(
            string[] include = null,
            bool ingoreNullValues = false)
        {
            Include = include;
            IgnoreNullValues = ingoreNullValues;
        }

        internal string[] Include { get; set; }

        internal string[] Exclude { get; set; }

        internal bool IgnoreNullValues { get; set; }

        internal PropertyTransformation[] Transformations { get; set; }

        internal Func<string, string> PropertyNameTransformer { get; set; }

        internal int MaxDepth { get; set; } = 5;

        internal bool IsIncluded(string name)
        {
            if (Exclude != null)
            {
                return !Exclude.Any(exclude => exclude.Equals(name, StringComparison.OrdinalIgnoreCase));
            }
            else if (Include != null)
            {
                return Include.Any(exclude => exclude.Equals(name, StringComparison.OrdinalIgnoreCase));
            }

            return true;
        }

        internal PropertyTransformation GetTransformation(string propertyName)
        {
            if (Transformations == null) return null;

            foreach (var t in Transformations)
            {
                if (t.Name.Equals(propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    return t;
                }
            }

            return null;
        }
    }
}