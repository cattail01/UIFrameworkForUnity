using System.Collections;
using UnityEngine;


/// <summary>
/// unity 标准双锁线程安全单例类
/// 无需挂载，需要用到时自动生成GameObject
/// 并且在场景切换时不会被删除
/// </summary>
/// <typeparam name="T"></typeparam>
public class UnityStandardSingleton<T> : MonoBehaviour
where T : MonoBehaviour
{
    private static T instance;

    private static readonly object syncLock;

    private static bool applicationIsQutting;

    static UnityStandardSingleton()
    {
        syncLock = new object();
    }
    
    public static T Instance
    {
        get
        {
            if (applicationIsQutting)
            {
                return null;
            }

            if (instance == null)
            {
                lock (syncLock)
                {
                    if (instance == null)
                    {
                        instance = FindObjectOfType<T>();
                        if (FindObjectsOfType<T>().Length > 1)
                        {
                            return instance;
                        }

                        if (instance == null)
                        {
                            // 创建gameobject物体
                            GameObject singleton = new GameObject();
                            // 在物体上加组件T
                            instance = singleton.AddComponent<T>();
                            // 给该物体重命名
                            singleton.name = "(singleton)" + typeof(T).Name;
                            // 设置场景切换时不销毁该物体
                            DontDestroyOnLoad(singleton);
                        }
                    }
                }
            }

            return instance;
        }
    }
}
