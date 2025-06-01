class Singleton
{
    static void Main(string[] args)
    {
        Logger logger = Logger.GetInstance();                    //лоігка
        logger.AddLog("Програма запущена");
        logger.AddLog("Додано новий запис");

        foreach (var entry in logger.GetLog())                   
        {
            Console.WriteLine(entry);
        }

        Settings settings = Settings.GetInstance();
        Console.WriteLine($"Розмір вікна: {settings.GetSetting("WindowSize")}");
        settings.SetSetting("Language", "English");                        //зміна мови
        Console.WriteLine($"Мова: {settings.GetSetting("Language")}");

        Console.ReadLine();
    }

}
public class Settings                    //налаштування єдиний екземплр
{
    private static Settings _instance;
    private Dictionary<string, object> _settings;

    private Settings()
    {
        _settings = new Dictionary<string, object>
        {
            { "WindowSize", "800x600" },
            { "Language", "Ukrainian" }
        };
    }

    public static Settings GetInstance()   //отримати налаштування якщо є
    {
        if (_instance == null)
        {
            _instance = new Settings();
        }
        return _instance;
    }

    public void SetSetting(string key, object value)      //зміна чи додавання налаштув
    {
        _settings[key] = value;
    }

    public object GetSetting(string key)
    {
        return _settings.ContainsKey(key) ? _settings[key] : null;
    }
}

public class Logger                                        //логгер дій 
{
    private static Logger _instance;                    //єдиний екземпляр
    private List<string> _logEntries;               

    private Logger()
    { 
        _logEntries = new List<string>();
    }

    public static Logger GetInstance()              //створюємо новий якщо такого немає
    {
        if (_instance == null)
        {
            _instance = new Logger();
        }
        return _instance;
    }

    public void AddLog(string entry)                //додаємо лог
    {
        _logEntries.Add($"{DateTime.Now}: {entry}");
    }

    public List<string> GetLog()                    //повертаємо список копій логів
    {
        return new List<string>(_logEntries);
    }
}