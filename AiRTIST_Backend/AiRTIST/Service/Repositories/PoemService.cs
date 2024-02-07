using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using AiRTIST.Data;
using AiRTIST.Model;
using AiRTIST.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AiRTIST.Service.Repositories;

public class PoemService: IUserMethods
{
private readonly AiRTISTDBContext _dbContext;


    public PoemService(AiRTISTDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Poem>> GetAllPoemsAsync()
    {
        try
        {
            List<Poem> poems = await _dbContext.Poems
                .OrderBy(l => l.CreatedAt)
                .ToListAsync();
            return poems;
        }
        catch(Exception ex)
        {
            throw;
        }
    }
    
    public async Task<PoemResult> AddPoemAsync(string generatedPoem, string userID)
    {
        try
        {
            var user = await _dbContext.Users.FindAsync(userID);
            if (user == null)
            {
                return new PoemResult(false, $"User with ID {userID} not found.");
            }
            Poem poemToAdd = new Poem(generatedPoem, userID);
            _dbContext.Poems.Add(poemToAdd);
            await _dbContext.SaveChangesAsync();
            return new PoemResult(true, $"Poem with {poemToAdd.PoemId} ID has been created");
        }
        catch (Exception ex)
        {
            return new PoemResult(false, $"Error: {ex.Message}");
        }
    }
    
    public async Task<PoemResult> UpdatePoemAsync(int poemID, string modifiedPoemString)
    {
        try
        {
            Poem existingPoem = await _dbContext.Poems.FirstOrDefaultAsync(p => p.PoemId == poemID);
            if (existingPoem == null)
            {
                return new PoemResult(false, $"Poem with Id {poemID} not found.");
            }
            existingPoem.GeneratedPoem = modifiedPoemString;
            await _dbContext.SaveChangesAsync();
            return new PoemResult(true, $"{existingPoem} has been updated");
        }
        catch (Exception ex)
        {
            
            return new PoemResult(false, $"Error: {ex.Message}");
        }
    }
    


    public async Task<PoemResult> DeletePoemAsync(int poemID)
    {
        try
        {
            Poem poemToDelete = await _dbContext.Poems.FirstOrDefaultAsync(p => p.PoemId == poemID);
            _dbContext.Poems.Remove(poemToDelete);
            await _dbContext.SaveChangesAsync();
            return new PoemResult(true, $"{poemToDelete} has been deleted");
        }
        catch (Exception ex)
        {
            return new PoemResult(false, $"Error: {ex.Message}");
        }
    }

}