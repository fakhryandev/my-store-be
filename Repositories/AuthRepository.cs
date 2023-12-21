public interface IAuthRepository
{
    UserDTO? GetUserByUsername(string username);
    void AddUser(User user);
}

public class AuthRepository : IAuthRepository
{
    private readonly DataContext _context;

    public AuthRepository(DataContext context)
    {
        _context = context;
    }

    public void AddUser(User user)
    {
        UserDTO userToSave = new UserDTO
        {
            username = user.username,
            password = user.password,
            createdby = "DEV",
        };

        _context.users.Add(userToSave);
        _context.SaveChanges();
    }

    public UserDTO? GetUserByUsername(string username)
    {
        return _context.users.SingleOrDefault(x => x.username == username);
    }
}