using ClassLibrary1.location;
        Location a = new Location();

Guid ID = Guid.Empty;
string Address = "";
string Name = null;
string TimeZone = "Some random string";
DateTime CreatedAt = DateTime.MinValue;
DateTime UpdatedAt = DateTime.MinValue;
a.ID = ID;
a.Address = Address;
a.Name = Name;
a.Timezone = TimeZone;
a.CreatedAt = CreatedAt;
a.UpdatedAt = UpdatedAt;

Console.WriteLine("ID: " + a.ID);
Console.WriteLine("Адрес: " + a.Address);
Console.WriteLine("Имя: " + a.Name);
Console.WriteLine("тайм зона: " + a.Timezone);
Console.WriteLine("Создание: " + a.CreatedAt);
Console.WriteLine("Обновление: " + a.UpdatedAt);

int b;

