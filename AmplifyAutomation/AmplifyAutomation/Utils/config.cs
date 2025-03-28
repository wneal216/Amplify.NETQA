using dotenv.net;

public static class Config
{
    static Config()
    {
        DotEnv.Load(new DotEnvOptions(probeForEnv: true, probeLevelsToSearch: 4));
        //literally could not get it to read the .env file without it searching specifically for it. mentioned this in
        //my readme file updates, not sure why this was actually happening, this seems to be a quick fix
        Console.WriteLine("Loaded BASE_URL: " + Environment.GetEnvironmentVariable("BASE_URL"));
    }

    public static string BaseUrl =>
        Environment.GetEnvironmentVariable("BASE_URL") ?? throw new Exception("BASE_URL is missing!");

    public static string TestRailUser =>
        Environment.GetEnvironmentVariable("TESTRAIL_USER") ?? "fallback@example.com";
}
