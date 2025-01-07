using AutoMapper;
using LibraryManagement.Application.DTO;
using LibraryManagement.Application.Handler.AuthorFeature.Command;
using LibraryManagement.Application.Handler.AuthorFeature.Query;
using LibraryManagement.Application.Handler.GenericFeature.GenericQuery;
using LibraryManagement.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;


        public AuthorController(IMediator mediator, IMapper _mapper)
        {
            _mediator = mediator;
            this._mapper = _mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAuthorAsync()
        {
            var result = await _mediator.Send(new GetAllAuthorQuery());
            var returnResult = _mapper.Map<IEnumerable<AuthorDto>>(result);

            return Ok(returnResult);
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAuthorBYIdAsync([FromRoute] int id)
        {
            var result = await _mediator.Send(new GetByIdGenericQuery<Author>(id));
            var returnResult = _mapper.Map<AuthorDto>(result);
            return Ok(returnResult);
        }
        [HttpPost]
        public async Task<IActionResult> AddAuthorAsync([FromBody] AuthorDto authorDto)
        {
            var author = _mapper.Map<Author>(authorDto);
            var result = await _mediator.Send(new AddAuthorCommand(author));
            return Ok(authorDto);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthorByIdAsync([FromRoute] int id)
        {
            var result = await _mediator.Send(new DeleteAuthorByIdCommand(id));
            var returnResult = _mapper.Map<AuthorDto>(result);
            return Ok(new { returnResult, mssg = "deleted" });
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync([FromBody] AuthorDto authorDto, [FromRoute] int id)
        {
            var author = _mapper.Map<Author>(authorDto);
            var result = await _mediator.Send(new UpdateAuthorCommand(author, id));
            return Ok(new { mssg = "user updated", prevData = _mapper.Map<AuthorDto>(result), newData = authorDto });
        }
    }
}
