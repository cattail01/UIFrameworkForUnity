using System.Collections.Generic;

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

public class DataInfo
{
    public int id;
    // data info
    // ...
}