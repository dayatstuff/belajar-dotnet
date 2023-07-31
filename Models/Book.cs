namespace BookApi.Models;

public class Book 
{
    public long id {get; set; }
    public string? title {get; set; }
    public string?  author {get; set; }
    public string?  publisher {get; set; }
}