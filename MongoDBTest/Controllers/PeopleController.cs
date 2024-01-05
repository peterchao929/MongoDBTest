using Microsoft.AspNetCore.Mvc;
using MongoDBTest.MongoCollection;
using MongoDBTest.Services;

namespace MongoDBTest.Controllers;

/// <summary>
/// 人員
/// </summary>
[Produces("application/json")]
[Route("[controller]/[action]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status400BadRequest)]
[ProducesResponseType(StatusCodes.Status404NotFound)]
public sealed class PeopleController : ControllerBase
{
    private readonly PeopleService _peopleService;

    public PeopleController(PeopleService peopleService)
    {
        _peopleService = peopleService;
    }

    /// <summary>
    /// 查詢人員清單
    /// </summary>
    /// <returns>人員清單</returns>
    [HttpGet]
    public async Task<IEnumerable<People>> GetList()
    {
        var result = await _peopleService.GetList();

        return result;
    }

    /// <summary>
    /// 查詢單筆人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <returns>人員</returns>
    [HttpGet("{id:length(24)}")]
    public async Task<ActionResult<People>> GetPeople([FromRoute] string id)
    {
        var result = await _peopleService.GetPeopleById(id);

        if (result == null)
        {
            return NotFound();
        }

        return result;
    }

    /// <summary>
    /// 新增人員資料
    /// </summary>
    /// <param name="addDto">新增資料</param>
    /// <returns>新增</returns>
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] People addDto)
    {
        await _peopleService.AddPeople(addDto);

        return CreatedAtAction(nameof(GetList), new { id = addDto.Id }, addDto);
    }

    /// <summary>
    /// 修改人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <param name="updateDto">修改資料</param>
    /// <returns>修改</returns>
    [HttpPut("{id:length(24)}")]
    public async Task<IActionResult> Update([FromRoute] string id, [FromBody] People updateDto)
    {
        var result = await _peopleService.GetPeopleById(id);

        if (result == null)
        {
            return NotFound();
        }

        updateDto.Id = result.Id;

        await _peopleService.UpdatePeople(id, updateDto);

        return NoContent();
    }

    /// <summary>
    /// 刪除人員資料
    /// </summary>
    /// <param name="id">人員編號</param>
    /// <returns>刪除</returns>
    [HttpDelete("{id:length(24)}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var result = await _peopleService.GetPeopleById(id);

        if (result == null)
        {
            return NotFound();
        }

        await _peopleService.DeletePeople(id);

        return NoContent();
    }
}
