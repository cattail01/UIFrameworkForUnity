
using UnityEngine;

///<summary>
/// UI Root static manager
///</summary>
public class UIRoot
{
	public static Transform UIRootTransform;
	public static Transform RecyclePool;
	public static Transform WorkStation;
	public static Transform NoticeStation;

	static UIRoot()
	{
		if (UIRootTransform == null)
		{
			Resources.Load<GameObject>("UI/UIRoot");
		}
	}

}
