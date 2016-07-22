using System.Threading.Tasks;

namespace RestClientHelper.Abstractions
{
    /// <summary>
    /// Abstraction of the Class that handles the calls to a REST service
    /// </summary>
    /// <typeparam name="T">The expected type of the call's result</typeparam>
	public interface IRestClient<T>
	{
        /// <summary>
        /// Call to the REST API
        /// </summary>
        /// <param name="query">Query to excecute</param>
        /// <returns></returns>
		Task<T> CallListEndPoint(string query);
	}
}
