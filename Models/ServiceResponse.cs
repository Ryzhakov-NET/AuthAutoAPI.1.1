namespace RegistrationAPI.Models
{
    public class ServiceResponse<T>     //Wrapper object
    {
        public T Data { get; set; }

        public bool Success { get; set; } = true;

        public string Message { get; set; } = null;
    }
}
