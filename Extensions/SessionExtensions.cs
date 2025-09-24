using System.Text.Json;

namespace YemekSitesi.Extensions
{
    public static class SessionExtensions
    {
        public static void SetJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }
        public static T? Get<T>(this ISession session, string key) where T: class
        {
            var value = session.GetString(key);
            return value == null ? null : JsonSerializer.Deserialize<T>(value);
        }
    }
}
