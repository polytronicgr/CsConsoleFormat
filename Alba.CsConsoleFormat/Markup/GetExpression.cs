﻿using System;
using System.Reflection;
using Alba.CsConsoleFormat.Framework.Text;

// TODO Support more complex getter expressions
namespace Alba.CsConsoleFormat.Markup
{
    public class GetExpression
    {
        public object Source { get; set; }
        public string Path { get; set; }

        public object GetValue ()
        {
            if (Source == null)
                return null;
            if (Path.IsNullOrEmpty())
                return Source;

            object value = Source;
            foreach (string propName in Path.Split('.')) {
                if (value == null)
                    return null;
                PropertyInfo prop = value.GetType().GetProperty(propName);
                if (prop == null)
                    throw new InvalidOperationException("Cannot resolve property '{0}'.".Fmt(propName));
                value = prop.GetValue(value);
            }
            return value;
        }
    }
}