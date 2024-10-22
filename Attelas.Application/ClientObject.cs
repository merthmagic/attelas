namespace Attelas.Application;

/// <summary>
/// A generic class to return data to the client
/// </summary>
/// <typeparam name="T"></typeparam>
public class ClientObject<T> where T : class
{
    /// <summary>
    /// indicates if the operation was successful
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// payload to be returned to the client
    /// </summary>
    public T Data { get; set; }
}