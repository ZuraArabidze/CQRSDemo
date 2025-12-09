namespace CQRSDemo.Models.DTOs;

public record ProductDto(int Id, string Name, decimal Price, int Stock, DateTime CreatedAt);
