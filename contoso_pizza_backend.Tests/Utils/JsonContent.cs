using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace contoso_pizza_backend.Tests.Utils
{
    /// <summary>
	/// Helper class to convert a <see cref="StringContent"/> into a JsonContent
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class JsonContent<T> : StringContent
    {
        public JsonContent(T entity) : base(JsonConvert.SerializeObject(entity))
        {
            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }
    }
}