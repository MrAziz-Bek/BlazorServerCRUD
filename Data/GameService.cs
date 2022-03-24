using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;

    public List<Game> Games { get; set; } = new();

    public GameService(ApplicationDbContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task LoadGames()
    {
        Games = await _context.Games.ToListAsync();
    }
}