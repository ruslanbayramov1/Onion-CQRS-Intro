﻿using AutoMapper;
using Elastic.Clients.Elasticsearch;
using Elastic.Clients.Elasticsearch.QueryDsl;
using OnionAPI.Application.DTOs.Products;
using OnionAPI.Application.Interfaces;
using OnionAPI.Domain.Entities;
using OnionAPI.Domain.Enums;
using OnionAPI.Domain.Exceptions.Common;
using OnionAPI.Persistence.Clients;

namespace OnionAPI.Persistence.Implements;

public class ProductElasticService : IProductElasticService
{
    private readonly ElasticsearchClient client;
    private readonly IMapper mapper;
    private readonly string index;
    public ProductElasticService(IMapper mapper)
    {
        client = ElasticClient.GetClient(ElasticIndexes.products);
        this.mapper = mapper;
        index = ElasticIndexes.products.ToString();
    }

    public async Task CreateAsync(ProductCreateDto dto, Guid productId)
    {
        Product product = mapper.Map<Product>(dto);
        product.Id = productId;

        CreateRequest<Product> request = new CreateRequest<Product>(product.Id)
        { 
            Document = product,
        };

        CreateResponse response = await client.CreateAsync(request);

        if (!response.IsValidResponse)
            throw new NotValidException(response.ElasticsearchServerError!.Error.Reason, response.ElasticsearchServerError.Status);
    }

    public async Task<List<ProductGetDto>> GetAllAsync()
    {
        SearchRequest searchRequest = new(index)
        {
            Query = new MatchQuery(new Field("isDeleted"))
            { 
                Query = false,
            }
        };

        SearchResponse<Product> response = await client.SearchAsync<Product>(searchRequest);

        if (!response.IsValidResponse)
            throw new NotValidException(response.ElasticsearchServerError!.Error.Reason, response.ElasticsearchServerError.Status);

        var data = mapper.Map<List<ProductGetDto>>(response.Documents);
        return data;
    }

    public async Task<ProductGetDto> GetByIdAsync(Guid id)
    {
        GetResponse<Product> response = await client.GetAsync<Product>(id);

        if (!response.IsValidResponse)
            throw new NotFoundException<Product>();

        if (response.Source == null || response.Source?.IsDeleted == true)
            throw new NotFoundException<Product>();

        ProductGetDto dto = mapper.Map<ProductGetDto>(response.Source);

        return dto;
    }
    
    public async Task UpdateAsync(ProductUpdateDto dto, Guid productId)
    {
        Product product = mapper.Map<Product>(dto);

        UpdateRequest<Product, ProductUpdateDto> request = new (index, productId)
        {
            Doc = dto,
        };

        UpdateResponse<Product> response = await client.UpdateAsync(request);

        if (!response.IsValidResponse)
            throw new NotValidException(response.ElasticsearchServerError!.Error.Reason, response.ElasticsearchServerError.Status);
    }

    public async Task DeleteAsync(Guid productId, ProductDeleteDto dto)
    {
        Product product = mapper.Map<Product>(dto);

        UpdateRequest<Product, ProductDeleteDto> request = new(index, productId)
        {
            Doc = dto,
        };

        UpdateResponse<Product> response = await client.UpdateAsync(request);

        if (!response.IsValidResponse)
            throw new NotValidException(response.ElasticsearchServerError!.Error.Reason, response.ElasticsearchServerError.Status);
    }
}
