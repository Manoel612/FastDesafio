namespace FastDesafio.Models
{
    public class ResponseModel<T>
    {
        public T? Data { get; set; }
        public String Message { get; set; } = string.Empty;
        public Boolean IsSuccess { get; set; } = true;
    }
}
