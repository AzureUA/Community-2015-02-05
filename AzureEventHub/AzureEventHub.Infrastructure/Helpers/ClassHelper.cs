using System.Collections.Generic;
using System.Reflection;

namespace AzureEventHub.Infrastructure.Helpers
{
	public static class ClassHelper
	{
		public static Dictionary<string, object> CreatePropertyBag(this object obj)
		{
			var dict = new Dictionary<string, object>();

			if (obj == null)
			{
				return dict;
			}

			var t = obj.GetType();
			var props = t.GetProperties();

			foreach (PropertyInfo prp in props)
			{
				var value = prp.GetValue(obj, new object[] { });
				dict.Add(prp.Name, value);
			}

			return dict;
		}

		public static T GetFromPropertyBag<T>(this IDictionary<string, object> bag) where T : class, new()
		{
			var message = new T();

			foreach (var property in bag)
			{
				message.GetType().GetProperty(property.Key).SetValue(message, property.Value);
			}

			return message;
		}
	}
}
