namespace Validations;

public static class NameValidation
{
    public static bool IsValid(string name)
    {
        if (string.IsNullOrEmpty(name))
            return false;

        if (name.Length < 1)
            return false;

        return true;
    }
}