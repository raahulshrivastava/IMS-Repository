using System;
using System.ComponentModel;
using System.Reflection;

namespace IMS.Utilities
{
    public class EnumHelper
    {
        public static string GetEnumDescription(System.Enum value)
        {
            try
            {
                string description = value.ToString();
                FieldInfo fi = value.GetType().GetField(value.ToString());
                var attribute = (DescriptionAttribute)fi.GetCustomAttribute(typeof(DescriptionAttribute));
                return attribute.Description;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

        public static int GetEnumFromDescription(string description, Type enumType)
        {
            foreach (var field in enumType.GetFields())
            {
                DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
                if (attribute == null) continue;
                if (attribute.Description == description)
                {
                    return (int)field.GetValue(null);
                }
            }
            return 0;
        }
    }
}