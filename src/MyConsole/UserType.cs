namespace MyConsole;

public class UserType : SmartEnum<UserType>
{
    public static readonly UserType Normal = new (1, "Normal");
    public static readonly UserType Premium = new (2, "Premium");
    private UserType(int value, string name) : base (value, name)
    {
    }
}