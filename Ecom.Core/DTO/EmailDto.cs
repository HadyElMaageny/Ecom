namespace Ecom.Core.DTO;

public class EmailDto(string to, string from, string subject, string content)
{
    public string To { get; set; } = to;
    public string From { get; set; } = from;
    public string Subject { get; set; } = subject;
    public string Content { get; set; } = content;
}