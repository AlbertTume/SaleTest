namespace SaliTest.Application.DTOs
{
    public class LoginResponseDto
    {
        public long UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public bool IsSuccess { get; set; }
    }
}