﻿using ECommerce.Application.Commands;
using ECommerce.Application.Queries;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CartItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CartItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CartItemModel>>> GetAllCartItems()
        {
            var userId = Request.Headers["x-user-id"].FirstOrDefault();
            var parsedUserId = Guid.Parse(userId!);
            var query = new CartItemQuery.GetAllCartItemsQuery(parsedUserId);
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<CartItemModel>> AddCartItem([FromBody] AddCartItemDTO addCartItemDto, [FromHeader] Guid shopperId)
        {
            var command = new CartItemCommand.AddCartItemCommand(shopperId, addCartItemDto.ProductName);
            var result = await _mediator.Send(command);

            return CreatedAtAction(nameof(AddCartItem), new { cartItemId = result.CartItemId }, result);
        }

        [HttpPut("{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CartItemModel>> UpdateCartItem([FromBody] UpdateCartItemDTO updateCartItemDto, [FromRoute] Guid cartItemId)
        {
            var command = new CartItemCommand.UpdateCartItemCommand
            {
                CartItemId = cartItemId,
                ProductName = updateCartItemDto.ProductName,
            };

            var updatedCartItem = await _mediator.Send(command);

            if (updatedCartItem == null)
            {
                return NotFound();
            }

            return updatedCartItem;
        }

        [HttpDelete("{cartItemId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteCartItem(Guid cartItemId)
        {
            var command = new CartItemCommand.DeleteCartItemCommand(cartItemId);
            await _mediator.Send(command);
            return NoContent();
        }
    }
}