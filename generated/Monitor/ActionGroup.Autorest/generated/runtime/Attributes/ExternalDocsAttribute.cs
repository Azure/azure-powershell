/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public class ExternalDocsAttribute : Attribute
    {

        public string Description { get; }

        public string Url { get; }

        public ExternalDocsAttribute(string url)
        {
            Url = url;
        }

        public ExternalDocsAttribute(string url, string description)
        {
            Url = url;
            Description = description;
        }
    }
}
