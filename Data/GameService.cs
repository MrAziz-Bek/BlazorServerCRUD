namespace BlazorServerCRUD.Data;

public class GameService
{
    private readonly ApplicationDbContext _context;

    public GameService(ApplicationDbContext context)
    {
        _context = context;
    }
}