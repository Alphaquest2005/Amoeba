﻿using System;
using System.ComponentModel;

namespace Utilities
{
    public static class NullableExtensions
    {
        public static Nullable<T> ToNullable<T>(this string s) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
                if (!string.IsNullOrEmpty(s) && s.Trim().Length > 0)
                {
                    TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
                    result = (T)conv.ConvertFrom(s);
                }
            }
            catch { }
            return result;
        }

        public static Nullable<T> ToNullable<T>(this object s,T type ) where T : struct
        {
            Nullable<T> result = new Nullable<T>();
            try
            {
               TypeConverter conv = TypeDescriptor.GetConverter(typeof(T));
               result = (T)conv.ConvertFrom(s);
            }
            catch { }
            return result;
        }
    }
}
