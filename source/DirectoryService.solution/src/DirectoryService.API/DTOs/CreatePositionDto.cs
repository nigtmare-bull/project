namespace DirectoryService.API.DTOs;
public record CreatePositionDto(string name);
public record UpdatePositionDto(string name);
public record CreateLocationDto(string name, string Address);
public record UpdateLocationDto(string name, string Address);
