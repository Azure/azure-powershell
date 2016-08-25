// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using System;

namespace StaticAnalysis
{
    /// <summary>
    /// Abstract class to implement the Decorator pattern
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Decorator<T>
    {
        Action<T> _action;
        string _name;

        protected Decorator(Action<T> action, string name)
        {
            _action = action;
            _name = name;
            Inner = null;
        }

        public static Decorator<T> Create()
        {
            return new Decorator<T>(r => { }, "default");
        }

        public void Apply(T record)
        {
            _action(record);
            if (Inner != null)
            {
                Inner.Apply(record);
            }
        }

        public void AddDecorator(Action<T> action, string name)
        {
            if (action == null)
            {
                throw new ArgumentNullException("action");
            }

            if (name == null)
            {
                throw new ArgumentNullException("name");
            }

            if (Inner == null)
            {
                Inner = new Decorator<T>(action, name);
            }
            else
            {
                Inner.AddDecorator(action, name);
            }
        }

        public void Remove(string name)
        {
            if (Inner != null)
            {
                if (string.Equals(Inner._name, name))
                {
                    Inner = Inner.Inner;
                }
                else
                {
                    Inner.Remove(name);
                }
            }
        }

        protected Decorator<T> Inner { get; set; }
    }
}
