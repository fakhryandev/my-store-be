public class User
{
    public required string username { get; set; }
    public required string password { get; set; }
    public bool is_admin { get; set; } = false;
}