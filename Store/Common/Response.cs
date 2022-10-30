namespace Store.Common
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public T Result { get; set; }
        public string[] Messages { get; set; }
    }
}
