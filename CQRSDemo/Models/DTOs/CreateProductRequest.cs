namespace CQRSDemo.Models.DTOs;

public record CreateProductRequest(string Name, decimal Price, int Stock);

