/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;

namespace Microsoft.Azure.PowerShell.Cmdlets.Monitor.ActionGroup.Runtime.Json
{
    internal static class TypeExtensions
    {
        internal static bool IsNullable(this Type type) =>
            type.IsGenericType && type.GetGenericTypeDefinition().Equals(typeof(Nullable<>));

        internal static Type GetOpenGenericInterface(this Type candidateType, Type openGenericInterfaceType)
        {

            if (candidateType.IsGenericType && candidateType.GetGenericTypeDefinition() == openGenericInterfaceType)
            {
                return candidateType;
            }

            // Check if it references it's own converter....

            foreach (Type interfaceType in candidateType.GetInterfaces())
            {
                if (interfaceType.IsGenericType
                  && interfaceType.GetGenericTypeDefinition().Equals(openGenericInterfaceType))
                {
                    return interfaceType;
                }
            }

            return null;
        }

        // Author: Sebastian Good
        // http://stackoverflow.com/questions/503263/how-to-determine-if-a-type-implements-a-specific-generic-interface-type
        internal static bool ImplementsOpenGenericInterface(this Type candidateType, Type openGenericInterfaceType)
        {
            if (candidateType.Equals(openGenericInterfaceType))
            {
                return true;
            }

            if (candidateType.IsGenericType && candidateType.GetGenericTypeDefinition().Equals(openGenericInterfaceType))
            {
                return true;
            }

            foreach (Type i in candidateType.GetInterfaces())
            {
                if (i.IsGenericType && i.ImplementsOpenGenericInterface(openGenericInterfaceType))
                {
                    return true;
                }
            }

            return false;
        }
    }
}