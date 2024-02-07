using AiRTIST.Contracts;
using AiRTIST.Model;

namespace AiRTIST.Service.Repositories;

public interface IUserMethods
{
    Task<List<Poem>> GetAllPoemsAsync();
    Task<PoemResult> UpdatePoemAsync(int poemID, string modifiedPoemString);
    Task<PoemResult> DeletePoemAsync(int poemID);
    Task<PoemResult> AddPoemAsync(string userID, string generatedPoem);
}