using Domain;
namespace DirectoryService.API.Models;

public sealed class Location
{
    private readonly LocationId _id;
    private LocationName _name;
    private LocationAddress _address;
    private readonly EntityLifeTime _lifeTime;

    private Location(LocationId id, LocationName name, LocationAddress address, EntityLifeTime lifeTime)
    {
        _id = id;
        _name = name;
        _address = address;
        _lifeTime = lifeTime;
    }

    public LocationId Id => _id;
    public LocationName Name => _name;
    public LocationAddress Address => _address;
    public EntityLifeTime LifeTime => _lifeTime;

    public static Location Create(LocationId id, LocationName name, LocationAddress address)
    {
        return new Location(id, name, address, EntityLifeTime.New());
    }

    public void Archive() => _lifeTime.Archive();
    
    public void Activate()
    {
        _lifeTime.Activate();
        _lifeTime.UpdateLastUpdatedDate();
    }

    public void Update(LocationName name, LocationAddress address)
    {
        if (_lifeTime.IsArchived)
            throw new InvalidOperationException("Нельзя изменять архивированную локацию.");
        
        _name = name;
        _address = address;
        _lifeTime.UpdateLastUpdatedDate();
    }
}

public sealed class LocationId : EntityId
{
    public LocationId(Guid value) : base(value) { }
    public static LocationId New() => new(Guid.NewGuid());
}

public sealed class LocationName
{
    public string Value { get; }

    private LocationName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Название локации не может быть пустым", nameof(value));
        
        if (value.Length > 100)
            throw new ArgumentException("Название локации не может превышать 100 символов", nameof(value));
        
        Value = value.Trim();
    }

    public static LocationName Create(string value) => new(value);
}

public sealed class LocationAddress
{
    public string Value { get; }

    private LocationAddress(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Адрес не может быть пустым", nameof(value));
        
        Value = value.Trim();
    }

    public static LocationAddress Create(string value) => new(value);
}