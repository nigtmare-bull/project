using DirectoryService.API.Storage;
using DirectoryService.API.Models;
using DirectoryService.API.DTOs;
using Domain;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new() { Title = "Directory Service API", Version = "v1" });
});

var app = builder.Build();

PositionStorage.InitializeStorage();
LocationStorage.InitializeStorage();

// Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/api/positions", (CreatePositionDto request) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Results.BadRequest("Название должности не может быть пустым");

        var positionName = PositionName.Create(request.Name);
        var repository = new InMemoryPositionRepository();
        var uniquenessCriteria = new PositionNameUniquenessCriteria(repository);

        var position = Position.Create(
            PositionId.New(),
            positionName,
            uniquenessCriteria
        );

        PositionStorage.Add(position);

        return Results.Created($"/api/positions/{position.Id}", new
        {
            Id = position.Id.Value,
            Name = position.Name.Value,
            CreatedAt = position.LifeTime.CreatedAt
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Conflict(ex.Message);
    }
    catch (Exception)
    {
        return Results.StatusCode(500);
    }
})
.WithName("CreatePosition")
.WithOpenApi();

app.MapGet("/api/positions", () =>
{
    var positions = PositionStorage.GetAll().Select(p => new
    {
        Id = p.Id.Value,
        Name = p.Name.Value,
        CreatedAt = p.LifeTime.CreatedAt,
        LastUpdatedAt = p.LifeTime.LastUpdatedAt
    });
    return Results.Ok(positions);
})
.WithName("GetAllPositions")
.WithOpenApi();

app.MapGet("/api/positions/{id:guid}", (Guid id) =>
{
    var position = PositionStorage.GetById(new PositionId(id));
    
    if (position == null)
        return Results.NotFound($"Position с ID {id} не найдена");

    return Results.Ok(new
    {
        Id = position.Id.Value,
        Name = position.Name.Value,
        CreatedAt = position.LifeTime.CreatedAt,
        LastUpdatedAt = position.LifeTime.LastUpdatedAt
    });
})
.WithName("GetPositionById")
.WithOpenApi();

app.MapPatch("/api/positions/{id:guid}", (Guid id, UpdatePositionDto request) =>
{
    try
    {
        var position = PositionStorage.GetById(new PositionId(id));
        
        if (position == null)
            return Results.NotFound($"Position с ID {id} не найдена");

        var newName = PositionName.Create(request.Name);
        var repository = new InMemoryPositionRepository();
        var uniquenessCriteria = new PositionNameUniquenessCriteria(repository);

        position.ChangeName(newName, uniquenessCriteria);
        PositionStorage.Update(position);

        return Results.Ok(new
        {
            Id = position.Id.Value,
            Name = position.Name.Value,
            LastUpdatedAt = position.LifeTime.LastUpdatedAt
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Conflict(ex.Message);
    }
})
.WithName("UpdatePosition")
.WithOpenApi();

app.MapDelete("/api/positions/{id:guid}", (Guid id) =>
{
    var position = PositionStorage.GetById(new PositionId(id));
    
    if (position == null)
        return Results.NotFound($"Position с ID {id} не найдена");

    PositionStorage.Remove(new PositionId(id));

    return Results.NoContent();
})
.WithName("DeletePosition")
.WithOpenApi();

app.MapPost("/api/locations", (CreateLocationDto request) =>
{
    try
    {
        if (string.IsNullOrWhiteSpace(request.Name))
            return Results.BadRequest("Название локации не может быть пустым");

        if (string.IsNullOrWhiteSpace(request.Address))
            return Results.BadRequest("Адрес локации не может быть пустым");

        var locationName = LocationName.Create(request.Name);
        var locationAddress = LocationAddress.Create(request.Address);

        var location = Location.Create(
            LocationId.New(),
            locationName,
            locationAddress
        );

        LocationStorage.Add(location);

        return Results.Created($"/api/locations/{location.Id}", new
        {
            Id = location.Id.Value,
            Name = location.Name.Value,
            Address = location.Address.Value,
            CreatedAt = location.LifeTime.CreatedAt
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Conflict(ex.Message);
    }
    catch (Exception)
    {
        return Results.StatusCode(500);
    }
})
.WithName("CreateLocation")
.WithOpenApi();

app.MapGet("/api/locations", () =>
{
    var locations = LocationStorage.GetAll().Select(l => new
    {
        Id = l.Id.Value,
        Name = l.Name.Value,
        Address = l.Address.Value,
        CreatedAt = l.LifeTime.CreatedAt,
        LastUpdatedAt = l.LifeTime.LastUpdatedAt
    });
    return Results.Ok(locations);
})
.WithName("GetAllLocations")
.WithOpenApi();

app.MapGet("/api/locations/{id:guid}", (Guid id) =>
{
    var location = LocationStorage.GetById(new LocationId(id));
    
    if (location == null)
        return Results.NotFound($"Location с ID {id} не найдена");

    return Results.Ok(new
    {
        Id = location.Id.Value,
        Name = location.Name.Value,
        Address = location.Address.Value,
        CreatedAt = location.LifeTime.CreatedAt,
        LastUpdatedAt = location.LifeTime.LastUpdatedAt
    });
})
.WithName("GetLocationById")
.WithOpenApi();

app.MapPatch("/api/locations/{id:guid}", (Guid id, UpdateLocationDto request) =>
{
    try
    {
        var location = LocationStorage.GetById(new LocationId(id));
        
        if (location == null)
            return Results.NotFound($"Location с ID {id} не найдена");

        var newName = LocationName.Create(request.Name);
        var newAddress = LocationAddress.Create(request.Address);

        location.Update(newName, newAddress);
        LocationStorage.Update(location);

        return Results.Ok(new
        {
            Id = location.Id.Value,
            Name = location.Name.Value,
            Address = location.Address.Value,
            LastUpdatedAt = location.LifeTime.LastUpdatedAt
        });
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
    catch (InvalidOperationException ex)
    {
        return Results.Conflict(ex.Message);
    }
})
.WithName("UpdateLocation")
.WithOpenApi();

app.MapDelete("/api/locations/{id:guid}", (Guid id) =>
{
    var location = LocationStorage.GetById(new LocationId(id));
    
    if (location == null)
        return Results.NotFound($"Location с ID {id} не найдена");

    LocationStorage.Remove(new LocationId(id));

    return Results.NoContent();
})
.WithName("DeleteLocation")
.WithOpenApi();

app.Run();