/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
namespace Microsoft.Azure.PowerShell.Cmdlets.Portal.Runtime
{
    internal static class DictionaryExtensions
    {
        internal static void HashTableToDictionary<V>(System.Collections.Hashtable hashtable, System.Collections.Generic.IDictionary<string, V> dictionary)
        {
            foreach (var each in hashtable.Keys)
            {
                var key = each.ToString();
                var value = hashtable[key];
                if (null != value)
                {
                    if (value is System.Collections.Hashtable nested)
                    {
                        HashTableToDictionary<V>(nested, new System.Collections.Generic.Dictionary<string, V>());
                    }
                    else
                    {
                        try
                        {
                            dictionary[key] = (V)value;
                        }
                        catch
                        {
                            // Values getting dropped; not compatible with target dictionary. Not sure what to do here.
                        }
                    }
                }
            }
        }
    }
}