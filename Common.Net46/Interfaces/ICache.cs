using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Net46.Interfaces
{
    public interface ICache
    {
        object Set(string key, object value);
        object Get(string key);
        void Remove(string key);
    }
}
