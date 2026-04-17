using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using DirectoryService.API.Models;

namespace DirectoryService.API.Storage;

public static class LocationStorage
{
    private static readonly ConcurrentDictionary<LocationId, Location> _locations = new();

    public static void Add(Location location)
    {
        if (location == null)
            throw new ArgumentNullException(nameof(location));

        if (!_locations.TryAdd(location.Id, location))
            throw new InvalidOperationException($"Location с Id {location.Id} уже существует");
    }

    public static Location? GetById(LocationId id)
    {
        return _locations.TryGetValue(id, out var location) && !location.LifeTime.IsArchived 
            ? location 
            : null;
    }

    public static IEnumerable<Location> GetAll()
    {
        return _locations.Values.Where(l => !l.LifeTime.IsArchived);
    }

    public static void Remove(LocationId id)
    {
        var location = GetById(id);
        if (location != null)
        {
            location.Archive();
        }
    }

    public static void HardRemove(LocationId id)
    {
        _locations.TryRemove(id, out _);
    }

    public static void Update(Location location)
    {
        _locations[location.Id] = location;
    }

    public static void InitializeStorage()
    {
        var location1 = Location.Create(
            LocationId.New(),
            LocationName.Create("Москва"),
            LocationAddress.Create("ул. Примерная, д. 1")
        );
        _locations.TryAdd(location1.Id, location1);

        var location2 = Location.Create(
            LocationId.New(),
            LocationName.Create("Санкт-Петербург"),
            LocationAddress.Create("пр. Тестовый, д. 2")
        );
        _locations.TryAdd(location2.Id, location2);
    }
}