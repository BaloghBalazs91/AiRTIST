
using System.Text.Json;
using AiRTIST.Contracts;
using AiRTIST.Service.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AiRTIST.Model;
using AiRTIST.Service.OpenAIService;
using Azure.AI.OpenAI;

namespace AiRTIST.Controllers{
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize(Roles = "User, Admin")]
    public class UserController : ControllerBase
    {
        private readonly IUserMethods _userMethods;
        private readonly OpenAIService _openAiService;

        
        public UserController(IUserMethods userMethods, OpenAIService openAiService)
        {
            _openAiService = openAiService;
            _userMethods = userMethods;

        }

        [HttpGet("GetAllPoems")]
        public async Task<IActionResult> GetPoems()
        {
            return Ok(await _userMethods.GetAllPoemsAsync());
        }
        

        [HttpPost("GenerateText")]
        public async Task<IActionResult> GenerateText([FromBody] PromptRequest request)
        {
            try
            {
                var response = await _openAiService.MakeChatRequestAsync(request.Prompt);
                var content = ExtractGeneratedContentFromResponse(response);

                if (content != null)
                    return Ok(new { content });
                else
                    return BadRequest("Failed to generate text.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = $"Error: {ex.Message}" });
            }
        }


        [HttpPost("AddPoem")]
        public async Task<IActionResult> AddPoem([FromBody] NewPoemRequest request)
        {
            try
            {
                var result = await _userMethods.AddPoemAsync(request.poemString, request.userID );

                if (result.Success)
                {
                    return Ok(result.Message);
                }
                else
                {
                    return BadRequest($"{result.Message}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception during poem creation: {ex.Message}");
                return StatusCode(500, "Internal Server Error");
            }
        }


        [HttpPatch("UpdatePoem")]
        public async Task<IActionResult> UpdatePoem([FromBody] UpdatePoemRequest request)
        {
            if (request.poemID == null)
            {
                return BadRequest("Updated poemID is null");
            }

            if (request.modifiedPoem == "")
            {
                return BadRequest("Updated poem string is empty");
            }

            var result = await _userMethods.UpdatePoemAsync(request.poemID, request.modifiedPoem);

            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpDelete("DeletePoem")]
        
        public async Task<IActionResult> DeletePoem([FromBody] int poemID)
        {
            if (poemID == null)
            {
                return BadRequest("Updated poemID is null");
            }

            var result = await _userMethods.DeletePoemAsync(poemID);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
        private string ExtractGeneratedContentFromResponse(string response)
        {
            // Mintapéldány JSON parse logika, feltételezve, hogy a válasz szerkezete hasonló a példáéhoz
            var jsonDoc = JsonDocument.Parse(response);
            var choices = jsonDoc.RootElement.GetProperty("choices");
            if (choices.GetArrayLength() > 0)
            {
                var content = choices[0].GetProperty("message").GetProperty("content").GetString();
                return content;
            }
            return null;
        }
    }
}
