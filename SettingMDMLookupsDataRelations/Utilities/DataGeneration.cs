using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SettingMDMLookupsDataRelations.Utilities
{
    internal static class DataGeneration
    {
        #region Methods :
        public static T CreateObjData<T>() where T : class => (T)GetObjectData(typeof(T));
        #endregion
        #region Helpers :
        private static object GetObjectData(Type objType)
        {
            var obj = Activator.CreateInstance(objType);
            foreach (var property in objType.GetProperties())
                property.SetValue(obj, GetPropertyValue(property.PropertyType));
            return obj;
        }
        private static object GetPropertyValue(Type propType)
        {
            if (propType == typeof(string)) return $"test";
            else if (propType == typeof(DateTime)) return DateTime.Now;
            else if (propType == typeof(bool)) return false;

            else if (propType == typeof(byte)
                || propType == typeof(sbyte)
                || propType == typeof(short)
                || propType == typeof(ushort)
                || propType == typeof(int)
                || propType == typeof(uint)
                || propType == typeof(long)
                || propType == typeof(ulong))
                return 1;

            else if (propType == typeof(float)
                || propType == typeof(double)
                || propType == typeof(decimal)) return 1.0;
            else if (propType.IsGenericType && propType.GetGenericTypeDefinition() == typeof(Nullable<>)) return GetNullValue(propType);
            else if (typeof(IEnumerable<object>).IsAssignableFrom(propType)) return GetListValue(propType);

            else if (propType.IsArray) return GetArrayValue(propType);

            else if ((propType.IsClass || propType.IsValueType)
                && propType != typeof(ExtensionDataObject)
                && propType != typeof(string)) return GetObjectData(propType);

            return default;
        }
        private static object GetListValue(Type propType)
        {
            var listType = typeof(List<>);
            var genericArgs = propType.GetGenericArguments();
            var concreteType = listType.MakeGenericType(genericArgs);
            var value = GetPropertyValue(genericArgs[0]);
            var newList = Activator.CreateInstance(concreteType);
            newList.GetType().GetMethod("Add").Invoke(newList, new[] { value });
            return newList;
        }
        private static object GetArrayValue(Type propType)
        {
            Type elementType = propType.GetElementType();
            var value = GetPropertyValue(elementType);
            var newArray = Array.CreateInstance(elementType, 1);
            newArray.SetValue(value, 0);
            return newArray;
        }
        private static object GetNullValue(Type propType)
        {
            var genericArgs = propType.GetGenericArguments();
            return GetPropertyValue(genericArgs[0]);
        }
        #endregion
    }
}
