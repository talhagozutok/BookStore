using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers;

[ApiController]
[Route("api/books")]
//[Route("api/v{v:apiversion}/books")]
[ApiExplorerSettings(GroupName = "v2")]
public class BooksV2Controller : ControllerBase
{
    private readonly IServiceManager _manager;

    public BooksV2Controller(IServiceManager manager)
    {
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllBooksAsync()
    {
        var books = await _manager.BookService.GetAllBooksAsync(false);
        var booksV2 = books.Select(b => new { b.Title, b.Id });
        return Ok(booksV2);
    }
}
