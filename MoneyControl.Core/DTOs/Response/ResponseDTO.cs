namespace MoneyControl.Core.DTOs.Response
{
    public class ResponseDTO
    {
        public bool IsSuccess { get; set; } = false;
        public string Message { get; set; }
        public Object Data { get; set; }
    }
}
