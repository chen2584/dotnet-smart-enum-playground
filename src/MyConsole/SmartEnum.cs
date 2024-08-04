using System.Reflection;

namespace MyConsole;

public class SmartEnum<TEnum> : IEquatable<SmartEnum<TEnum>> where TEnum : SmartEnum<TEnum>
{
    private static Dictionary<int, TEnum> _enumerations = CreateEnumerations();
    private static Dictionary<int, TEnum> CreateEnumerations()
    {
        var enumerationType = typeof(TEnum);

        return enumerationType
            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
            .Where(fieldType => enumerationType.IsAssignableFrom(fieldType.FieldType))
            .Select(fieldInfo => (TEnum) fieldInfo.GetValue(default)!)
            .ToDictionary(x => x.Value);
    }

    public static TEnum? FromValue(int value) =>
        _enumerations.TryGetValue(value, out var enumeration) ? enumeration : null;

    public static TEnum? FromName(string name) =>
        _enumerations.Values
            .Where(w => w.Name == name)
            .FirstOrDefault();

    public string Name { get; init; } = null!;
    public int Value { get; init; }

    protected SmartEnum(int value, string name)
    {
        Value = value;
        Name = name;
    }


    public bool Equals(SmartEnum<TEnum>? other)
    {
        if (other is null)
            return false;

        return GetType() == other.GetType() && Value == other.Value;
    }

    public override bool Equals(object? obj) =>
        obj is SmartEnum<TEnum> other && Equals(other);

    public override int GetHashCode()
    {
        return Value.GetHashCode();
    }

    public override string ToString()
    {
        return Name;
    }
}