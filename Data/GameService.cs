using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerCRUD.Data;

public class GameService : IGameService
{
    private readonly ApplicationDbContext _context;
    private readonly NavigationManager _navigationManager;

    public List<Game> Games { get; set; } = new();

    public GameService(ApplicationDbContext context, NavigationManager navigationManager)
    {
        _context = context;
        _navigationManager = navigationManager;
        _context.Database.EnsureCreated();
    }

    public async Task LoadGames()
    {
        Games = await _context.Games.ToListAsync();
    }

    public async Task<Game> GetSingleGame(int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game is null)
            throw new Exception("No game here, :/");

        return game;
    }

    public async Task CreateGame(Game game)
    {
        try
        {
            await _context.AddAsync(game);
            await _context.SaveChangesAsync();

            _navigationManager.NavigateTo("videogames");
        }
        catch (Exception ex)
        {
            throw new Exception($"Adding game is failed :/\n{ex.Message}");
        }
    }

    public async Task UpdateGame(Game game, int id)
    {
        var dbGame = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (dbGame is null)
            throw new Exception("No game here, :/");

        dbGame.Name = game.Name ?? dbGame.Name;
        dbGame.Developer = game.Developer ?? dbGame.Developer;
        dbGame.Release = game.Release ?? dbGame.Release;

        try
        {
            _context.Games.Update(dbGame);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }
        catch(Exception ex)
        {
            throw new Exception($"Updating game is failed :/\n{ex.Message}");
        }
    }

    public async Task DeleteGame(int id)
    {
        var game = await _context.Games.FirstOrDefaultAsync(g => g.Id == id);
        if (game is null)
            throw new Exception("No game here, :/");

        try
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            _navigationManager.NavigateTo("videogames");
        }
        catch (Exception ex)
        {
            throw new Exception($"Deleting game is failed :/\n{ex.Message}");
        }
    }
}