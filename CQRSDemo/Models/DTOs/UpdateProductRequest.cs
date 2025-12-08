namespace CQRSDemo.Models.DTOs;

public record UpdateProductRequest(string Name, decimal Price, int Stock);

