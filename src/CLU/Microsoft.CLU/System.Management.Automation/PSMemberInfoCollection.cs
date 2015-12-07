using System.Collections;
using System.Collections.Generic;

namespace System.Management.Automation
{
    public abstract class PSMemberInfoCollection<T> : IEnumerable<T>, IEnumerable where T : PSMemberInfo
    {
        protected PSMemberInfoCollection() { }

        public abstract T this[string name] { get; }

        public abstract void Add(T member);
        public abstract void Add(T member, bool preValidated);
        public abstract IEnumerator<T> GetEnumerator();
        public abstract void Remove(string name);

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)this.GetEnumerator();
        }
    }
}
