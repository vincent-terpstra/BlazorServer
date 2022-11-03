namespace DataAccess;

public static class Examples
{
    public static string ExampleThrowsException(string file)
    {
        if (file.Length < 10)
            throw new FileLoadException();

        return "SUCCESS";
    }
}