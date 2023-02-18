using System.Collections.Generic;

/// <summary>
/// UI MVC Model base class
/// </summary>
public class ModelBase: DoubleLockSingleton<ModelBase>
{
    private Dictionary<int, DataInfo> DataDic;

    public virtual void Add(DataInfo dataInfo)
    {
        if (!DataDic.ContainsKey(dataInfo.id))
        {
            DataDic.Add(dataInfo.id, dataInfo);
        }
    }

    // visit
    // ModelBase.Instance.<Method>;
}

/// <summary>
/// Data Type
/// </summary>
public class DataInfo
{
    public int id;
    // data info
    // ...
}
