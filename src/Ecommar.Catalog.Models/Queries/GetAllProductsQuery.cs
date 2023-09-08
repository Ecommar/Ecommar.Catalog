using Ecommar.Catalog.Models.DTOs;
using MediatR;

namespace Ecommar.Catalog.Models.Queries;

public record GetAllProductsQuery : IRequest<List<ProductDto>?>;
