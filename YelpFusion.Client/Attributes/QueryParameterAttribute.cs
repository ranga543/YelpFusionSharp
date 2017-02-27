using System;

namespace YelpFusion.Client.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class QueryParameterAttribute : System.Attribute
    {
        public string Name { get; set; }

        public QueryParameterAttribute(string name)
        {
            Name = name;
        }
    }
}