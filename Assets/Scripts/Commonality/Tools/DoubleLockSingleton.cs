
/// <summary>
/// 无需挂载的双锁单例类
/// </summary>
/// <typeparam name="T"></typeparam>
public class DoubleLockSingleton<T>
    where T : class, new()
{
    private static T instance = null;
    private static object syncLock;

    static DoubleLockSingleton()
    {
        syncLock = new object();
    }

    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = new T();
                    }
                }
            }
            return instance;
        }
    }
}
