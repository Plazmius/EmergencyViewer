using System;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class ComponentInfoAttribute : Attribute
    {
        public string Author;
        public string Description;
        public string Version;
    }
}
