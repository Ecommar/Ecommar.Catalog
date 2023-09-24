using Ecommar.Catalog.Shared.DTOs;
using MediatR;

namespace Ecommar.Catalog.Shared.Queries;

public record GetAllProductsQuery : IRequest<List<ProductDto>?>;
