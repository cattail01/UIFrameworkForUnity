
using System;
using UnityEngine;

///<summary>
/// UI Root static manager
///</summary>
public class UIRoot
{
	/// <summary>
	/// UI root prefab transform component
	/// </summary>
	static Transform UIRootTransform;

	/// <summary>
	/// recycle pool 
	/// </summary>
	static Transform RecyclePool;
	static Transform WorkStation;
	static Transform NoticeStation;

	/// <summary>
	/// Initial static property
	/// </summary>
	/// <exception cref="Exception">can't find UIRoot prefab or children</exception>
	static UIRoot()
	{
		if (UIRootTransform == null)
		{
			UIRootTransform = Resources.Load<GameObject>("UI/UIRoot").transform;
			if (UIRootTransform == null)
				throw new Exception();
		}

		if (RecyclePool == null)
		{
			RecyclePool = UIRootTransform.Find("RecyclePool");
			if (RecyclePool == null)
				throw new Exception();
		}

		if (WorkStation == null)
		{
			WorkStation = UIRootTransform.Find("WorkStation");
			if (WorkStation == null)
				throw new Exception();
		}

		if (NoticeStation == null)
		{
			NoticeStation = UIRootTransform.Find("NoticeStation");
			if (NoticeStation == null)
				throw new Exception();
		}
	}

	/// <summary>
	/// set parent object for one view object
	/// </summary>
	/// <param name="view">UI view transform</param>
	/// <param name="viewState">for place in parent object</param>
	public static void SetParent(Transform view, ViewStateType viewState)
	{
		switch (viewState)
		{
			case ViewStateType.Hidden:
				view.SetParent(RecyclePool);
				break;
			case ViewStateType.Activated:
				view.SetParent(WorkStation);
				break;
			case ViewStateType.Notice:
				view.SetParent(NoticeStation);
				break;
			default:
				break;
		}
	}
}
