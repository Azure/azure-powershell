/*---------------------------------------------------------------------------------------------
 *  Copyright (c) Microsoft Corporation. All rights reserved.
 *  Licensed under the MIT License. See License.txt in the project root for license information.
 *--------------------------------------------------------------------------------------------*/
﻿using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Reflection;

namespace Microsoft.Azure.PowerShell.Cmdlets.DeviceRegistry.Runtime.Json
{
    internal class JsonModel
    {
        private Dictionary<string, JsonMember> map;
        private readonly object _sync = new object();

        private JsonModel(Type type, List<JsonMember> members)
        {
            Type = type ?? throw new ArgumentNullException(nameof(type));
            Members = members ?? throw new ArgumentNullException(nameof(members));
        }

        internal string Name => Type.Name;

        internal Type Type { get; }

        internal List<JsonMember> Members { get; }

        internal JsonMember this[string name]
        {
            get
            {
                if (map == null)
                {
                    lock (_sync)
                    {
                        if (map == null)
                        {
                            map = new Dictionary<string, JsonMember>();

                            foreach (JsonMember m in Members)
                            {
                                map[m.Name.ToLower()] = m;
                            }
                        }
                    }
                }


                map.TryGetValue(name.ToLower(), out JsonMember member);

                return member;
            }
        }

        internal static JsonModel FromType(Type type)
        {
            var members = new List<JsonMember>();

            int i = 0;

            // BindingFlags.Instance | BindingFlags.Public

            foreach (var member in type.GetFields())
            {
                if (member.IsStatic) continue;

                if (member.IsDefined(typeof(IgnoreDataMemberAttribute))) continue; 

                members.Add(new JsonMember(member, i));
                
                i++;
            }

            foreach (var member in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (member.IsDefined(typeof(IgnoreDataMemberAttribute))) continue;

                members.Add(new JsonMember(member, i));
                
                i++;
            }

            members.Sort((a, b) => a.Order.CompareTo(b.Order)); // inline sort

            return new JsonModel(type, members);
        }
    }
}